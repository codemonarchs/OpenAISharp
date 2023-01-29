using OpenAISharp.Utilities.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OpenAISharp.Utilities
{
    /// <summary>
    /// Utility used to help encode/decode tokens for the logit_bias parameter when sending a request to Completion API.
    /// </summary>
    public class EncoderUtility
    {
        /// <summary>
        /// A dictionary that maps strings to integers, used for encoding text.
        /// </summary>
        public static Dictionary<string, int> Encoder = EncoderLookup.Data;

        /// <summary>
        /// An array of strings that contains the contents of a file named "vocab.bpe".
        /// </summary>
        public static string[] BpeFile = VocabLookup.Data;

        /// <summary>
        /// A regular expression used for matching text.
        /// </summary>
        private static Regex Pat = new Regex("/'s|'t|'re|'ve|'m|'ll|'d| ?\\p{L}+| ?\\p{N}+| ?[^\\s\\p{L}\\p{N}]+|\\s+(?!\\S)|\\s+/gu", RegexOptions.Compiled);

        /// <summary>
        /// A dictionary that is created from the Encoder dictionary, but with its keys and values flipped.
        /// </summary>
        private static Dictionary<int, string> Decoder = Encoder.Select((b, i) => new { Key = Encoder[b.Key], Value = b.Key }).ToDictionary(x => x.Key, x => x.Value);

        /// <summary>
        /// A reference to BpeFile.
        /// </summary>
        private static string[] Lines = BpeFile;

        /// <summary>
        /// A list of lists of strings, created by splitting the lines of BpeFile on spaces and removing empty entries.
        /// </summary>
        public static List<List<string>> BpeMerges = Lines.Skip(1).Take(Lines.Length - 2).Select(x => x.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();

        /// <summary>
        /// A dictionary that maps integers to strings, created by the BytesToUnicode() method
        /// </summary>
        private static IDictionary<int, string> ByteEncoder = BytesToUnicode();

        /// <summary>
        /// A dictionary that is created from the ByteEncoder dictionary, but with its keys and values flipped.
        /// </summary>
        public static IDictionary<string, int> ByteDecoder = ByteEncoder.Select((b, i) => new { Key = ByteEncoder[b.Key], Value = b.Key }).ToDictionary(x => x.Key, x => x.Value);

        /// <summary>
        /// A dictionary that maps lists of strings to integers, created by the DictionaryZip() method.
        /// </summary>
        public static IDictionary<List<string>, int> BpeRanks = DictionaryZip(BpeMerges, Range(0, BpeMerges.Count));

        /// <summary>
        /// An empty dictionary used for caching.
        /// </summary>
        private static IDictionary<string, string> Cache = new Dictionary<string, string>();

        /// <summary>
        /// Returns a list of integers within a given range.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static List<int> Range(int x, int y)
            => Enumerable.Range(x, y - x).ToList();

        /// <summary>
        /// Returns the Unicode code point value of a given character.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static int Ord(string x)
            => char.ConvertToUtf32(x, 0);

        /// <summary>
        /// Returns the character represented by a given Unicode code point value.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static string Chr(int x)
            => char.ConvertFromUtf32(x);

        /// <summary>
        /// Encodes a string into a byte array using UTF-8 encoding.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] EncodeString(string str)
            => Encoding.UTF8.GetBytes(str);

        /// <summary>
        /// Decodes a byte array into a string using UTF-8 encoding.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static string DecodeString(IEnumerable<int> arr)
            => Encoding.UTF8.GetString(arr.Select(x => (byte)x).ToArray());

        /// <summary>
        /// Returns a dictionary that maps elements of two lists to each other.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static IDictionary<T1, T2> DictionaryZip<T1, T2>(List<T1> x, List<T2> y)
            => x.Zip(y, (key, value) => new { Key = key, Value = value }).ToDictionary(a => a.Key, a => a.Value);

        /// <summary>
        /// Returns a dictionary that maps integers to Unicode characters.
        /// </summary>
        /// <returns></returns>
        public static IDictionary<int, string> BytesToUnicode()
        {
            var bs = Range(Ord("!"), Ord("~") + 1).Concat(Range(Ord("¡"), Ord("¬") + 1)).Concat(Range(Ord("®"), Ord("ÿ") + 1)).ToList();
            var cs = new List<int>(bs);
            int n = 0;
            for (int b = 0; b < Math.Pow(2, 8); b++)
            {
                if (!bs.Contains(b))
                {
                    bs.Add(b);
                    cs.Add((int)Math.Pow(2, 8) + n);
                    n = n + 1;
                }
            }
            return bs.Select((b, i) => new { Key = b, Value = Chr(cs[i]) }).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Returns a set of lists of strings, where each list contains two adjacent characters in the input word.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static HashSet<List<string>> GetPairs(List<string> word)
        {
            HashSet<List<string>> pairs = new HashSet<List<string>>();
            var prevChar = word[0];
            for (int i = 1; i < word.Count; i++)
            {
                var c = word[i];
                pairs.Add(new List<string> { prevChar, c });
                prevChar = c;
            }
            return pairs;
        }

        /// <summary>
        /// Poof. Magic.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string Bpe(string token)
        {
            if (Cache.ContainsKey(token))
                return Cache[token];

            var word = token.Select(x => x.ToString()).ToList();

            var pairs = GetPairs(word);

            if (pairs.Count == 0)
                return token;

            while (true)
            {
                var minPairs = new SortedDictionary<double, List<string>>();
                foreach (var pair in pairs)
                {
                    if (!minPairs.Any(kvp => kvp.Value.SequenceEqual(pair)))
                    {
                        var rank = BpeRanks.FirstOrDefault(kvp => kvp.Key.SequenceEqual(pair)).Value;
                        if (minPairs.ContainsKey(int.MaxValue) && rank == 0)
                        {
                            minPairs[int.MaxValue] = pair;
                            continue;
                        }
                        minPairs.Add(rank == 0 ? int.MaxValue : rank, pair);
                    }
                }

                var bigram = minPairs[minPairs.Keys.Min()];

                if (!BpeRanks.Any(kvp => kvp.Key.SequenceEqual(bigram)))
                    break;

                var first = bigram[0];
                var second = bigram[1];
                var newWord = new List<string>();
                var i = 0;

                while (i < word.Count)
                {
                    var j = word.IndexOf(first, i);
                    if (j == -1)
                    {
                        newWord = newWord.Concat(word.Skip(i)).ToList();
                        break;
                    }
                    newWord = newWord.Concat(word.Skip(i).Take(j - i)).ToList();
                    i = j;

                    if (word[i] == first && i < word.Count - 1 && word[i + 1] == second)
                    {
                        newWord.Add(first + second);
                        i = i + 2;
                    }
                    else
                    {
                        newWord.Add(word[i]);
                        i = i + 1;
                    }
                }

                word = newWord;
                if (word.Count == 1)
                    break;
                else
                    pairs = GetPairs(word);
            }

            var finalWord = string.Join(" ", word);
            Cache.Add(token, finalWord);
            return finalWord;
        }

        /// <summary>
        /// Encodes a string of text into a list of integers that represent the tokens.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IEnumerable<int> Encode(string text)
        {
            var bpeTokens = new List<int>();
            var matches = Pat.Matches(text).Cast<Match>().Select(m => m.Value).ToList();
            foreach (var token in matches)
            {
                var t = string.Join("", EncodeString(token).Select(x => ByteEncoder[x]));
                var newTokens = Bpe(t).Split(' ').Select(x => Encoder[x]).ToList();
                bpeTokens.AddRange(newTokens);
            }
            return bpeTokens;
        }

        /// <summary>
        /// Decodes a list of tokens into the string of text that it represents.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public static string Decode(IEnumerable<int> tokens)
            => DecodeString(string.Join("", tokens.Select(x => Decoder[x])).Select(x => ByteDecoder[x.ToString()]));
    }
}

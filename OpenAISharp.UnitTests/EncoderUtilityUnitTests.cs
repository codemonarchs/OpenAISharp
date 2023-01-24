using OpenAISharp.Utilities;

namespace OpenAISharp.UnitTests
{
    public class EncoderUtilityUnitTests
    {
        [Theory]
        [InlineData("canada", "can ada")]
        [InlineData("company", "company")]
        [InlineData("elite", "el ite")]
        [InlineData("sandwich", "sand wich")]
        [InlineData("Pneumonoultramicroscopicsilicovolcanoconiosis", "P neum on oult ram icro sc op ics ilic ov ol can ocon iosis")]
        [InlineData("Uncopyrightable", "Un cop yright able")]
        [InlineData("esternocleidooccipitomastoideo", "estern oc le ido occ ip it om ast o ideo")]
        [InlineData("interdépartemental", "inter d é part ement al")]
        public void TestBpe(string token, string final_word)
        {
            var word = EncoderUtility.Bpe(token);
            Assert.Equal(final_word, word);
        }

        [Fact]
        public void TestGetPairs()
        {
            var word = new List<string> { "h", "o", "l", "a" };
            var expectedSize = 3;
            var pairs = EncoderUtility.GetPairs(word);

            Assert.Equal(expectedSize, pairs.Count);
            Assert.Contains(new List<string> { "h", "o" }, pairs);

            Assert.Equal(expectedSize, pairs.Count);
            Assert.Contains(new List<string> { "o", "l" }, pairs);

            Assert.Equal(expectedSize, pairs.Count);
            Assert.Contains(new List<string> { "l", "a" }, pairs);
        }

        [Fact]
        public void TestLookupListSizes()
        {
            var encoder = EncoderUtility.Encoder;
            Assert.Equal(50257, encoder.Count);

            var byteEncoder = EncoderUtility.BytesToUnicode();
            Assert.Equal(256, byteEncoder.Count);

            var byteDecoder = EncoderUtility.ByteDecoder;
            Assert.Equal(256, byteDecoder.Count);

            var bpeFile = EncoderUtility.BpeFile;
            Assert.Equal(50001, bpeFile.Length);

            var bpeMerges = EncoderUtility.BpeMerges;
            Assert.Equal(49999, bpeMerges.Count);

            var bpeRanks = EncoderUtility.BpeRanks;
            Assert.Equal(49999, bpeRanks.Count);
        }

        [Theory]
        [InlineData("canada", new int[] { 5171, 4763 })]
        [InlineData("company", new int[] { 39722 })]
        [InlineData("elite", new int[] { 417, 578 })]
        [InlineData("sandwich", new int[] { 38142, 11451 })]
        [InlineData("Pneumonoultramicroscopicsilicovolcanoconiosis", new int[] { 47, 25668, 261, 25955, 859, 2500, 1416, 404, 873, 41896, 709, 349, 5171, 36221, 42960 })]
        [InlineData("Uncopyrightable", new int[] { 3118, 22163, 4766, 540 })]
        [InlineData("esternocleidooccipitomastoideo", new int[] { 3330, 420, 293, 17305, 13966, 541, 270, 296, 459, 78, 1651 })]
        [InlineData("interdépartemental", new int[] { 3849, 67, 2634, 3911, 972, 282 })]
        public void TestEncode(string word, int[] expectedResult)
        {
            var encoded = EncoderUtility.Encode(word);
            Assert.Equal(expectedResult, encoded);
        }

        [Theory]
        [InlineData("canada", new int[] { 5171, 4763 })]
        [InlineData("company", new int[] { 39722 })]
        [InlineData("elite", new int[] { 417, 578 })]
        [InlineData("sandwich", new int[] { 38142, 11451 })]
        [InlineData("Pneumonoultramicroscopicsilicovolcanoconiosis", new int[] { 47, 25668, 261, 25955, 859, 2500, 1416, 404, 873, 41896, 709, 349, 5171, 36221, 42960 })]
        [InlineData("Uncopyrightable", new int[] { 3118, 22163, 4766, 540 })]
        [InlineData("esternocleidooccipitomastoideo", new int[] { 3330, 420, 293, 17305, 13966, 541, 270, 296, 459, 78, 1651 })]
        [InlineData("interdépartemental", new int[] { 3849, 67, 2634, 3911, 972, 282 })]
        public void TestDecode(string word, int[] expectedResult)
        {
            var decoded = EncoderUtility.Decode(expectedResult);
            Assert.Equal(word, decoded);
        }
    }
}
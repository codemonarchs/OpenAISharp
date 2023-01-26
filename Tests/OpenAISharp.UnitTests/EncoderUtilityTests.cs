using OpenAISharp.Utilities;

namespace OpenAISharp.UnitTests
{
    public class EncoderUtilityTests
    {
        public static IEnumerable<object[]> EncoderDecoderTestData()
        {
            yield return new object[] { "canada", new int[] { 5171, 4763 } };
            yield return new object[] { "company", new int[] { 39722 } };
            yield return new object[] { "elite", new int[] { 417, 578 } };
            yield return new object[] { "sandwich", new int[] { 38142, 11451 } };
            yield return new object[] { "Pneumonoultramicroscopicsilicovolcanoconiosis", new int[] { 47, 25668, 261, 25955, 859, 2500, 1416, 404, 873, 41896, 709, 349, 5171, 36221, 42960 } };
            yield return new object[] { "Uncopyrightable", new int[] { 3118, 22163, 4766, 540 } };
            yield return new object[] { "esternocleidooccipitomastoideo", new int[] { 3330, 420, 293, 17305, 13966, 541, 270, 296, 459, 78, 1651 } };
            yield return new object[] { "interdépartemental", new int[] { 3849, 67, 2634, 3911, 972, 282 } };
        }

        [Theory]
        [MemberData(nameof(EncoderDecoderTestData))]
        public void WhenEncodingWordShouldReturnExpectedTokens(string word, int[] tokens)
        {
            var result = EncoderUtility.Encode(word);
            Assert.Equal(tokens, result);
        }

        [Theory]
        [MemberData(nameof(EncoderDecoderTestData))]
        public void WhenDecodingTokensShouldReturnExpectedWord(string word, int[] tokens)
        {
            var result = EncoderUtility.Decode(tokens);
            Assert.Equal(word, result);
        }

        [Theory]
        [InlineData("canada", "can ada")]
        [InlineData("company", "company")]
        [InlineData("elite", "el ite")]
        [InlineData("sandwich", "sand wich")]
        [InlineData("Pneumonoultramicroscopicsilicovolcanoconiosis", "P neum on oult ram icro sc op ics ilic ov ol can ocon iosis")]
        [InlineData("Uncopyrightable", "Un cop yright able")]
        [InlineData("esternocleidooccipitomastoideo", "estern oc le ido occ ip it om ast o ideo")]
        [InlineData("interdépartemental", "inter d é part ement al")]
        public void WhenRunningBpeShouldReturnExpected(string token, string expectedToken)
        {
            var result = EncoderUtility.Bpe(token);
            Assert.Equal(expectedToken, result);
        }

        [Fact]
        public void WhenGettingArbitraryPairValueShouldTransformCorrectly()
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
        public void WhenRetrievingOpenAIEncoderLookupDataShouldBeOfLength50257()
            => Assert.Equal(50257, EncoderUtility.Encoder.Count);

        [Fact]
        public void WhenRetrievingByteEncoderDataShouldBeOfLength256()
            => Assert.Equal(256, EncoderUtility.BytesToUnicode().Count);

        [Fact]
        public void WhenRetrievingByteDecoderDataShouldBeOfLength256()
            => Assert.Equal(256, EncoderUtility.ByteDecoder.Count);

        [Fact]
        public void WhenRetrievingVocabDataShouldBeOfLength50001()
            => Assert.Equal(50001, EncoderUtility.BpeFile.Length);

        [Fact]
        public void WhenRetrievingBpeMergesDataShouldBeOfLength49999()
            => Assert.Equal(49999, EncoderUtility.BpeMerges.Count);

        [Fact]
        public void WhenRetrievingBpeRanksDataShouldBeOfLength49999()
            => Assert.Equal(49999, EncoderUtility.BpeRanks.Count);
    }
}
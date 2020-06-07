using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace Alpha_Top10Words
{
    public class UnitTests
    {
        [Fact]
        public void  ReadFileTest()
        {
            var file = TextUtil.ReadFile();
            Assert.NotNull(file);
        }

        [Theory]
        [InlineData("This sentance has six words within", true)]
        [InlineData("This sentance. Is also six, long", true)]
        [InlineData("This sentance should fail", false)]
        public void  ExtractWordsTest(string testSentance, bool shouldPass)
        {
            var extractedWords = TextUtil.ExtractWords(testSentance);
            Assert.NotEmpty(extractedWords);
            Assert.True((extractedWords.Count == 6) == shouldPass);
        }
       
        [Theory]
        [InlineData("This", "this", "sentance", "has", "has", "three", "doubles", "wiThIn", "within")]
        [InlineData("This","this","ThiS","Thee")]
        public void FindDuplicatesTest(params string[] testSentance)
        {
            var dupWords = TextUtil.FindDuplicates(testSentance.ToList());
            Assert.NotEmpty(dupWords);
            Assert.True(dupWords["This"] > 1);
        }

    }
}
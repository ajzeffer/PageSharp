using System.Collections.Generic;
using Xunit;
namespace PageSharp.Tests{
    public class PagerGetNextTests {
        [Fact]
        public void Pager__GetNext_GetNextPageEqualsNextPage_Success()
        {
            var pager = Pager<string>.Create(3, new List<string>{"","","", ""});
            var nextPage = pager.NextPage;
            var getNextPage = pager.GetNextPage();
            Assert.True(nextPage == getNextPage);
        }
           [Fact]
        public void Pager__GetNextOnLastPage_NextPageNull_Success()
        {
            var pager = Pager<string>.Create(3, new List<string>{"","","", ""});
            var page1 = pager.GetNextPage();
            var page2 = pager.GetNextPage();
            Assert.Null(pager.NextPage);
        }
        [Fact]
        public void Pager_GetNext_Success()
        {
            var pager = Pager<string>.Create(3, new List<string>{"","","", ""});
            var nextPage = pager.NextPage;
            var getNextPage = pager.GetNextPage();
            Assert.True(nextPage == getNextPage);
        }
    }
}
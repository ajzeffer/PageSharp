using Xunit;
using System.Collections.Generic;

namespace PageSharp.Tests
{
    public class PagerCreateTests
    {
        [Fact]
        public void Pager_ItemsMatchPageSize_TotalPages1_Success()
        {
            var pager = Pager<string>.Create(3, new List<string> { "", "", "" });
            Assert.True(pager.TotalPages == 1);
        }
        [Fact]
        public void Pager__TotalPages2_Success()
        {
            var pager = Pager<string>.Create(3, new List<string> { "", "", "", "" });
            Assert.True(pager.TotalPages == 2);
        }
        [Fact]
        public void Pager__CreatesPartialPage_Success()
        {
            var pager = Pager<string>.Create(3, new List<string> { "", "", "", "" });
            var nextPage = pager.NextPage;
            Assert.True(nextPage.Items.Count == 1);
        }


        [Fact]
        public void Pager_CurrentPageIsNull_AfterCreate_Success()
        {
            var pager = Pager<string>.Create(pageSize: 3,collection: new List<string> { "", "", "", "" });
            Assert.Null(pager.CurrentPage);
        }
        [Fact]
        public void Pager_PreviousPage_Success()
        {
            var pager = Pager<string>.Create(3, new List<string> { "", "", "", "" });
            var page1 = pager.GetNextPage();
            var page2 = pager.GetNextPage();
            var prevPage = pager.PreviousPage;
            Assert.True(page1 == prevPage);
        }

        [Fact]
        public void Pager_Create_PagesRemaining_Success()
        {
            var pager = Pager<string>.Create(3, new List<string> { "", "", "", "" });
            Assert.True(pager.PagesRemaining == 2);
        }

        [Fact]
        public void Pager_Create_NullList_PagesRemaining0_Success()
        {
            var pager = Pager<string>.Create(3, null);
            Assert.True(pager.PagesRemaining == 0);
        }
        [Fact]
        public void Pager_Create_NullList_TotalPages0_Success()
        {
            var pager = Pager<string>.Create(3, null);
            Assert.True(pager.TotalPages == 0);
        }

        [Fact]
        public void Pager__PageSizeLargerThanItems_Expect1Page_Success()
        {
            var pager = Pager<string>.Create(10, new List<string> { "", "", "", "" });
            Assert.True(pager.TotalPages == 1);
        }
        [Fact]
        public void Test()
        {
            var outcome = "";
            var dividesEqually = 3 % 4;
            var even = 3 % 3;
            var odd = 12 % 3;
            Assert.True(true);
        }

    }
}
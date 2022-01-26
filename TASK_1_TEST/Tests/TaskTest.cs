using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TASK_1_TEST.Tests
{
    class TaskTest :BaseTest
    {
        private readonly string _expectedArticle = "UK PM says he won't resign in angry exchanges";
        private readonly string _EXPECTED_ARTICLE_FROM_SEARCH = "Politics UK Archive";
        private readonly List<string> _EXPECTED_LIST_OF_ARTICLES = new List<string>() {"Party report won't be easy reading - Kuenssberg",
                                                                                      "PM is the real captain hindsight - Starmer",
                                                                                      "What action could police take?"};


        [Test]
        public void CheckTheNameMainArticle()
        {
            GetHomePage().GoToNews();
            GetNewsPage().ClosePopUp();
            Assert.AreEqual(_expectedArticle, GetNewsPage().GetTextMainArticle());
        }

        [Test]
        public void CheckTheNameSecondaryArticles() {
            GetHomePage().GoToNews();
            GetNewsPage().ClosePopUp();
            var ListSecondaryArticles = GetNewsPage().GetSecondaryArticles();
            for (int i = 0; i < ListSecondaryArticles.Count; i++)
            {
                Assert.AreEqual(_EXPECTED_LIST_OF_ARTICLES[i], ListSecondaryArticles[i].Text);
            }
        }

        [Test]
        public void CheckTheNameFirstArticleAfterSearch()
        {
            GetHomePage().GoToNews();
            GetNewsPage().ClosePopUp();
            GetNewsPage().SearchByKeyWord(GetNewsPage().GetTextCategoryOfMain());
            Assert.AreEqual(_EXPECTED_ARTICLE_FROM_SEARCH, GetSearchResultPage().GetTextFirstArticleAfterSearch());
        }
    }
}

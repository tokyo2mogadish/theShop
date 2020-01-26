using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheShop;
using System.Collections.Generic;

namespace DatabaseDriverTest
{
    [TestClass]
    public class UnitTest1
    {
        DatabaseDriver databaseDriver = new DatabaseDriver();
        [TestMethod]
        public void GetById()
        {
            Article article = new Article();
            try
            {
                //act
                article = databaseDriver.GetById(1);
            }
            catch (Exception e)
            {
                Assert.Fail("Couldnt fetch an article: \n" + e.Message);
            }
            Assert.AreEqual("Article from supplier1_1", article.Name_of_article, "Retrieved value doesnt match expected one.");
        }
        [TestMethod]
        public void GetAllArticles()
        {
            //arrange
            List<Article> articles = new List<Article>();
            //act
            try
            {
                articles = databaseDriver.GetAllArticles();
            }
            catch (Exception ex)
            {
                Assert.Fail("Couldnt retrieve list of articles:\n" + ex.Message);
            }
            //assert
            Assert.IsNotNull(articles, "List of articles does not exists");
            Assert.AreEqual(9, articles.Count, "Retrieved number of rows is not as expected");
            Assert.AreEqual("Article from supplier1_3", articles[2].Name_of_article, "Retrieved value does not match excpected one");

        }
        [TestMethod]
        public void Save()
        {
            //arrange
            List<Article> articles = new List<Article>();
            try
            {
                articles = databaseDriver.GetAllArticles();
            }
            catch (Exception ex)
            {
                Assert.Fail("Couldnt retrieve list of articles:\n" + ex.Message);
            }
            Article article = new Article()
            {
                ID = 1,
                Name_of_article = "Article from supplier4_1",
                ArticlePrice = 58,
                IsSold = false
            };
            //act 
            try
            {
                databaseDriver.Save(article);
            }
            catch (Exception ex)
            {
                Assert.Fail("Couldnt save article:\n" + ex.Message);
            }
            //assert
            Assert.AreEqual("Article from supplier4_1", articles[9].Name_of_article, "Retrieved value does not match excpected one");

        }
    }
}

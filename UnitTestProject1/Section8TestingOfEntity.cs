using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteveDelezioSEAssignment2Sit1;
using SteveDelezioSEAssignment2Sit1.Controllers;
using SteveDelezioSEAssignment2Sit1.Models;


namespace UnitTestProject1
{
    [TestClass]
    public class Section8TestingOfEntity
    {
        [TestInitialize]
        public void CreateBackup()
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=SEAssignment2Sit1;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "TakeDatabaseBackup";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Create Of Article Testing
        [TestMethod]
        public void CreateArticleTest()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms = new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            DataContext db = new DataContext();
            int intialCount = db.tbl_Articles.Count() + 1;
            ms.CreateArticle("TestingTitle", "TestingContent", "TestinComment", DateTime.Now, 2, 3, 5, 1);
            int FinalCount = db.tbl_Articles.Count();
            Assert.AreEqual(intialCount, FinalCount);
        }
        [TestMethod]
        public void CreateArticleTestWithEmptyTitle()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms = new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            DataContext db = new DataContext();
            int intialCount = db.tbl_Articles.Count();
            ms.CreateArticle(String.Empty, "TestingContent", "TestinComment", DateTime.Now, 2, 3, 5, 1);
            int FinalCount = db.tbl_Articles.Count();
            Assert.AreEqual(intialCount, FinalCount);
        }
        [TestMethod]
        public void CreateArticleTestWithEmptyContent()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms = new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            DataContext db = new DataContext();
            int intialCount = db.tbl_Articles.Count();
            ms.CreateArticle("TestingTitle", String.Empty, "TestinComment", DateTime.Now, 2, 3, 5, 1);
            int FinalCount = db.tbl_Articles.Count();
            Assert.AreEqual(intialCount, FinalCount);
        }
        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void CreateArticleTestWithInvalidDateTime()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms = new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            DataContext db = new DataContext();
            int intialCount = db.tbl_Articles.Count();
            ms.CreateArticle("TestingTitle", "TestingContent", "TestinComment", DateTime.Parse("23/01/2015"), 2, 3, 5, 1);
            int FinalCount = db.tbl_Articles.Count();
            Assert.AreEqual(intialCount, FinalCount);
        }

        //Reading Of Article Testing
        [TestMethod]
        public void ReadArticle()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms = new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            DataContext db = new DataContext();
            // ArticlesController r = new ArticlesController();
            //  r.Details(5);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ReadArticleWithWrongId()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms = new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            DataContext db = new DataContext();
            ArticlesController ac = new ArticlesController();
            tbl_Articles testarticle = new tbl_Articles();
            try
            {
                testarticle = ac.GetArticleById(-11);
            }
            finally
            {
                Assert.AreEqual(String.Empty, testarticle.ArticleContent);
            }
        }

        [TestMethod]
        public void UpdateArticle()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms = new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            DataContext db = new DataContext();
            tbl_Articles unupdated = db.tbl_Articles.SingleOrDefault(x => x.ArticleId == 12);

            ms.UpdateArticle("UpdatedTitle", "UpdatedContent", "UpdatedComment", DateTime.Now, unupdated.UserId, unupdated.ArticleMediaManagerId, unupdated.ArticleStatusId, unupdated.ArticleStateId, unupdated.ArticleId);
            db.Entry(unupdated).Reload();

            tbl_Articles updated = db.tbl_Articles.SingleOrDefault(x => x.ArticleId == 12);
            Assert.AreEqual(unupdated.ArticleId, updated.ArticleId);
            Assert.AreEqual("UpdatedTitle", updated.ArticleTitle);
            Assert.AreEqual("UpdatedContent", updated.ArticleContent);
            Assert.AreEqual("UpdatedComment", updated.ArticleComments);
        }
        [TestMethod]
        public void UpdateArticleEmptyTitle()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms = new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            DataContext db = new DataContext();
            tbl_Articles unupdated = db.tbl_Articles.SingleOrDefault(x => x.ArticleId == 12);
            string unupdatedTitle = unupdated.ArticleTitle;
            string unupdatedContent = unupdated.ArticleContent;
            string unupdatedComments = unupdated.ArticleComments;
            ms.UpdateArticle(String.Empty, "UpdatedContent", "UpdatedComment", DateTime.Now, unupdated.UserId, unupdated.ArticleMediaManagerId, unupdated.ArticleStatusId, unupdated.ArticleStateId, unupdated.ArticleId);
            db.Entry(unupdated).Reload();

            tbl_Articles updated = db.tbl_Articles.SingleOrDefault(x => x.ArticleId == 12);
            Assert.AreEqual(unupdated.ArticleId, updated.ArticleId);
            Assert.AreEqual(unupdatedTitle, updated.ArticleTitle);
            Assert.AreEqual(unupdatedContent, updated.ArticleContent);
            Assert.AreEqual(unupdatedComments, updated.ArticleComments);
        }

        [TestMethod]
        public void DeleteArticle()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms = new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            DataContext db = new DataContext();
            int initialCount = db.tbl_Articles.Count();

            ms.DeleteArticle(12);
            int FinalCount = db.tbl_Articles.Count();
            Assert.AreEqual(initialCount - 1, FinalCount);
        }

        [TestMethod]
        [ExpectedException(typeof(SoapHeaderException))]
        public void DeleteArticleWithInvalidId()
        {
            int initialCount = 0;
            int FinalCount = 0;
            DataContext db = new DataContext();
            try
            {
                SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms =
                    new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
              
                 initialCount = db.tbl_Articles.Count();

                ms.DeleteArticle(-12);
                
            }
            finally
            {
                FinalCount = db.tbl_Articles.Count();
                Assert.AreEqual(initialCount, FinalCount);
            }
        }

        
        [TestMethod]
        public void ListArticles()
        {
            ArticlesController ac = new ArticlesController();
           IEnumerable<tbl_Articles> articles= ac.GetArticlesOfOtherWritersAndStatus("Leli", 5);
           Assert.IsNotNull(articles);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ListArticlesNonExistingUser()
        {
              IEnumerable<tbl_Articles> articles= new List<tbl_Articles>();
            try
            {
                ArticlesController ac = new ArticlesController();
                articles = ac.GetArticlesOfOtherWritersAndStatus("", 5);
            }
            finally
            {
                Assert.AreEqual(0,articles.Count());
            }
        }

        [TestMethod]
        public void ListArticlesNonValidStatus()
        {
            ArticlesController ac = new ArticlesController();
            IEnumerable<tbl_Articles> articles= new List<tbl_Articles>();
            try
            {
                articles = ac.GetArticlesOfOtherWritersAndStatus("Leli", 200);
            }
            finally
            {
                 Assert.AreEqual(0,articles.Count());
            }
        
        }

        [TestCleanup]
        public void RestoreBackup()
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "RestoreDatabaseBackup";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

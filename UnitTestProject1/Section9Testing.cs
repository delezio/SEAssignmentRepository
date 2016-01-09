using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteveDelezioSEAssignment2Sit1.Controllers;
using SteveDelezioSEAssignment2Sit1.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class Section9Testing
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
#region LoginTesting
        [TestMethod]
        public void Login()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms =
                 new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            bool login=ms.Login("Leli", "abc123");
            Assert.AreEqual(true,login);
        }
        [TestMethod]
        public void LoginEmptyUsername()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms =
                 new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            bool login = ms.Login(String.Empty, "abc123");
            Assert.AreEqual(false, login);
        }
        [TestMethod]
        public void LoginLongUsername()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms =
                 new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            bool login = ms.Login("xRGJ9FmsKg2aMG1pADHe1fq0meKponxhHOtURjaeDVZIBHeZC", "abc123");
            Assert.AreEqual(false, login);
        }
        [TestMethod]
        public void LoginValidUsernameandInvalidPassword()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms =
                 new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            bool login = ms.Login("Leli", "x");
            Assert.AreEqual(false, login);
        }
        [TestMethod]
        public void LoginLongUsernameandEmptyPassword()
        {
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms =
                 new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            bool login = ms.Login("xRGJ9FmsKg2aMG1pADHe1fq0meKponxhHOtURjaeDVZIBHeZC", String.Empty);
            Assert.AreEqual(false, login);
        }
#endregion 

#region DeleteArticleTesting

        [TestMethod]
        public void DeleteArticle()
        {
             DataContext db = new DataContext();
           int initialCount= db.tbl_Articles.Count();
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms =
                new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            ms.DeleteArticle(12);
            int FinalCount = db.tbl_Articles.Count();

            Assert.AreEqual(initialCount-1,FinalCount);
        }
        [TestMethod]
        [ExpectedException(typeof(SoapHeaderException))]
        public void DeleteArticleNegativeInteger()
        {
            DataContext db = new DataContext();
            int initialCount = db.tbl_Articles.Count();
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms =
                new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            try
            {
                ms.DeleteArticle(-23);
            }
            finally
            {

                int FinalCount = db.tbl_Articles.Count();

                Assert.AreEqual(initialCount, FinalCount);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(SoapHeaderException))]
        public void DeleteArticleNonExistingArticle()
        {
            DataContext db = new DataContext();
            int initialCount = db.tbl_Articles.Count();
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms =
                new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            try
            {
                ms.DeleteArticle(950);
            }
            finally
            {

                int FinalCount = db.tbl_Articles.Count();

                Assert.AreEqual(initialCount, FinalCount);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(SoapHeaderException))]
        public void DeleteArticleZero()
        {
            DataContext db = new DataContext();
            int initialCount = db.tbl_Articles.Count();
            SteveDelezioSEAssignment2Sit1.MyService.ServiceManager ms =
                new SteveDelezioSEAssignment2Sit1.MyService.ServiceManager();
            try
            {
                ms.DeleteArticle(0);
            }
            finally
            {

                int FinalCount = db.tbl_Articles.Count();

                Assert.AreEqual(initialCount, FinalCount);
            }
        }

#endregion

#region UpdateRole

        [TestMethod]
        public void UpdateRole()
        {
            RolesController rc = new RolesController();
            DataContext db = new DataContext();
            tbl_Roles r = new tbl_Roles();
            {
                r.RoleId = 2;
                r.RoleName = "Tester";

            }
            rc.UpdateRole(r);
            tbl_Roles FinalRole = db.tbl_Roles.Find(2);
            Assert.AreEqual("Tester",FinalRole.RoleName);
            Assert.AreEqual(2,FinalRole.RoleId);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateRoleWithNull()
        {
            RolesController rc = new RolesController();
            DataContext db = new DataContext();
            rc.UpdateRole(null);


        }
#endregion

#region GetArticlesOfOtherWritersAndStatus

        [TestMethod]
        public void GetArticlesOfOtherWritersAndStatus()
        {
            ArticlesController ar = new ArticlesController();
         IEnumerable<tbl_Articles>articles=   ar.GetArticlesOfOtherWritersAndStatus("Leli", 5);

            Assert.AreEqual(articles.Count()!=0,articles.Count()!=0);
        }
        [TestMethod]
        public void GetArticlesOfOtherWritersAndStatusInvalidStatus()
        {
            ArticlesController ar = new ArticlesController();
            IEnumerable<tbl_Articles> articles = ar.GetArticlesOfOtherWritersAndStatus("Leli", 999);

            Assert.AreEqual(0,articles.Count());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetArticlesOfOtherWritersAndStatusEmptyUsername()
        {
            ArticlesController ar = new ArticlesController();
            IEnumerable<tbl_Articles> articles = ar.GetArticlesOfOtherWritersAndStatus(String.Empty,5);

            Assert.AreEqual(0,articles.Count());
        }
        [TestMethod]
        public void GetArticlesOfOtherWritersAndStatusNegativeStatus()
        {
            ArticlesController ar = new ArticlesController();
            IEnumerable<tbl_Articles> articles = ar.GetArticlesOfOtherWritersAndStatus("Leli", -5);

            Assert.AreEqual(0,articles.Count());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetArticlesOfOtherWritersAndStatusNonExistingUser()
        {
            ArticlesController ar = new ArticlesController();
            IEnumerable<tbl_Articles> articles = ar.GetArticlesOfOtherWritersAndStatus("kaopsdkaospkpdoopap", 5);

            Assert.IsNull(articles);
        }
#endregion


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

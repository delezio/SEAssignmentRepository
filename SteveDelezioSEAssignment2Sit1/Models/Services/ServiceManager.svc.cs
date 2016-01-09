using SteveDelezioSEAssignment2Sit1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SteveDelezioSEAssignment2Sit1.Models.Patterns;
using SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern;
using System.Reflection;
using System.Data;

namespace SteveDelezioSEAssignment2Sit1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceManager.svc or ServiceManager.svc.cs at the Solution Explorer and start debugging.
    public class ServiceManager : IServiceManager
    {
        private DataContext db = new DataContext();
        public void DoWork()
        {
        }
        public bool Login(string username, string password)
        {
            if (username.Length > 50 || password.Length > 50)
            {
                return false;
            }
            if (username.Length == 0 || password.Length == 0)
            {
                return false;
            }
            if (db.tbl_Users.Where(x => x.Username == username && x.Password == password).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void CreateArticle(string articleTitle, string articleContent, string articleComment,
            DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId)
        {
            // Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.NewArticleState.cs");
            //string state =db.tbl_Articles.SingleOrDefault(x => x.ArticleId == 1).tbl_ArticleStates.StateName;
            // string fullname = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + state;

            if (articleTitle.Length != 0 && articleContent.Length != 0)
            {
                Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.NewArticleState");
                //ConstructorInfo ctor = s.GetConstructor(new[] { typeof(IArticleState) });
                // (IArticleState)s.GetConstructor()
                ArticleFactory afe = new TextArticleFactory();
                Articles af = afe.CreateTextArticle((IArticleState) Activator.CreateInstance(s), articleTitle,
                    articleContent, articleComment,
                    articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId);
                //   ArticleFactory af = new TextArticle((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
                //       articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId);
                af.CreateArticle();
            }

        }
        public void AcceptArticle(string articleTitle, string articleContent, string articleComment,
           DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleId)
        {
            string currentStateName =
    db.tbl_Articles.SingleOrDefault(x => x.ArticleId == articleId).tbl_ArticleStates.StateName;
            if (currentStateName == null) throw new ArgumentNullException("currentStateName");
            string fullstringtype = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + currentStateName;
            Type s = Type.GetType(fullstringtype);
            //   Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.ReviewByWriterArticleState");
            //ConstructorInfo ctor = s.GetConstructor(new[] { typeof(IArticleState) });
            // (IArticleState)s.GetConstructor()
            ArticleFactory afe = new TextArticleFactory();
            Articles af = afe.CreateTextArticlewitId((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
                articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId, articleId);


            //ArticleFactory af = new TextArticle((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
            //    articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId, articleId);
            af.AcceptArticle();

        }
        public void RejectArticle(string articleTitle, string articleContent, string articleComment,
           DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleId)
        {
            // Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.NewArticleState.cs");
            //string state =db.tbl_Articles.SingleOrDefault(x => x.ArticleId == 1).tbl_ArticleStates.StateName;
            // string fullname = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + state;
            string currentStateName =
    db.tbl_Articles.SingleOrDefault(x => x.ArticleId == articleId).tbl_ArticleStates.StateName;
            if (currentStateName == null) throw new ArgumentNullException("currentStateName");
            string fullstringtype = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + currentStateName;
            Type s = Type.GetType(fullstringtype);
            //  Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.ReviewByWriterArticleState");
            //ConstructorInfo ctor = s.GetConstructor(new[] { typeof(IArticleState) });
            // (IArticleState)s.GetConstructor()


            ArticleFactory afe = new TextArticleFactory();
            Articles af = afe.CreateTextArticlewitId((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
                articlePublishDate, userId, mediaManagerId, articleStatusId, 1, articleId);


          //  ArticleFactory af = new TextArticle((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
           //     articlePublishDate, userId, mediaManagerId, articleStatusId, 1, articleId);
            af.RejectArticle();

        }
        public void UpdateArticle(string articleTitle, string articleContent, string articleComment,
         DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleId)
        {
            if (articleTitle != String.Empty && articleContent != String.Empty)
            {
                // Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.NewArticleState.cs");
                //string state =db.tbl_Articles.SingleOrDefault(x => x.ArticleId == 1).tbl_ArticleStates.StateName;
                // string fullname = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + state;
                string currentStateName =
                    db.tbl_Articles.SingleOrDefault(x => x.ArticleId == articleId).tbl_ArticleStates.StateName;
                if (currentStateName == null) throw new ArgumentNullException("currentStateName");
                string fullstringtype = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + currentStateName;
                Type s = Type.GetType(fullstringtype);
                //Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.NewArticleState");
                //ConstructorInfo ctor = s.GetConstructor(new[] { typeof(IArticleState) });
                // (IArticleState)s.GetConstructor()

                ArticleFactory afe = new TextArticleFactory();
                Articles af = afe.CreateTextArticlewitId((IArticleState) Activator.CreateInstance(s), articleTitle,
                    articleContent, articleComment,
                    articlePublishDate, userId, mediaManagerId, articleStatusId, 2, articleId);


                //   ArticleFactory af = new TextArticle((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
                //      articlePublishDate, userId, mediaManagerId, articleStatusId, 2, articleId);
                af.UpdateArticle();
            }

        }

        public void DeleteArticle(int articleId)
        {
            string currentStateName =
                db.tbl_Articles.SingleOrDefault(x => x.ArticleId == articleId).tbl_ArticleStates.StateName;
            if (currentStateName == null) throw new ArgumentNullException("currentStateName");
            string fullstringtype = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + currentStateName;
            Type s = Type.GetType(fullstringtype);
            // Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.NewArticleState");
            //ConstructorInfo ctor = s.GetConstructor(new[] { typeof(IArticleState) });
            // (IArticleState)s.GetConstructor()

            ArticleFactory afe = new TextArticleFactory();
            Articles af = afe.CreateTextArticlewitIdandState((IArticleState) Activator.CreateInstance(s), articleId);


           // ArticleFactory af = new TextArticle((IArticleState)Activator.CreateInstance(s), articleId);
            af.DeleteArticle();
        }






        public void AcceptArticleMediaManager(string articleTitle, string articleContent, string articleComment,
   DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleId)
        {
            string currentStateName =
    db.tbl_Articles.SingleOrDefault(x => x.ArticleId == articleId).tbl_ArticleStates.StateName;
            if (currentStateName == null) throw new ArgumentNullException("currentStateName");
            string fullstringtype = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + currentStateName;
            Type s = Type.GetType(fullstringtype);
            // Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.ReviewByMediaManagerState");
            //ConstructorInfo ctor = s.GetConstructor(new[] { typeof(IArticleState) });
            // (IArticleState)s.GetConstructor()

            ArticleFactory afe = new TextArticleFactory();
            Articles af = afe.CreateTextArticlewitId((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
                articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId, articleId);


          //  ArticleFactory af = new TextArticle((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
          //      articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId, articleId);
            af.AcceptArticle();

        }
        public void RejectArticleMediaManager(string articleTitle, string articleContent, string articleComment,
           DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleId)
        {
            // Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.NewArticleState.cs");
            //string state =db.tbl_Articles.SingleOrDefault(x => x.ArticleId == 1).tbl_ArticleStates.StateName;
            // string fullname = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + state;
            string currentStateName =
    db.tbl_Articles.SingleOrDefault(x => x.ArticleId == articleId).tbl_ArticleStates.StateName;
            if (currentStateName == null) throw new ArgumentNullException("currentStateName");
            string fullstringtype = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + currentStateName;
            Type s = Type.GetType(fullstringtype);
            // Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern..ReviewByMediaManagerState");
            //ConstructorInfo ctor = s.GetConstructor(new[] { typeof(IArticleState) });
            // (IArticleState)s.GetConstructor()

            ArticleFactory afe = new TextArticleFactory();
            Articles af = afe.CreateTextArticlewitId((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
                articlePublishDate, userId, mediaManagerId, articleStatusId, 1, articleId);


           // ArticleFactory af = new TextArticle((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
           //     articlePublishDate, userId, mediaManagerId, articleStatusId, 1, articleId);
            af.RejectArticle();

        }

        public bool DoesUsernameExist(string username)
        {
            if (db.tbl_Users.Where(x => x.Username == username).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RegisterUser(string username, string password, string firstName, string surname, int roleId)
        {
            tbl_Users u = new tbl_Users();
            u.Username = username;
            u.Password = password;
            u.FirstName = firstName;
            u.Surname = surname;
            u.RoleId = roleId;
            db.tbl_Users.Add(u);
            db.SaveChanges();
         }

        public void DefaultStateWorkflowOnRegister(int position, int stateId, int userId)
        {
            tbl_StateWorkflows s = new tbl_StateWorkflows
            {
                StateId = stateId,
                UserId = userId,
                WorflowPositionId = position
            };
            db.tbl_StateWorkflows.Add(s);
            db.SaveChanges();
        }

       

    }
}

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
            Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.NewArticleState");
            //ConstructorInfo ctor = s.GetConstructor(new[] { typeof(IArticleState) });
            // (IArticleState)s.GetConstructor()

            ArticleFactory af = new TextArticle((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
                articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId);
            af.CreateArticle();

        }
        public void AcceptArticle(string articleTitle, string articleContent, string articleComment,
           DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId,int articleId)
        {
            Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.ReviewByWriterArticleState");
            //ConstructorInfo ctor = s.GetConstructor(new[] { typeof(IArticleState) });
            // (IArticleState)s.GetConstructor()

            ArticleFactory af = new TextArticle((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
                articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId,articleId);
            af.AcceptArticle();

        }
        public void RejectArticle(string articleTitle, string articleContent, string articleComment,
           DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId,int articleId)
        {
            // Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.NewArticleState.cs");
            //string state =db.tbl_Articles.SingleOrDefault(x => x.ArticleId == 1).tbl_ArticleStates.StateName;
            // string fullname = "SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern." + state;
            Type s = Type.GetType("SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern.ReviewByWriterArticleState");
            //ConstructorInfo ctor = s.GetConstructor(new[] { typeof(IArticleState) });
            // (IArticleState)s.GetConstructor()

            ArticleFactory af = new TextArticle((IArticleState)Activator.CreateInstance(s), articleTitle, articleContent, articleComment,
                articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId,articleId);
            af.RejectArticle();

        }

    }
}

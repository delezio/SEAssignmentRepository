using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern
{
    public class NewArticleState : IArticleState
    {
        private ArticleFactory a;
        private DataContext db = new DataContext();
        public NewArticleState(ArticleFactory a)
        {
            this.a = a;
        }
        public NewArticleState()
        {
        }

        public void CreateArticle(string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId)
        {
            tbl_Articles a = new tbl_Articles();
            a.ArticleTitle = articleTitle;
            a.ArticleContent = articleContent;
            a.ArticleComments = articleComment;
            a.ArticlePublishDateTime = articlePublishDate;
            a.UserId = userId;
            a.ArticleMediaManagerId = mediaManagerId;
            a.ArticleStatusId =articleStatusId;
            a.ArticleStateId = articleStateId;
            db.tbl_Articles.Add(a);
            db.SaveChanges();
        }

        public void AcceptArticle(string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleId)
        {
            throw new NotImplementedException();
        }

        public void RejectArticle(string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleId)
        {
            throw new NotImplementedException();
        }

    }
}
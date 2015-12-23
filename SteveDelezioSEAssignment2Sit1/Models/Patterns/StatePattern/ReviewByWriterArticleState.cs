using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern
{
    public class ReviewByWriterArticleState: IArticleState
    {
        private DataContext db = new DataContext();
        public void CreateArticle(string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId)
        {
            throw new NotImplementedException();
        }

        public void AcceptArticle(string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId,int articleId)
        {
            tbl_Articles a = db.tbl_Articles.SingleOrDefault(x => x.ArticleId == articleId);
            a.ArticleTitle = articleTitle;
            a.ArticleContent = articleContent;
            a.ArticleComments = articleComment;
            a.ArticlePublishDateTime = articlePublishDate;
            a.UserId = userId;
            a.ArticleMediaManagerId = mediaManagerId;
            a.ArticleStatusId = articleStatusId;
            a.ArticleStateId = articleStateId;
            db.Entry(a).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RejectArticle(string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate,
            int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleId)
        {
            tbl_Articles a = db.tbl_Articles.SingleOrDefault(x => x.ArticleId == articleId);
            a.ArticleTitle = articleTitle;
            a.ArticleContent = articleContent;
            a.ArticleComments = articleComment;
            a.ArticlePublishDateTime = articlePublishDate;
            a.UserId = userId;
            a.ArticleMediaManagerId = mediaManagerId;
            a.ArticleStatusId = articleStatusId;
            a.ArticleStateId = articleStateId;
            db.Entry(a).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
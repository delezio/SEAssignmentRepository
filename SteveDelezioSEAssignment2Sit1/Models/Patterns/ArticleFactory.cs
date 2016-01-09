using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public abstract class ArticleFactory
    {
        public virtual Articles CreateTextArticle(IArticleState state, string articleTitle, string articleContent,
            string articleComment, DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId,
            int articleStateId)
        {
            return null;
        }

        public virtual Articles CreateTextArticlewitId(IArticleState state, string articleTitle, string articleContent,
            string articleComment, DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId,
            int articleStateId, int articleId)
        {
            return null;
        }

        public virtual Articles CreateTextArticlewitIdandState(IArticleState state, int articleId)
        {
            return null;
        }


    }
}
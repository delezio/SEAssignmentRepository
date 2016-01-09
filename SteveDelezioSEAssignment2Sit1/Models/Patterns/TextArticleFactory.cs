using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public class TextArticleFactory:ArticleFactory
    {
        public TextArticleFactory()
        {
        }

        public override Articles CreateTextArticle(IArticleState state, string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId)
        {
            return new TextArticle(state, articleTitle, articleContent, articleComment,
                articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId);


        }
        public override Articles CreateTextArticlewitId(IArticleState state, string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId,int articleId)
        {
            return new TextArticle(state, articleTitle, articleContent, articleComment,
                articlePublishDate, userId, mediaManagerId, articleStatusId, articleStateId,articleId);


        }
        public override Articles CreateTextArticlewitIdandState(IArticleState state, int articleId)
        {
            return new TextArticle(state, articleId);


        }
    }
}
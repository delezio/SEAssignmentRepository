using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public class TextArticle : ArticleFactory
    {
        public IArticleState state;
        public string articleTitle;
        public string articleContent;
        public string articleComment;
        public DateTime articlePublishDate;
        public int userId;
        public int mediaManagerId;
        public int articleStatusId;
        public int articleStateId;

        public TextArticle(IArticleState state, string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId)
        {
            this.state = state;
            this.articleTitle = articleTitle;
            this.articleContent = articleContent;
            this.articleComment = articleComment;
            this.articlePublishDate = articlePublishDate;
            this.userId = userId;
            this.mediaManagerId = mediaManagerId;
            this.articleStatusId = articleStatusId;
            this.articleStateId = articleStateId;
        }

        public TextArticle(IArticleState state)
        {
            this.state = state;
        }
        public TextArticle()
        {
        }
        public override void CreateArticle()
        {
            base.CreateArticle();
            state.CreateArticle(articleTitle,  articleContent, articleComment, articlePublishDate, userId,  mediaManagerId, articleStatusId,articleStateId);
        }
        public override void UpdateArticle()
        {
            base.UpdateArticle();
        }
        public override void DeleteArticle()
        {
            base.DeleteArticle();
        }
    }
}
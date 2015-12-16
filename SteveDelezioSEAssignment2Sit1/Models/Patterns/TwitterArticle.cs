using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public class TwitterArticle : ArticleComponent
    {
        private ArticleFactory myArticleFactory;
        public TwitterArticle(ArticleFactory articleFactory, ArticleComponent articleComponent) : base(articleFactory, articleComponent)
        {
        }

        public TwitterArticle(ArticleFactory articleFactory)
        {
            myArticleFactory = articleFactory;
        }

        public override void Upload(ArticleFactory a)
        {
            //Upload to Twitter
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public class FacebookArticle : ArticleComponent
    {
        private ArticleFactory myArticleFactory;
        public FacebookArticle(ArticleFactory articleFactory, ArticleComponent articleComponent) : base(articleFactory, articleComponent)
        {
        }

        public FacebookArticle(ArticleFactory articleFactory)
        {
            myArticleFactory = articleFactory;
        }
        public override void Upload(ArticleFactory a)
        {
           
            //Upload to Facebook
        }
    }
}
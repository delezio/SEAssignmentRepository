using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public class TwitterArticle : ArticleComponent
    {
        public TwitterArticle(ArticleComponent articleComponent) : base(articleComponent)
        {
        }

        public override void Upload(ArticleFactory a)
        {
            //Upload to Twitter
        }
    }
}
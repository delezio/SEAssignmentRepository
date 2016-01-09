using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public class FacebookArticle : ArticleComponent
    {
        public FacebookArticle(ArticleComponent articleComponent)
            : base(articleComponent)
        {
        }
        public override void Upload(Articles a)
        {

            //Upload to Facebook
        }
    }
}
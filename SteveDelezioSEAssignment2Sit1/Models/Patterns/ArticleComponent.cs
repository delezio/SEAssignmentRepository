using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public  abstract class ArticleComponent
    {
        ArticleComponent ArticleComp { get; set; }

        public ArticleComponent(ArticleComponent articleComponent)
        {
            ArticleComp= articleComponent;
        }

        protected ArticleComponent()
        {
            
        }

        public abstract void Upload(Articles a);

    }
}
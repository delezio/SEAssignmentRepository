using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public  abstract class ArticleComponent
    {
        ArticleFactory ArticleFactory { get; set; }
        ArticleComponent ArticleComp { get; set; }

        public ArticleComponent(ArticleFactory articleFactory, ArticleComponent articleComponent)
        {
            ArticleFactory = articleFactory;
            ArticleComp= articleComponent;
        }

        protected ArticleComponent()
        {
            
        }

        public abstract void Upload(ArticleFactory a);

    }
}
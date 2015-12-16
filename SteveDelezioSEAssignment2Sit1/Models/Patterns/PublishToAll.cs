using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public class PublishToAll
    {
        public void Publish()
        {
            ArticleFactory af = new TextArticle();
            ArticleComponent ac = new FacebookArticle(af,new TwitterArticle(af));
            ac.Upload(af);
        }
    }
}
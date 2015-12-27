using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public class PublishToAll
    {
        public void Publish()
        {
            TextArticle af = new TextArticle();
            ArticleComponent ac = new FacebookArticle(new TwitterArticle(null));
            ac.Upload(af);

            
        }
    }
}
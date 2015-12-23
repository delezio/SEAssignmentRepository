using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns
{
    public abstract class ArticleFactory
    {
        public Type State;

        public virtual void CreateArticle(){

        }

        public virtual void AcceptArticle()
        {
            
        }

        public virtual void RejectArticle()
        {
            
        }
        public virtual void UpdateArticle()
        {

        }
        public virtual void DeleteArticle()
        {

        }
    }
}
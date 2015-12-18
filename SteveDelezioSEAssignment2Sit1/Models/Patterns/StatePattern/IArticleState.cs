using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SteveDelezioSEAssignment2Sit1.Models.Patterns.StatePattern
{
    public interface IArticleState
    {

        void CreateArticle(string articleTitle, string articleContent, string articleComment,
            DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId);

    }
}

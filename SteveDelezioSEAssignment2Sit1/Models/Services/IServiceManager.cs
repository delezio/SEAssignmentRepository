﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SteveDelezioSEAssignment2Sit1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceManager" in both code and config file together.
    [ServiceContract]
    public interface IServiceManager
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        [XmlSerializerFormat]
        bool Login(string username, string password);

        [OperationContract]
        [XmlSerializerFormat]
        void CreateArticle(string articleTitle, string articleContent,string articleComment,DateTime articlePublishDate,int userId, int mediaManagerId,int articleStatusId,int articleStateId);
        [OperationContract]
        [XmlSerializerFormat]
        void AcceptArticle(string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId,int articleId);
        [OperationContract]
        [XmlSerializerFormat]
        void RejectArticle(string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId,int articleId);

        [OperationContract]
        [XmlSerializerFormat]
        void UpdateArticle(string articleTitle, string articleContent, string articleComment, DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId, int articleId);

        [OperationContract]
        [XmlSerializerFormat]
        void DeleteArticle(int ArticleId);
        [OperationContract]
        [XmlSerializerFormat]
       void AcceptArticleMediaManager(string articleTitle, string articleContent, string articleComment,
            DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            int articleId);
        [OperationContract]
        [XmlSerializerFormat]
        void RejectArticleMediaManager(string articleTitle, string articleContent, string articleComment,
            DateTime articlePublishDate, int userId, int mediaManagerId, int articleStatusId, int articleStateId,
            int articleId);

    }
}

using SteveDelezioSEAssignment2Sit1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SteveDelezioSEAssignment2Sit1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceManager" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceManager.svc or ServiceManager.svc.cs at the Solution Explorer and start debugging.
    public class ServiceManager : IServiceManager
    {
        private DataContext db = new DataContext();
        public void DoWork()
        {
        }
        public bool Login(string username, string password)
        {
            if (db.tbl_Users.Where(x => x.Username == username && x.Password == password).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

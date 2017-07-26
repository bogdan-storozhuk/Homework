using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12_1
{
    class Validator:IValidator
    {
        private UserCollection _collection=new UserCollection();

        public bool AuthenticationSuccess(IUser user)
        {

            if (_collection.GetUser(user))
            {
                return true;
            }
            return false;
        }


    }
}

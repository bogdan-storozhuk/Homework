using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12_1
{
    interface IValidator
    {
        bool AuthenticationSuccess(IUser user);
    }
}

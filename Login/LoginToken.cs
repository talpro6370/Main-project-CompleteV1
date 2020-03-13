using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class LoginToken<T> : ILoginTokenBase where T : IUser // user = admin\airline\customer
    {
        public T User { get; set; }
        
    }
}

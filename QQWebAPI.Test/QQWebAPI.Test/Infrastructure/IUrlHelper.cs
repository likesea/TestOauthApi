using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QQWebAPI.Test.Infrastructure
{
    public interface IUrlHelper
    {
        
        string GetOauthUrl(string code,string state);
        string GetRequestUrl();
    }
}

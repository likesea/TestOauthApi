using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Ninject.Activation;
using Newtonsoft.Json;
using QQWebAPI.Test.Models;

namespace QQWebAPI.Test.Infrastructure
{
    public interface IProxy
    {
        UserTokenModel GetAccessTokenResponse(string getUserTokenUrl);
    }

    public class Proxy :  IProxy
    {
        public UserTokenModel GetAccessTokenResponse(string getUserTokenUrl)
        {
            UserTokenModel userToken =new UserTokenModel(){ret =-1};
            HttpWebRequest request = WebRequest.Create(getUserTokenUrl) as HttpWebRequest;
            //request.Accept = "*/*";
            //request.Headers.Add("Accept-Encoding","gzip,deflate,sdch");
            //request.Headers.Add("Accept-Language", ":zh-CN,zh;q=0.8,en;q=0.6");
            Encoding enc = Encoding.GetEncoding("GB2312"); 
            var response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, System.Text.Encoding.UTF8);
            var text = sr.ReadToEnd();
            userToken = JsonConvert.DeserializeObject<UserTokenModel>(text);
            if (userToken != null && userToken.ret == 0)
            {
                return userToken;
            }
            return userToken;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Management;
using QQWebAPI.Test.Models;

namespace QQWebAPI.Test.Infrastructure
{
    public class QQAPIUrlHelper:IUrlHelper
    {
        private static readonly string urlBase = "https://openapi.b.qq.com/";
        private static readonly int appID = Int32.Parse(ConfigurationManager.AppSettings["APPID"]);
        private static readonly string appSecret = ConfigurationManager.AppSettings["APPSecret"];
        private static readonly string redirectUri = ConfigurationManager.AppSettings["RedirectUri"];
        private static GetOauthParams oauthParams;
        
        public string GetOauthUrl(string code,string state)
        {
            if (oauthParams == null)
            {
                oauthParams = new GetOauthParams(appID,appSecret,"","",redirectUri);
            }
            oauthParams.Code = code;
            oauthParams.State = state;
            string oauthBaseUrl = urlBase +
                                  "oauth2/companyToken?grant_type={0}&app_id={1}&app_secret={2}&code={3}&state={4}&redirect_uri={5}";
            oauthBaseUrl=string.Format(oauthBaseUrl, oauthParams.GrantType, oauthParams.AppID, oauthParams.AppSecret,
                oauthParams.Code, oauthParams.State, oauthParams.RedirectUri);
            return oauthBaseUrl;
        }

        public string GetRequestUrl()
        {
            return "";
        }
    }
}
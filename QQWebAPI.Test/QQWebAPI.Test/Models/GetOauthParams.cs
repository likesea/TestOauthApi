using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QQWebAPI.Test.Models
{
    /// <summary>
    /// 获取授权token参数实体
    /// </summary>
    public class GetOauthParams
    {
        public string GrantType {
            get { return "authorization_code"; }
        }
        /// <summary>
        ///第三方应用appid
        /// </summary>
        public int AppID { get; set; }

        public string AppSecret { get; set; }
        /// <summary>
        /// 回调地址
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 帮助第三方防范CSRF攻击的，会原样返回
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 须与下发企业授权码一样的redirect_uri一致
        /// </summary>
        public string RedirectUri { get; set; }

        public GetOauthParams(int appId, string appsecret, string code, string state, string redirectUri)
        {
            AppID = appId;
            AppSecret = appsecret;
            Code = code;
            State = state;
            RedirectUri = redirectUri;
        }
    }
}
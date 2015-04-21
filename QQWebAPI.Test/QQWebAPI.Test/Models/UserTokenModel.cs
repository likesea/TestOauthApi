using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QQWebAPI.Test.Models
{
    public interface IUserTokenModel
    {
    }

    public class UserTokenModel : IUserTokenModel
    {
        /// <summary>
        /// 返回码：0 正常， >0 异常
        /// </summary>
        public int ret { get; set; }
        /// <summary>
        /// 如果ret不为0，会有相应的错误信息提示，UTF-8编码。
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// JS对象格式的数据
        /// </summary>
        public Data data { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 认证token
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 是该access token的有效期，单位为秒
        /// </summary>
        public int expires_in  { get; set; }
        /// <summary>
        /// 与请求参数中的state一样
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 当前登录的号码，或者当前授权的号码的open_id
        /// </summary>
        public string open_id { get; set; }
        /// <summary>
        /// access_token过期后，调用 刷新access token
        /// </summary>
        public string refresh_token { get; set; }
    }
}
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QQWebAPI.Test.Infrastructure;

namespace QQWebAPI.Test.Controllers
{
    public class HomeController : Controller
    {
        private IUrlHelper urlHelper;
        private IProxy proxy;
        private const string state = "testState";

        public HomeController(IUrlHelper helper,IProxy proxy)
        {
            urlHelper = helper;
            this.proxy = proxy;
        }
        // GET: Home
        public ActionResult Index()
        {
            string url = urlHelper.GetCompanyOauthUrl("", "1231");
            string userLoginUri = urlHelper.GetUserLoginUrl(state);
            ViewBag.Url = url;
            ViewBag.UserLoginUri = userLoginUri;
            return View();

        }
        /// <summary>
        /// 公司开通app回调
        /// </summary>
        /// <param name="code"></param>
        /// <param name="returnState"></param>
        /// <returns></returns>
        public ActionResult CallBack(string code,string state)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(state) || state.Trim(' ') != HomeController.state)
            {
                ViewBag.ErrorMessage = "登录失败";
                View("Error");
            }
           
            string oauthUrl = urlHelper.GetCompanyOauthUrl(code, state); 
            return View();
        }
        /// <summary>
        /// 用户登录callback
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ActionResult UserCallBack(string code, string state)
        {

            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(state) || state.Trim(' ') != HomeController.state)
            {
                string msg = Request["msg"];
                ViewBag.ErrorMessage = msg??"登录失败";
                return View("Error");
            }
            string getAccessTokenUrl = urlHelper.GetUserOauthUrl(code, state);
             var result = Redirect(getAccessTokenUrl);
            var userToken =proxy.GetAccessTokenResponse(getAccessTokenUrl);
            if (userToken.ret == 0)
            {
                ViewBag.OpenId = userToken.data.open_id;
                ViewBag.Success = "登录成功";
            }
            else
            {
                ViewBag.Success = userToken.msg;
            }
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
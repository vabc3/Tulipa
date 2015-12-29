using Senparc.Weixin.MP;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MvcExtension;
using System.Web.Mvc;

namespace Tulipe.WXService
{
    public class WeixinController : Controller
    {
        private const string Token = "weixin";

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(PostModel postModel, string echostr)
        {
            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Content(echostr);
            }
            else
            {
                return Content("error!");
            }
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Content("error！");
            }

            postModel.Token = Token;
            postModel.EncodingAESKey = "";
            postModel.AppId = Util.AppId;



            var messageHandler = new TulipeMessageHandler(Request.InputStream, postModel);
            messageHandler.Execute();
            return new WeixinResult(messageHandler);
        }

        [HttpGet]
        [ActionName("Log")]
        public ActionResult Get1()
        {
            return Content("log:\n" + string.Join("<br/>\n", TulipeMessageHandler.logger));

        }
    }
}
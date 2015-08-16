using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MvcExtension;
using System.Web.Http;
using System.Web.Mvc;

namespace Tulipe.WXService
{
    /*
    public class WeixinController : ApiController
    {
        private const string Token = "weixin";//对应微信后台设置的Token，建议设置地复杂一些

        /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url填写如：http://weixin.senparc.com/weixin
        /// </summary>
        public IHttpActionResult Get(PostModel postModel, string echostr)
        {
            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Ok(echostr);//返回随机字符串则表示验证通过
            }
            else
            {
                return Ok("failed:" + postModel.Signature + "," + CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, Token) + "。如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }

        public IHttpActionResult Post(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Ok("参数错误！");
            }

            postModel.Token = Token;
            postModel.EncodingAESKey = "";//根据自己后台的设置保持一致
            postModel.AppId = "wx3fa7c72e903fb1fc";//根据自己后台的设置保持一致

            var messageHandler = new CustomMessageHandler(Request.InputStream, postModel);//接收消息

            messageHandler.Execute();//执行微信处理过程

            return new WeixinResult(messageHandler);//返回结果
        }
    }
    */
}
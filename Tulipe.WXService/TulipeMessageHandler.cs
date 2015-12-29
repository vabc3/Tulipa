using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;

namespace Tulipe.WXService
{
    internal class CustomMessageContext : MessageContext<IRequestMessageBase, IResponseMessageBase>
    {
    }

    internal class TulipeMessageHandler : MessageHandler<CustomMessageContext>
    {
        private Stream inputStream;
        private PostModel postModel;
        private static ITulipeService service = new TulipeService();
        internal static IList<string> logger = new List<string>();


        public TulipeMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0)
           : base(inputStream, postModel, maxRecordCount)

        {
            this.inputStream = inputStream;
            this.postModel = postModel;
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "未知指令:(";
            return responseMessage;
        }

        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();

            //responseMessage.Content = "FromUserName:" + requestMessage.FromUserName + "\n username:" + CurrentMessageContext.UserName;
            responseMessage.Content = handle(requestMessage.Content, requestMessage.FromUserName);
            return responseMessage;
        }

        private string handle(string text, string user)
        {
            logger.Add(Util.GetNickName(user) + ":" + text);

            string result = "说点啥？输入h 查看帮助";
            var data = text.Split(' ');
            switch (data[0])
            {
                case "V":
                    result = "version 0.2.1";
                    break;
                case "h":
                    result = "创建游戏：c 坏人数 好人数 坏人词 好人词\n加入游戏：j 游戏ID\n查看游戏 ：v 游戏ID";
                    break;
                case "c":
                    try
                    {
                        var p1c = int.Parse(data[1]);
                        var p2c = int.Parse(data[2]);
                        var id = service.CreateGame(user, p1c, p2c, data[3], data[4]);

                        result = "创建成功，游戏ID" + id;
                    }
                    catch (Exception)
                    {
                        result = "参数错误，再检查下？";
                    }

                    break;
                case "j":
                    try
                    {
                        var gid = int.Parse(data[1]);
                        var game = service.GetGame(gid);
                        bool character; string word;
                        if (game.Join(user, out character, out word))
                        {
                            result = "加入成功:您是" + (character ? "坏人" : "好人") + "词语:" + word;
                        }
                        else
                        {
                            result = "游戏已满员|";
                        }
                    }
                    catch (Exception)
                    {
                        result = "参数错误，再检查下？";
                    }
                    break;
                case "v":
                    try
                    {
                        var gid = int.Parse(data[1]);
                        var game = service.GetGame(gid);

                        if (game.Owner == user)
                        {
                            result = GetTable(game);
                        }
                        else
                        {
                            result = "创建者才有权限看哦|";
                        }
                    }
                    catch (Exception)
                    {
                        result = "参数错误啦|";
                    }
                    break;
                default:
                    break;
            }

            return result;
        }

        private static string GetTable(TulipeGame game)
        {
            var b = new StringBuilder();
            b.AppendLine("当前游戏人数:" + game.UserCount);

            for (var i = 0; i < game.UserCount; i++)
            {
                b.AppendFormat("{0}->{1}\n", Util.GetNickName(game.Users[i]), game.Characters[i] ? "坏人" : "好人");
            }

            return b.ToString();
        }
    }
}
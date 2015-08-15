using System.IO;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MessageHandlers;
using System;
using System.Xml.Linq;

namespace Tulipe.WXService
{
    internal class CustomMessageHandler : IMessageHandlerDocument
    {
        private Stream inputStream;
        private PostModel postModel;

        public CustomMessageHandler(Stream inputStream, PostModel postModel)
        {
            this.inputStream = inputStream;
            this.postModel = postModel;
        }

        public XDocument FinalResponseDocument
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public XDocument RequestDocument
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public XDocument ResponseDocument
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string TextResponseMessage
        {
            get
            {
                return "hitfrom" + DateTime.Now;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        internal void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
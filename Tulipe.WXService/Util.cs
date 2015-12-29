using System;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.CommonAPIs;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Tulipe.WXService
{
    internal static class Util
    {
        internal static string AppId = Environment.GetEnvironmentVariable("APPSETTING_AppId");
        internal static string AppSecret = Environment.GetEnvironmentVariable("APPSETTING_AppSecret");

        private static IDictionary<string, string> cache = new ConcurrentDictionary<string, string>();

        public static string GetNickName(string oid)
        {
            string nickName = "foo";
            if (!cache.TryGetValue(oid, out nickName))
            {
                var accessToken = AccessTokenContainer.TryGetToken(AppId, AppSecret);
                var dat = UserApi.Info(accessToken, oid);
                cache[oid] = dat.nickname;
                nickName = dat.nickname;
            }

            return nickName;
        }
    }
}
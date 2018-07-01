using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "!!!!! 改成自己的ChannelAccessToken !!!!!";
        const string AdminUserId= "!!!改成你的AdminUserId!!!";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //定義Flex Message
            var Flex = @"
[
    {
      ""type"": ""flex"",
      ""altText"": ""This is a Flex Message"",
      ""contents"": 
{
  ""type"": ""bubble"",
  ""header"": {
                ""type"": ""box"",
    ""layout"": ""horizontal"",
    ""contents"": [
      {
        ""type"": ""text"",
        ""text"": ""NEWS DIGEST"",
        ""weight"": ""bold"",
        ""color"": ""#aaaaaa"",
        ""size"": ""sm""
      }
    ]
  },
  ""hero"": {
    ""type"": ""image"",
    ""url"": ""https://scdn.line-apps.com/n/channel_devcenter/img/fx/01_4_news.png"",
    ""size"": ""full"",
    ""aspectRatio"": ""20:13"",
    ""aspectMode"": ""cover"",
    ""action"": {
      ""type"": ""uri"",
      ""uri"": ""http://linecorp.com/""
    }
  },
  ""body"": {
    ""type"": ""box"",
    ""layout"": ""horizontal"",
    ""spacing"": ""md"",
    ""contents"": [
      {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""flex"": 1,
        ""contents"": [
          {
            ""type"": ""image"",
            ""url"": ""https://scdn.line-apps.com/n/channel_devcenter/img/fx/02_1_news_thumbnail_1.png"",
            ""aspectMode"": ""cover"",
            ""aspectRatio"": ""4:3"",
            ""size"": ""sm"",
            ""gravity"": ""bottom""
          },
          {
            ""type"": ""image"",
            ""url"": ""https://scdn.line-apps.com/n/channel_devcenter/img/fx/02_1_news_thumbnail_2.png"",
            ""aspectMode"": ""cover"",
            ""aspectRatio"": ""4:3"",
            ""margin"": ""md"",
            ""size"": ""sm""
          }
        ]
      },
      {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""flex"": 2,
        ""contents"": [
          {
            ""type"": ""text"",
            ""text"": ""7 Things to Know for Today"",
            ""gravity"": ""top"",
            ""size"": ""xs"",
            ""flex"": 1
          },
          {
            ""type"": ""separator""
          },
          {
            ""type"": ""text"",
            ""text"": ""Hay fever goes wild"",
            ""gravity"": ""center"",
            ""size"": ""xs"",
            ""flex"": 2
          },
          {
            ""type"": ""separator""
          },
          {
            ""type"": ""text"",
            ""text"": ""LINE Pay Begins Barcode Payment Service"",
            ""gravity"": ""center"",
            ""size"": ""xs"",
            ""flex"": 2
          },
          {
            ""type"": ""separator""
          },
          {
            ""type"": ""text"",
            ""text"": ""LINE Adds LINE Wallet"",
            ""gravity"": ""bottom"",
            ""size"": ""xs"",
            ""flex"": 1
          }
        ]
      }
    ]
  },
  ""footer"": {
    ""type"": ""box"",
    ""layout"": ""horizontal"",
    ""contents"": [
      {
        ""type"": ""button"",
        ""action"": {
          ""type"": ""uri"",
          ""label"": ""More"",
          ""uri"": ""https://linecorp.com""
        }
      }
    ]
  }
}


    }
  ]
";

            //define bot instance
            Bot bot = new Bot(channelAccessToken);

            //Push Flex Message
            bot.PushMessageWithJSON(AdminUserId, Flex);
        }
    }
}
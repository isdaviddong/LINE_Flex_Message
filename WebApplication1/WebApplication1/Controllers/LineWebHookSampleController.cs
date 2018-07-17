using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "!!!!! 改成自己的ChannelAccessToken !!!!!"; //channel access token
        const string AdminUserId = "!!!改成你的AdminUserId!!!";  //admin user id

        #region"flex"
        //定義Flex Message
        string Flex = @"
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
        #endregion

        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.text == "text") //收到文字
                        this.ReplyMessage(LineEvent.replyToken, "你說了:" + LineEvent.message.text);
                    if (LineEvent.message.text == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                    if (LineEvent.message.text == "flex") //收到貼圖
                        this.ReplyMessageWithJSON(LineEvent.replyToken, Flex);
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}

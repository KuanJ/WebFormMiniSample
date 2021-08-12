using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    /// <summary>
    /// WeatherDataHandler 的摘要描述
    /// </summary>
    public class WeatherDataHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string acc = context.Request.QueryString["account"];
            string pwd = context.Request.Form["Password"];

            if (acc == "admin" && pwd == "12345")
            {
                context.Response.ContentType = "application/json";

                WeatherDataModel model = WeatherDataReader.ReadData();
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                context.Response.Write(jsonText);
            }

            else
            {
                context.Response.StatusCode = 401;
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
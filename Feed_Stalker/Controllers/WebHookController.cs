using Feed_Stalker.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Feed_Stalker
{
    public class WebHookController : ApiController
    {

        List<string> webhookPosts = new List<string>();
        
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public  void Post(HttpRequestMessage request)
        {
            string jsonContent =  request.Content.ReadAsStringAsync().Result;

            //jsonContent = jsonContent.Substring(2, jsonContent.Length-3);
            //GithubPostViewModel dataSet = JsonConvert.DeserializeObject<GithubPostViewModel>(jsonContent);
            //GithubPostViewModel post = new GithubPostViewModel();
            //post.author =;
            //post.githubEvent=;
            //post.message=;
            //post.timestamp =;

            webhookPosts.Add(jsonContent);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public List<string> getWebHooks()
        {
            return webhookPosts;
        }
    }
}
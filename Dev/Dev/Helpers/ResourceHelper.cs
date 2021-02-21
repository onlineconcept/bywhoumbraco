using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Helpers
{
    public class ResourceHelper
    {
        private readonly IResourceRepository _repository;
        private readonly IMemoryCache _cache;

        public ResourceHelper(IResourceRepository repository, IMemoryCache cache)
        {                
            _cache = cache;
            _repository = repository;
        }

        public async  Task<string> GetResource(string key)
        {
            List<Resource> resources = null;
            if (!_cache.TryGetValue("resources", out resources))
            {
                resources = await _repository.GetAllResource();
                _cache.Set("resources", resources, TimeSpan.FromMinutes(360));
            }
            var resource = resources.FirstOrDefault(x => x.Name.ToLower() == key.ToLower());
            return resource != null ? resource.Value : key;           
        }
        public async Task<object> GetAllResources()
        {
            List<Resource> resources;
            if (!_cache.TryGetValue("resources", out resources))
            {
                resources = await _repository.GetAllResource();
                _cache.Set("resources", resources, TimeSpan.FromMinutes(360));
            }
            
            return JsonConvert.SerializeObject(resources);
        }
        public HtmlString SerializeSingleQuote(object obj, bool indent = false)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (JsonTextWriter writer = new JsonTextWriter(sw))
                {
                    writer.QuoteChar = '\'';

                    JsonSerializer ser = new JsonSerializer();
                    if (indent)
                    {
                        ser.Formatting = Formatting.Indented;
                    }
                    ser.Serialize(writer, obj);
                }
            }

            return new HtmlString(sb.ToString().Replace("\"", "&quot;"));
        }
    }
}

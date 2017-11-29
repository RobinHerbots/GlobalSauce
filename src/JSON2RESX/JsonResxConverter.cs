using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace JSON2RESX
{
    public class JsonResxConverter
    {
        private static List<string> resxKey = new List<string>();
        public static void Convert(string jsonFile, string resxFile)
        {
            resxKey.Clear();
            JObject jsonJObject = JObject.Parse(File.ReadAllText(jsonFile));
            if (jsonJObject != null)
                using (ResXResourceWriter resx = new ResXResourceWriter(resxFile))
                {
                    foreach (var property in jsonJObject.Properties())
                    {
                        if (property.HasValues)
                        {
                            foreach (var childToken in property.Children())
                            {
                                ProcessJtoken(resx, childToken);
                            }
                        }
                        else
                        {
                            var key = property.Name.ToLower();
                            if (!resxKey.Contains(key))
                            {
                                resxKey.Add(key);
                                resx.AddResource(property.Name, property.Value);
                            }
                        }
                    }
                }
        }

        private static void ProcessJtoken(ResXResourceWriter resx, JToken jtoken)
        {
            if (jtoken.HasValues)
            {
                foreach (JToken childToken in jtoken)
                {
                    ProcessJtoken(resx, childToken);
                }
            }
            else
            {
                var key = jtoken.Path.Replace(".", "_").ToLower();
                if (!resxKey.Contains(key))
                {
                    resxKey.Add(key);
                    resx.AddResource(jtoken.Path.Replace(".", "_"), jtoken.Value<string>());
                }
            }
        }
    }
}

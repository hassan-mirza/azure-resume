using Newtonsoft.Json;

namespace HassanMirza.Resume
{
   public class Item
   {
       [JsonProperty(PropertyName="id")]
       public string Id {get;set;}
       
       [JsonProperty(PropertyName="counter")]
       public int Count {get;set;}
   }
}
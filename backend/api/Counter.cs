using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using Newtonsoft.Json;

public class Counter 
{
    [JsonProperty(PropertyName ="id")]
    public string Id {get; set;}
    [JsonProperty(PropertyName ="count")]
    public int Count {get; set;}
}
using Newtonsoft.Json;

namespace API.Services.RandomUserAPI.Models;

public class RandomUserAPIResultModel
{
    [JsonProperty("results")]
    public IEnumerable<RandomUserAPIModel> Results { get; set; }

    [JsonProperty("info")]
    public Info Info { get; set; }
}
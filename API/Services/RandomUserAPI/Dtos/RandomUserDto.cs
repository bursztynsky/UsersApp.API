using Newtonsoft.Json;

namespace API.Services.RandomUserApi.Dtos;

public class RandomUserResultDto
{
    [JsonProperty("results")]
    public IEnumerable<RandomUserDto> Results { get; set; }

    [JsonProperty("info")]
    public Info Info { get; set; }
}

public class RandomUserDto
{
    [JsonProperty("name")]
    public Name Name { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }
}

public class Info
{
    [JsonProperty("seed")]
    public string Seed { get; set; }

    [JsonProperty("results")]
    public int Results { get; set; }

    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }
}

public class Name
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("first")]
    public string First { get; set; }

    [JsonProperty("last")]
    public string Last { get; set; }
}
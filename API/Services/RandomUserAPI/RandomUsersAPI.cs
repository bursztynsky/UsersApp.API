using System.Net;
using API.Services.RandomUserAPI.Abstractions;
using API.Services.RandomUserAPI.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Tools.Exceptions;

namespace API.Services.RandomUserAPI;

public class RandomUsersAPI : IRandomUsersAPI
{
    private readonly IRestClient _client;
    private readonly RandomUsersAPIConfig? _config;

    public RandomUsersAPI(
        IOptions<RandomUsersAPIConfig>? options
    )
    {
        _config = options?.Value;

        if (!string.IsNullOrWhiteSpace(_config?.Url))
        {
            _client = new RestClient(_config.Url);
        }
    }

    public async Task<IEnumerable<RandomUserAPIModel>> Get(int amount)
    {
        var request = new RestRequest()
            .AddParameter("results", amount, ParameterType.QueryString);

        var response = await _client.ExecuteAsync(request);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new RandomUsersAPIException(response.ErrorMessage ??
                                              "There was a problem with connecting to the RandomUser API endpoint");

        if (string.IsNullOrWhiteSpace(response.Content))
            return new List<RandomUserAPIModel>();

        try
        {
            var result = JsonConvert.DeserializeObject<RandomUserAPIResultModel>(response.Content);

            return result?.Results.ToList() ?? new List<RandomUserAPIModel>();
        }
        catch (Exception ex)
        {
            // TODO: log error
        }

        return new List<RandomUserAPIModel>();
    }
}
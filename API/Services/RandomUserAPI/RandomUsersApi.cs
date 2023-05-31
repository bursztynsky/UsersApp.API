using System.Net;
using API.Exceptions;
using API.Services.RandomUserApi.Abstractions;
using API.Services.RandomUserApi.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace API.Services.RandomUserApi;

public class RandomUsersApi : IRandomUsersApi
{
    private readonly IRestClient _client;
    private readonly RandomUsersAPIConfig? _config;

    public RandomUsersApi(
        IOptions<RandomUsersAPIConfig>? options
    )
    {
        _config = options?.Value;

        if (!string.IsNullOrWhiteSpace(_config?.Url))
        {
            _client = new RestClient(_config.Url);
        }
    }

    public async Task<IEnumerable<RandomUserDto>> Get(int amount)
    {
        var request = new RestRequest()
            .AddParameter("results", amount, ParameterType.QueryString);

        var response = await _client.ExecuteAsync(request);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new RandomUsersApiException(response.ErrorMessage ?? "There was a problem with connecting to the RandomUser API endpoint");

        if (string.IsNullOrWhiteSpace(response.Content))
            return new List<RandomUserDto>();

        try
        {
            var result = JsonConvert.DeserializeObject<RandomUserResultDto>(response.Content);

            return result?.Results.ToList() ?? new List<RandomUserDto>();
        }
        catch (Exception)
        {
            throw new RandomUsersApiException($"Error during deserialization of the result.");
        }
    }
}
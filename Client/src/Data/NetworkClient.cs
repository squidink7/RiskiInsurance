using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace RiskiInsurance;

public static class NetworkClient
{
	const string ServerAddress = "http://localhost";
	const int ServerPort = 3000;

	public async static Task<bool> AddRecord(ClientRecord record) => await PostMessage("addrecord", record);

	private async static Task<bool> PostMessage<T>(string Endpoint, T content)
	{
		var client = new HttpClient();
		// Convert object to json
		var json = JsonSerializer.Serialize(content, typeof(T), JsonContext.Default);
		// Post object to server
		try
		{
			var res = await client.PostAsync($"{ServerAddress}:{ServerPort}/{Endpoint}", new StringContent(json));
			// Check if success
			return res?.IsSuccessStatusCode ?? false;
		}
		catch (HttpRequestException)
		{
			return false;
		}
	}
} 
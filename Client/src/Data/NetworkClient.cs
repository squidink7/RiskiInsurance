using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace RiskiInsurance;

public static class NetworkClient
{
	const string ServerAddress = "http://localhost";
	const int ServerPort = 3000;

	/// <summary>
	/// Use to add a record to the server database
	/// </summary>
	/// <param name="record">ClientRecord</param>
	/// <returns>boolean representing success</returns>
	public async static Task<bool> AddRecord(ClientRecord record)
	{
		var res = await PostMessage("addrecord", record);
		return res?.IsSuccessStatusCode ?? false;
	}

	/// <summary>
	/// Sends A Post request to the given endpoint of the server
	/// </summary>
	/// <param name="Endpoint"></param>
	/// <param name="content"></param>
	/// <returns>The Server Response to the message as an HttpResponseMessage</returns>
	private async static Task<HttpResponseMessage?> PostMessage<T>(string Endpoint, T content)
	{
		var client = new HttpClient();
		// Convert object to json
		var json = JsonSerializer.Serialize(content, typeof(T), JsonContext.Default);
		// Post object to server
		var res = await client.PostAsync($"{ServerAddress}:{ServerPort}/{Endpoint}", new StringContent(json));
		// Check if success
		return res;
	}
} 
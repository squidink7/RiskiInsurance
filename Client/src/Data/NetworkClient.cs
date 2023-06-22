using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiskiInsurance;

public static class NetworkClient
{
	const string ServerAddress = "http://localhost";
	const int ServerPort = 3000;

	public async static Task<bool> AddRecord(ClientRecord record) => await SendMessage("addrecord", "POST", record);

	public async static Task<bool> RemoveRecord(string id) => await SendMessage<object>($"deleteRecord?ID={id}", "DELETE", null);

    public async static Task<ClientRecord[]> GetRecords()
    {
        //Request Records from server
        HttpResponseMessage message = await GetMessage("records");
        //Convert response to json string if no content use an empty array
        string jsonContent = message.Content.ToString() ?? "[]";
        //Convert jsonConteent to ClientRecord array
        ClientRecord[]? Records = JsonSerializer.Deserialize<ClientRecord[]>(jsonContent);
        //Because Records is nullable must check that it is not null before returning
        return Records ?? new ClientRecord[0];
    }


	private async static Task<bool> SendMessage<T>(string endpoint, string method, T? content)
	{
		var client = new HttpClient();
		// Convert object to json
		var json = content == null ? JsonSerializer.Serialize(content, typeof(T), JsonContext.Default) : "{}";
		// Post object to server
		try
		{
			HttpResponseMessage res = new HttpResponseMessage();
			switch (method)
			{
				case "POST":
					res = await client.PostAsync($"{ServerAddress}:{ServerPort}/{endpoint}", new StringContent(json));
					break;
				case "DELETE":
					res = await client.DeleteAsync($"{ServerAddress}:{ServerPort}/{endpoint}");
					break;
			}
			// Check if success
			return res.IsSuccessStatusCode;
		}
		catch (HttpRequestException)
		{
			return false;
		}
	}

	private async static Task<HttpResponseMessage> GetMessage(string endpoint)
	{
		var client = new HttpClient();
		try
		{
			var res = await client.GetAsync($"{ServerAddress}:{ServerPort}/{endpoint}");
			return res;
		}
		catch
		{
			return new HttpResponseMessage();
		}
	}
} 
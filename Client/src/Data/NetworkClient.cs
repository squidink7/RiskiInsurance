using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Collections;
using System;

namespace RiskiInsurance;

public static class NetworkClient
{
	const string ServerAddress = "http://localhost";
	const int ServerPort = 3000;

	/// <summary>
	/// Adds a record to the servers record list
	/// </summary>
	/// <param name="record"></param>
	/// <returns></returns>
	public async static Task<bool> AddRecord(ClientRecord record) => await SendMessage("addrecord", "POST", record);

	/// <summary>
	/// Removes a record from the servers record list
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async static Task<bool> RemoveRecord(string id) => await SendMessage<object>($"deleteRecord?ID={id}", "DELETE", null);

	/// <summary>
	/// Gets Records from server
	/// </summary>
	/// <returns></returns>
    public async static Task<AvaloniaList<ClientRecord>> GetRecords()
    {
        //Request Records from server
        HttpResponseMessage message = await GetMessage("records");
        //Convert response to json string if no content use an empty array
        string jsonContent = await message.Content.ReadAsStringAsync() ?? "[]";
		//Convert jsonContent to ClientRecord array, if the convert returns null a new empty array is made
		ClientRecordJsonRecieve[] RecordsArr = JsonSerializer.Deserialize<ClientRecordJsonRecieve[]>(jsonContent) ?? new ClientRecordJsonRecieve[0];
		//Create the avaloniaList to return
        AvaloniaList<ClientRecord> RecordsList = new AvaloniaList<ClientRecord>();
		//Populate the list
		for (int i = 0; i < RecordsArr.Length; i++)
		{
			RecordsList.Add(RecordsArr[i].ToClientRecord());
		}
        return RecordsList;
    }

	/// <summary>
	/// Send a message to the server with the specified content and method
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="endpoint">the endpoint on the server to send the message to</param>
	/// <param name="method">the method to use when contacting the server eg. POST</param>
	/// <param name="content">the body of the message if appliciable</param>
	/// <returns></returns>
	private async static Task<bool> SendMessage<T>(string endpoint, string method, T? content)
	{
		var client = new HttpClient();
		// Convert object to json
		var json = content == null ? "{}" : JsonSerializer.Serialize(content, typeof(T), JsonContext.Default);
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

	/// <summary>
	/// Sends a get request to the server at a specified endpoint
	/// </summary>
	/// <param name="endpoint">The endpoint on the server to send the request</param>
	/// <returns></returns>
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
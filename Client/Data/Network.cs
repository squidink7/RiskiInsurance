using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public static class NetworkClient
{
    /// <summary>
    /// Use to add a record to the server database
    /// </summary>
    /// <param name="record">ClientRecord</param>
    /// <returns>boolean representing success</returns>
    public async static Task<bool> AddRecord(ClientRecord record)
    {
        HttpClient client = new HttpClient();
        var res = await PostMessage("/addRecord", record);
        return res.IsSuccessStatusCode;
    }

    /// <summary>
    /// Sends A Post request to the given endpoint of the server
    /// </summary>
    /// <param name="Endpoint"></param>
    /// <param name="content"></param>
    /// <returns>The Server Response to the message as an HttpResponseMessage</returns>
    private async static Task<HttpResponseMessage?> PostMessage(string Endpoint, object content)
    {
        HttpClient client = new HttpClient();
        var res = await client.PostAsync($"localhost:3000{Endpoint}", new StringContent(JsonSerializer.Serialize(content)));
        return res;
    }
} 
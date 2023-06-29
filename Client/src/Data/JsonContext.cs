using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia.Collections;

namespace RiskiInsurance;

[JsonSerializable(typeof(ClientRecord))]
[JsonSerializable(typeof(ClientRecord[]))]
[JsonSourceGenerationOptions(IncludeFields = true)]
public partial class JsonContext : JsonSerializerContext {}
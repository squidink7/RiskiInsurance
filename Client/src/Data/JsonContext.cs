using System.Text.Json;
using System.Text.Json.Serialization;

namespace RiskiInsurance;

[JsonSerializable(typeof(ClientRecord))]
[JsonSourceGenerationOptions(IncludeFields = true)]
public partial class JsonContext : JsonSerializerContext {}
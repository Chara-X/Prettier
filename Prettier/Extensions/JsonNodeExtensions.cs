using System.Text.Json;
using System.Text.Json.Nodes;

namespace Prettier.Extensions;

public static class JsonNodeExtensions
{
    public static string Prettify(this JsonNode jsonNode, int depth = 0)
    {
        var indent = new string(' ', depth * 2);
        return jsonNode switch
        {
            JsonObject jsonObject => $"{{{Environment.NewLine}{string.Join($",{Environment.NewLine}", jsonObject.Select(x => $"{indent}  \"{x.Key}\": {Prettify(x.Value!, depth + 1)}"))}{Environment.NewLine}{indent}}}",
            JsonArray jsonArray => $"[{Environment.NewLine}{string.Join($",{Environment.NewLine}", jsonArray.Select(x => $"{indent}  {Prettify(x!, depth + 1)}"))}{Environment.NewLine}{indent}]",
            JsonValue jsonValue => jsonValue.GetValueKind() == JsonValueKind.String ? $"\"{jsonValue}\"" : jsonValue.ToString(),
            null => "null",
            _ => throw new ArgumentOutOfRangeException(nameof(jsonNode))
        };
    }
}
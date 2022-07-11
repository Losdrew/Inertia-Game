using Newtonsoft.Json;

namespace GUI.Storage;

internal class SerializationWorker
{
    private readonly JsonSerializerSettings _settings = new() { TypeNameHandling = TypeNameHandling.Auto };

    public void Serialize<TEntity>(TEntity obj, string jsonFileName)
    {
        var json = JsonConvert.SerializeObject(obj, _settings);
        File.WriteAllText(jsonFileName, json);
    }

    public TEntity? Deserialize<TEntity>(string fileName)
    {
        var json = File.ReadAllText(fileName);
        return JsonConvert.DeserializeObject<TEntity>(json, _settings);
    }
}
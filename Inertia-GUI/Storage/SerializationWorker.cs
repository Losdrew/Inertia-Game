using Newtonsoft.Json;

namespace GUI.Storage;

internal class SerializationWorker
{
    public void Serialize<TEntity>(TEntity obj, string jsonFileName)
    {
        var json = JsonConvert.SerializeObject(obj);
        File.WriteAllText(jsonFileName, json);
    }

    public TEntity? Deserialize<TEntity>(string fileName)
    {
        var json = File.ReadAllText(fileName);
        return JsonConvert.DeserializeObject<TEntity>(json);
    }
}
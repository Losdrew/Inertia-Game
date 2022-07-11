using CommonCodebase.Core;

namespace GUI.Storage.Repositories;

internal class MapRepository
{
    private const string MapFileLocation = @"Resources\JsonFiles\Maps.json";

    private readonly SerializationWorker? _serializationWorker = new();

    public List<Map>? GetAllMaps()
    {
        return _serializationWorker?.Deserialize<List<Map>>(MapFileLocation);
    }

    public void UpdateMapList(List<Map> newMapList)
    {
        _serializationWorker?.Serialize(newMapList, MapFileLocation);
    }
}
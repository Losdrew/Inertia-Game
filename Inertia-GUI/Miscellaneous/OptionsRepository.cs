namespace GUI.Miscellaneous;

internal class OptionsRepository
{
    private const string OptionsFileLocation = @"Resources\JsonFiles\Options.json";

    private readonly SerializationWorker? _serializationWorker = new();

    public Options GetOptions()
    {
        var options = _serializationWorker?.Deserialize<Options>(OptionsFileLocation);

        if (options?.MapSize == (0, 0) || 
            options?.DirectionControls is null || 
            options.MusicControls is null || 
            options.Language is null)
        {
            options = new Options();
            UpdateOptions(options);
        }

        return options;
    }

    public void UpdateOptions(Options options)
    {
        _serializationWorker?.Serialize(options, OptionsFileLocation);
    }
}
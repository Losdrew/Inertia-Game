using GUI.Engines;
using GUI.Storage.Objects;
using GUI.Storage.Repositories;
using System.Globalization;

namespace GUI.Storage.Services;

internal static class OptionsService
{
    private static readonly OptionsRepository OptionsRepository = new();

    public static Options GetOptions()
    {
        return OptionsRepository.GetOptions();
    }

    public static void UpdateOptions(Options options)
    {
        OptionsRepository.UpdateOptions(options);
    }

    public static void ApplyOptions()
    {
        var options = GetOptions();

        ApplyLanguageSettings();
        InputEngine.DirectionControls = options.DirectionControls.ToDictionary(x => x.Value, x => x.Key);
        InputEngine.MusicControls = options.MusicControls.ToDictionary(x => x.Value, x => x.Key);
    }

    public static void ApplyLanguageSettings()
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(GetOptions().Language);
    }
}
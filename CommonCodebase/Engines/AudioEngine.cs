using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace CommonCodebase.Engines;

public static class AudioEngine
{
    // All available sounds
    private static readonly Dictionary<string, UnmanagedMemoryStream> Audio = new()
    {
        // Background music
        { "Music1", CommonResources.Music1 },
        { "Music2", CommonResources.Music2 },
        { "Music3", CommonResources.Music3 },
        { "Music4", CommonResources.Music4 },
        { "Music5", CommonResources.Music5 },
        { "Music6", CommonResources.Music6 },
        { "Music7", CommonResources.Music7 },
        { "Music8", CommonResources.Music8 },
        { "Music9", CommonResources.Music9 },

        // Sound Effects
        { "Wall", CommonResources.Wall },
        { "Stop", CommonResources.Stop },
        { "Prize", CommonResources.Prize },
        { "Trap", CommonResources.GameOver },
        { "Win", CommonResources.Win }
    };

    private static readonly IWavePlayer SoundOut;
    private static readonly IWavePlayer MusicOut;

    private static readonly MixingSampleProvider SoundMixer;
    private static readonly MixingSampleProvider MusicMixer;

    static AudioEngine()
    {
        Initialize(out SoundOut, out SoundMixer);
        Initialize(out MusicOut, out MusicMixer);
    }

    public static void PlayAudio(string soundName)
    {
        var stream = Audio[soundName];
        RefreshStreamPosition(stream);
        var reader = new WaveFileReader(stream);
        ChooseMixer(soundName).AddMixerInput(new AutoDisposeFileReader(reader));
    }

    public static void StartMusicPlaylist()
    {
        // Play next music when previous ends
        MusicMixer.MixerInputEnded += (sender, args) => PlayMusic();

        // Start playing music
        PlayMusic();
    }

    public static void PauseMusic()
    {
        if (MusicOut.PlaybackState == PlaybackState.Playing)
            MusicOut.Pause();

        else MusicOut.Play();
    }

    public static void SwitchMusic()
    {
        // Clean mixer off previous music
        MusicMixer.RemoveAllMixerInputs();

        // Start playback if it's stopped or paused
        if (MusicOut.PlaybackState != PlaybackState.Playing)
            MusicOut.Play();

        PlayMusic();
    }

    private static void PlayMusic()
    {
        // Music is chosen at random
        PlayAudio("Music" + new Random().Next(1, 10));
    }

    private static void Initialize(out IWavePlayer output, out MixingSampleProvider mixer)
    {
        // Only 44.1 kHz 8-bit Mono .wav files are allowed
        mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
        mixer.ReadFully = true;
        output = new WaveOutEvent();
        output.Init(mixer);
        output.Play();
    }

    private static void RefreshStreamPosition(Stream stream)
    {
        stream.Position = 0;
    }

    private static MixingSampleProvider ChooseMixer(string soundName)
    {
        return soundName.Contains("Music") ? MusicMixer : SoundMixer;
    }
}

public class AutoDisposeFileReader : IWaveProvider
{
    private readonly WaveFileReader _reader;

    private bool _isDisposed;

    public AutoDisposeFileReader(WaveFileReader reader)
    {
        _reader = reader;
        WaveFormat = reader.WaveFormat;
    }

    public WaveFormat WaveFormat { get; }

    public int Read(byte[] buffer, int offset, int count)
    {
        if (_isDisposed) return 0;

        var read = _reader.Read(buffer, offset, count);

        if (read == 0)
        {
            _reader.Dispose();
            _isDisposed = true;
        }

        return read;
    }
}
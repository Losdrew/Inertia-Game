using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace MyGame.Engines;

public static class AudioEngine
{
    // All available sounds
    private static readonly Dictionary<string, UnmanagedMemoryStream> Audio = new()
    {
        // Background music
        { "Music1", Resources.Music1 },
        { "Music2", Resources.Music2 },
        { "Music3", Resources.Music3 },
        { "Music4", Resources.Music4 },
        { "Music5", Resources.Music5 },
        { "Music6", Resources.Music6 },
        { "Music7", Resources.Music7 },
        { "Music8", Resources.Music8 },
        { "Music9", Resources.Music9 },

        // Sound Effects
        { "Wall", Resources.Wall },
        { "Stop", Resources.Stop },
        { "Prize", Resources.Prize },
        { "Trap", Resources.GameOver },
        { "Win", Resources.Win }
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

    public delegate void SoundHandler(string soundName);
    public delegate void MusicHandler();

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

    public static void PlayMusic()
    {
        // Clean mixer off previous music
        MusicMixer.RemoveAllMixerInputs();

        // Start playback if it's stopped or paused
        if (MusicOut.PlaybackState != PlaybackState.Playing)
            MusicOut.Play();

        // Music is chosen at random
        PlayAudio("Music" + new Random().Next(1, 10));
    }

    public static void PauseMusic()
    {
        if (MusicOut.PlaybackState == PlaybackState.Playing)
            MusicOut.Pause();

        else MusicOut.Play();
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

internal class AutoDisposeFileReader : IWaveProvider
{
    private readonly WaveFileReader _reader;

    private bool _isDisposed;

    public WaveFormat WaveFormat { get; }

    public AutoDisposeFileReader(WaveFileReader reader)
    {
        _reader = reader;
        WaveFormat = reader.WaveFormat;
    }

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
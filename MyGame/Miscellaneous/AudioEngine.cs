using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace MyGame.Miscellaneous;

public class AudioEngine
{
    // All available sounds
    private readonly Dictionary<string, UnmanagedMemoryStream> _audio = new()
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

    private readonly MixingSampleProvider _soundMixer;
    private readonly MixingSampleProvider _musicMixer;

    public AudioEngine()
    {
        Initialize(out _soundMixer);
        Initialize(out _musicMixer);
        StartMusicPlaylist();
    }

    public delegate void SoundHandler(string soundName);

    public void PlayAudio(string soundName)
    {
        var stream = _audio[soundName];
        RefreshStreamPosition(stream);
        var reader = new WaveFileReader(stream);
        ChooseMixer(soundName).AddMixerInput(new AutoDisposeFileReader(reader));
    }

    private void Initialize(out MixingSampleProvider mixer)
    {
        // Only 44.1 kHz 8-bit Mono .wav files are allowed
        mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
        mixer.ReadFully = true;
        var output = new WaveOutEvent();
        output.Init(mixer);
        output.Play();
    }

    private void StartMusicPlaylist()
    {
        // Play next music when previous ends
        _musicMixer.MixerInputEnded += (sender, args) => PlayMusic();

        // Start playing music
        PlayMusic();
    }

    private void PlayMusic()
    {
        // Music is chosen at random
        PlayAudio("Music" + new Random().Next(1, 10));
    }

    private void RefreshStreamPosition(Stream stream)
    {
        stream.Position = 0;
    }

    private MixingSampleProvider ChooseMixer(string soundName)
    {
        return soundName.Contains("Music") ? _musicMixer : _soundMixer;
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
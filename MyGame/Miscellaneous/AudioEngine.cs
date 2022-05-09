using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace MyGame.Miscellaneous;

public class AudioEngine
{
    private readonly IWavePlayer _outputDevice;

    private readonly MixingSampleProvider _mixer;

    public delegate void AudioHandler(Stream audioStream);

    // Only 44.1 kHz 8-bit Mono .wav files are allowed
    public AudioEngine()
    {
        _outputDevice = new WaveOutEvent();
        _mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
        _mixer.ReadFully = true;
        _outputDevice.Init(_mixer);
        _outputDevice.Play();
    }

    public void PlaySound(Stream audioStream)
    {
        var reader = new WaveFileReader(audioStream);
        _mixer.AddMixerInput(new AutoDisposeFileReader(reader));
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
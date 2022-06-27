using NAudio.Wave;

namespace CommonCodebase.Engines;

internal class AutoDisposeFileReader : IWaveProvider
{
    private bool _isDisposed;

    private readonly WaveFileReader _reader;

    public AutoDisposeFileReader(WaveFileReader reader)
    {
        _reader = reader;
        WaveFormat = reader.WaveFormat;
    }

    public WaveFormat WaveFormat { get; }

    public int Read(byte[] buffer, int offset, int count)
    {
        if (_isDisposed)
        {
            return 0;
        }

        var read = _reader.Read(buffer, offset, count);

        if (read == 0)
        {
            _reader.Dispose();
            _isDisposed = true;
        }

        return read;
    }
}
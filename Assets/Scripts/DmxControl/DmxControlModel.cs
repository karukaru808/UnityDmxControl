using System;
using System.IO.Ports;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace DmxControl
{
    public sealed class DmxControlModel : IDisposable
    {
        private const float BreakMilliSecond = 0.088f;
        private const float MarkAfterBreakMilliSecond = 0.008f;

        public byte[] DmxData = new byte[513];

        public uint FPS
        {
            get => _fps;
            set
            {
                if (61 > value && value > 0)
                {
                    _fps = value;
                }
            }
        }

        private uint _fps;
        private SerialPort _serialPort;
        private CancellationTokenSource _tokenSource;

        public void OpenDmxPort(string portName)
        {
            _tokenSource = new CancellationTokenSource();

            _serialPort = new SerialPort(portName, 250000, Parity.None, 8, StopBits.Two);
            _serialPort.Open();

            SendDmx(_tokenSource.Token).Forget();
        }

        private async UniTask SendDmx(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _serialPort.BreakState = true;
                await UniTask.Delay(TimeSpan.FromMilliseconds(BreakMilliSecond), cancellationToken: token);
                _serialPort.BreakState = false;
                await UniTask.Delay(TimeSpan.FromMilliseconds(MarkAfterBreakMilliSecond), cancellationToken: token);

                _serialPort.Write(DmxData, 0, DmxData.Length);

                await UniTask.Delay(
                    TimeSpan.FromMilliseconds(1f / FPS * 1000f - BreakMilliSecond - MarkAfterBreakMilliSecond),
                    cancellationToken: token);
            }
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
            _serialPort?.Close();
            _serialPort?.Dispose();
        }
    }
}
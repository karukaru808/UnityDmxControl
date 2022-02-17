using UniRx;

namespace DmxControl
{
    public interface IDmxControlView
    {
        public string PortName { get; }
        public Subject<uint> OnChangeFps { get; }
        public Subject<byte[]> OnChangeDmxData { get; }
    }
}
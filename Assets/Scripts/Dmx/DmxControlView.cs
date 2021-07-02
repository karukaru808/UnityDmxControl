using UniRx;
using UnityEngine;

namespace Dmx
{
    public sealed class DmxControlView : MonoBehaviour, IDmxControlView
    {
        [SerializeField, Range(1, 60)] private uint fps = 30;
        [SerializeField] private string portName = "COM3";
        [SerializeField] private byte[] dmxData = new byte[513];

        public string PortName => portName;
        public Subject<uint> OnChangeFps { get; } = new Subject<uint>();
        public Subject<byte[]> OnChangeDmxData { get; } = new Subject<byte[]>();

        private void Start()
        {
            this.ObserveEveryValueChanged(view => view.fps).Subscribe(f => OnChangeFps.OnNext(f));
            this.ObserveEveryValueChanged(view => view.dmxData).Subscribe(data => OnChangeDmxData.OnNext(data));
        }

        private void OnDestroy()
        {
            OnChangeFps?.Dispose();
            OnChangeDmxData?.Dispose();
        }
    }
}
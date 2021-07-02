using System;
using UniRx;
using Zenject;

namespace Dmx
{
    public sealed class DmxControlPresenter : IInitializable, IDisposable
    {
        private readonly DmxControlModel _model;
        private readonly IDmxControlView _view;

        public DmxControlPresenter(DmxControlModel model, IDmxControlView view)
        {
            _model = model;
            _view = view;

            view.OnChangeFps.Subscribe(fps => model.FPS = fps);
            view.OnChangeDmxData.Subscribe(data => model.DmxData = data);
        }

        public void Initialize()
        {
            _model.OpenDmxPort(_view.PortName);
        }

        public void Dispose()
        {
            _model?.Dispose();
        }
    }
}
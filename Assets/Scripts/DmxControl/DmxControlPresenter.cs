using System;
using UniRx;
using Zenject;

namespace DmxControl
{
    public sealed class DmxControlPresenter : IInitializable, IDisposable
    {
        private readonly DmxControlModel _model;
        private readonly IDmxControlView _view;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public DmxControlPresenter(DmxControlModel model, IDmxControlView view)
        {
            _model = model;
            _view = view;

            _view.OnChangeFps.Subscribe(fps => model.FPS = fps).AddTo(_disposable);
            _view.OnChangeDmxData.Subscribe(data => model.DmxData = data).AddTo(_disposable);
        }

        public void Initialize()
        {
            _model.OpenDmxPort(_view.PortName);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}
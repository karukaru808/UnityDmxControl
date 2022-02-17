using DmxControl;
using UnityEngine;

namespace Zenject
{
    public sealed class DmxInstaller : MonoInstaller
    {
        [SerializeField] private GameObject dmxControlViewPrefab;

        public override void InstallBindings()
        {
            Container.Bind<IDmxControlView>().FromComponentInNewPrefab(dmxControlViewPrefab).AsSingle();
            Container.BindInterfacesAndSelfTo<DmxControlModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<DmxControlPresenter>().AsSingle();
        }
    }
}
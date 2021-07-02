using Dmx;
using UnityEngine;
using Zenject;

namespace CIFER.Tech.Scripts.Zenject
{
    public class DmxInstaller : MonoInstaller
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
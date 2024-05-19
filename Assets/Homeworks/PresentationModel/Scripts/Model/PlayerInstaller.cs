using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CharacterInfo>().AsSingle().NonLazy();
            Container.Bind<PlayerLevel>().AsSingle().NonLazy();
            Container.Bind<UserInfo>().AsSingle().NonLazy();

            var playerPopup = FindObjectOfType<PlayerPopup>();
            Container.BindInterfacesAndSelfTo<PlayerPopupAdapter>().AsSingle().WithArguments(playerPopup).NonLazy();
        }
    }
}
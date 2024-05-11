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
            Container.BindInterfacesAndSelfTo<UserInfoAdapter>().AsSingle().WithArguments(playerPopup).NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerPopupButtonsAdapter>().AsSingle().WithArguments(playerPopup).NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerLevelAdapter>().AsSingle().WithArguments(playerPopup).NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerStatsAdapter>().AsSingle().WithArguments(playerPopup).NonLazy();
        }
    }
}
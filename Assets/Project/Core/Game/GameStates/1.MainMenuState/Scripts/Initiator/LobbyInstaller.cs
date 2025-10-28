using Project.Core.Game.GameStates._1.MainMenuState.Scripts.Mvc;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.GameStates._1.MainMenuState.Scripts.Initiator {
    public class LobbyInstaller : MonoInstaller {
        [SerializeField] private LobbyCanvasView lobbyCanvasView;
        [SerializeField] private LobbyButtonView lobbyButtonView;
        
        public override void InstallBindings() {
            Container.Bind<ILobbyInitiator>().To<LobbyInitiator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<LobbyCanvasController>().AsSingle().WithArguments(lobbyCanvasView).NonLazy();
            Container.BindInterfacesTo<ILobbyButtonsController>().AsSingle().WithArguments(lobbyButtonView).NonLazy();
        }
    }
}
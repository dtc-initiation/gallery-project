using Project.Core.Game.GameStates._1.LobbyState.Scripts.Mvc;
using UnityEngine;
using Zenject;

namespace Project.Core.Game.GameStates._1.LobbyState.Scripts.Initiator {
    public class LobbyInstaller : MonoInstaller {
        [SerializeField] private LobbyCanvasView lobbyCanvasView;
        [SerializeField] private LobbyButtonView lobbyButtonView;
        
        public override void InstallBindings() {
            Container.Bind<ILobbyInitiator>().To<LobbyInitiator>().AsSingle().NonLazy();
            Container.Bind<ILobbyCanvasController>().To<LobbyCanvasController>().AsSingle().WithArguments(lobbyCanvasView).NonLazy();
            Container.BindInterfacesTo<LobbyButtonController>().AsSingle().WithArguments(lobbyButtonView).NonLazy();
        }
    }
}
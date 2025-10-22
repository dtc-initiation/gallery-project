using System.Collections.Generic;
using System.Threading;
using Project.Core.Scripts.Services.InitiatorService.Base;
using Project.Core.Scripts.Services.Logger.Base;
using Project.Core.Scripts.Services.SceneService.Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Project.Core.Scripts.Services.SceneService {
    public class SceneLoaderService : ISceneService {
        [Header("Scene Initiator Reference")]
        private ISceneInitiatorService _sceneInitiatorService;
        private ISceneDataCollection _sceneDataCollections;
        
        private readonly HashSet<string> _sceneGroupsLoaded = new();
        private readonly HashSet<string> _sceneGroupsLoading = new();
        private readonly HashSet<string> _scenesLoaded = new();
        private readonly HashSet<string> _scenesLoading = new();
        private Dictionary<string, SceneGroupData> _sceneGroupLookup;

        [Inject]
        public SceneLoaderService(ISceneInitiatorService sceneInitiatorService, ISceneDataCollection sceneDataCollection) {
            _sceneInitiatorService = sceneInitiatorService;
            _sceneDataCollections = sceneDataCollection;
        }
        
        public void InitializeService() {
            InitializeSceneGroupLookup();
        }

        private void InitializeSceneGroupLookup() {
            _sceneGroupLookup = new Dictionary<string, SceneGroupData>();
            var sceneList = _sceneDataCollections.SceneList;
            foreach (var sceneGroupData in sceneList) {
                _sceneGroupLookup.Add(sceneGroupData.sceneGroupName,  sceneGroupData);
            }
        }

        public async Awaitable<bool> TryLoadSceneGroup(string sceneGroupName, CancellationTokenSource cancellationTokenSource) {
            var isGroupAlreadyLoaded = _sceneGroupsLoaded.Contains(sceneGroupName);
            if (isGroupAlreadyLoaded) {
                LogService.LogError($"SceneGroup : {sceneGroupName} is already loaded");
                return false;
            }
            
            var isGroupAlreadyLoading = _sceneGroupsLoading.Contains(sceneGroupName);
            if (isGroupAlreadyLoading) {
                LogService.LogError($"SceneGroup : {sceneGroupName} is already loading");
                return false;
            }

            await LoadSceneGroup(sceneGroupName, cancellationTokenSource);
            return true;
        }

        
        private async Awaitable LoadSceneGroup(string sceneGroupName, CancellationTokenSource cancellationTokenSource) {
            _sceneGroupsLoading.Add(sceneGroupName);
            var groupToLoad = _sceneGroupLookup[sceneGroupName];

            foreach (var sceneData in groupToLoad.sceneList) {
                await TryLoadScene(sceneData.ScenePath, cancellationTokenSource);
                await _sceneInitiatorService.InvokeLoadEntryPoint(sceneData,  cancellationTokenSource);
            }
            _sceneGroupsLoaded.Add(sceneGroupName);
            _sceneGroupsLoading.Remove(sceneGroupName);
        }

        private async Awaitable<bool> TryLoadScene(string scenePath, CancellationTokenSource cancellationTokenSource) {
            var isSceneLoaded = _scenesLoaded.Contains(scenePath);
            if (isSceneLoaded) {
                LogService.LogError($"ScenePath : {scenePath} is already loaded");
                return false;
            }
            
            var isSceneLoading = _scenesLoading.Contains(scenePath);
            if (isSceneLoading) {
                LogService.LogError($"ScenePath : {scenePath} is already loading");
                return false;
            }
            await LoadScene(scenePath, cancellationTokenSource);
            return true;
        }

        private async Awaitable LoadScene(string scenePath, CancellationTokenSource cancellationTokenSource) {
            _scenesLoading.Add(scenePath);
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            await SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Additive);
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            _scenesLoading.Remove(scenePath);
            _scenesLoaded.Add(scenePath);
        }
        

        public async Awaitable StartSceneGroup(string sceneGroupName, CancellationTokenSource cancellationTokenSource) {
            foreach (var sceneData in _sceneGroupLookup[sceneGroupName].sceneList) {
                await _sceneInitiatorService.InvokeStartEntryPoint(sceneData, cancellationTokenSource);
            }
        }

        public async Awaitable<bool> TryUnloadSceneGroup(string sceneGroupName, CancellationTokenSource cancellationTokenSource) {
            var isSceneGroupUnloaded = _sceneGroupsLoaded.Contains(sceneGroupName);
            if (!isSceneGroupUnloaded) {
                LogService.LogError($"SceneGroup : {sceneGroupName} is already unloaded");
                return false;
            }
            var isSceneGroupUnLoading = _sceneGroupsLoading.Contains(sceneGroupName);
            if (!isSceneGroupUnLoading) {
                LogService.LogError($"SceneGroup : {sceneGroupName} is unloading");
                return false;
            }
            await UnLoadSceneGroup(sceneGroupName, cancellationTokenSource);
            return true;
        }

        private async Awaitable UnLoadSceneGroup(string sceneGroupName, CancellationTokenSource cancellationTokenSource) {
            var sceneGroupToUnload = _sceneGroupLookup[sceneGroupName];
            foreach (var sceneData in sceneGroupToUnload.sceneList) {
                await _sceneInitiatorService.InvokeUnloadExitPoint(sceneData, cancellationTokenSource);
                await TryUnloadScene(sceneData.ScenePath, cancellationTokenSource);
            }
        }

        private async Awaitable<bool> TryUnloadScene(string scenePath, CancellationTokenSource cancellationTokenSource) {
            var isSceneLoaded = _scenesLoaded.Contains(scenePath);
            if (!isSceneLoaded) {
                LogService.LogError($"ScenePath : {scenePath} is already unloaded");
                return false;
            }
            var isSceneUnLoading = _scenesLoading.Contains(scenePath);
            if (isSceneUnLoading) {
                LogService.LogError($"ScenePath : {scenePath} is unloading");
                return false;
            }
            await UnloadScene(scenePath, cancellationTokenSource);
            return true;
        }

        private async Awaitable UnloadScene(string scenePath, CancellationTokenSource cancellationTokenSource) {
            await SceneManager.UnloadSceneAsync(scenePath);
            _scenesLoaded.Remove(scenePath);
        }
        
    }
}
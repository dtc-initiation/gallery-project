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
        
        private readonly HashSet<SceneGroupType> _loadedSceneGroups = new();
        private readonly HashSet<SceneGroupType> _loadingSceneGroups = new();
        private readonly HashSet<string> _loadedScenes = new();
        private readonly HashSet<string> _loadingScenes = new();

        [Inject]
        public SceneLoaderService(ISceneInitiatorService sceneInitiatorService, SceneDataCollection sceneDataCollection) {
            _sceneInitiatorService = sceneInitiatorService;
            _sceneDataCollections = sceneDataCollection;
        }
        
        public void InitializeService() {
            AddOpenedScenesToLoadedHashSet();
        }

        private void AddOpenedScenesToLoadedHashSet() {
            var countLoaded = SceneManager.sceneCount;
            for (var i = 0; i < countLoaded; i++) {
                var scenePath = SceneManager.GetSceneAt(i).path;
                if (!_loadedScenes.Contains(scenePath)) {
                    _loadedScenes.Add(scenePath);
                }
            }
        }

        public async Awaitable<bool> TryLoadSceneGroup(SceneGroupType sceneGroupType, CancellationTokenSource cancellationTokenSource) {
            var isGroupAlreadyLoaded = _loadedSceneGroups.Contains(sceneGroupType);
            if (isGroupAlreadyLoaded) {
                LogService.LogError($"SceneGroup : {sceneGroupType} is already loaded");
                return false;
            }
            
            var isGroupAlreadyLoading = _loadingSceneGroups.Contains(sceneGroupType);
            if (isGroupAlreadyLoading) {
                LogService.LogError($"SceneGroup : {sceneGroupType} is already loading");
                return false;
            }

            await LoadSceneGroup(sceneGroupType, cancellationTokenSource);
            return true;
        }

        
        private async Awaitable LoadSceneGroup(SceneGroupType sceneGroupType, CancellationTokenSource cancellationTokenSource) {
            _loadingSceneGroups.Add(sceneGroupType);
            var groupToLoad = _sceneDataCollections.GetSceneGroupByType(sceneGroupType);
            foreach (var sceneData in groupToLoad.sceneList) {
                await TryLoadScene(sceneData.ScenePath, cancellationTokenSource);
                await _sceneInitiatorService.InvokeLoadEntryPoint(sceneData,  cancellationTokenSource);
            }
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(groupToLoad.activeSceneName));
            _loadedSceneGroups.Add(sceneGroupType);
            _loadingSceneGroups.Remove(sceneGroupType);
        }

        private async Awaitable<bool> TryLoadScene(string scenePath, CancellationTokenSource cancellationTokenSource) {
            var isSceneLoaded = _loadedScenes.Contains(scenePath);
            if (isSceneLoaded) {
                LogService.LogError($"ScenePath : {scenePath} is already loaded");
                return false;
            }
            
            var isSceneLoading = _loadingScenes.Contains(scenePath);
            if (isSceneLoading) {
                LogService.LogError($"ScenePath : {scenePath} is already loading");
                return false;
            }
            await LoadScene(scenePath, cancellationTokenSource);
            return true;
        }

        private async Awaitable LoadScene(string scenePath, CancellationTokenSource cancellationTokenSource) {
            _loadingScenes.Add(scenePath);
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            await SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Additive);
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            _loadingScenes.Remove(scenePath);
            _loadedScenes.Add(scenePath);
        }
        

        public async Awaitable StartSceneGroup(SceneGroupType sceneGroupType, CancellationTokenSource cancellationTokenSource) {
            var groupToStart = _sceneDataCollections.GetSceneGroupByType(sceneGroupType);
            foreach (var sceneData in groupToStart.sceneList) {
                await _sceneInitiatorService.InvokeStartEntryPoint(sceneData, cancellationTokenSource);
            }
        }

        public async Awaitable<bool> TryUnloadSceneGroup(SceneGroupType sceneGroupType, CancellationTokenSource cancellationTokenSource) {
            var isSceneGroupUnloaded = _loadedSceneGroups.Contains(sceneGroupType);
            if (!isSceneGroupUnloaded) {
                LogService.LogError($"SceneGroup : {sceneGroupType} is already unloaded");
                return false;
            }
            var isSceneGroupUnLoading = _loadingSceneGroups.Contains(sceneGroupType);
            if (isSceneGroupUnLoading) {
                LogService.LogError($"SceneGroup : {sceneGroupType} is unloading");
                return false;
            }
            await UnLoadSceneGroup(sceneGroupType, cancellationTokenSource);
            return true;
        }

        private async Awaitable UnLoadSceneGroup(SceneGroupType sceneGroupType, CancellationTokenSource cancellationTokenSource) {
            var sceneGroupToUnload = _sceneDataCollections.GetSceneGroupByType(sceneGroupType);
            foreach (var sceneData in sceneGroupToUnload.sceneList) {
                await _sceneInitiatorService.InvokeUnloadExitPoint(sceneData, cancellationTokenSource);
                await TryUnloadScene(sceneData.ScenePath, cancellationTokenSource);
            }
        }

        private async Awaitable<bool> TryUnloadScene(string scenePath, CancellationTokenSource cancellationTokenSource) {
            var isSceneLoaded = _loadedScenes.Contains(scenePath);
            if (!isSceneLoaded) {
                LogService.LogError($"ScenePath : {scenePath} is already unloaded");
                return false;
            }
            var isSceneUnLoading = _loadingScenes.Contains(scenePath);
            if (isSceneUnLoading) {
                LogService.LogError($"ScenePath : {scenePath} is unloading");
                return false;
            }
            await UnloadScene(scenePath, cancellationTokenSource);
            return true;
        }

        private async Awaitable UnloadScene(string scenePath, CancellationTokenSource cancellationTokenSource) {
            await SceneManager.UnloadSceneAsync(scenePath);
            _loadedScenes.Remove(scenePath);
        }
        
    }
}
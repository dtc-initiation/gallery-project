using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Project.Core.Scripts.Editor {
    [InitializeOnLoad]
    public static class DefaultSceneSelector {
        private const string DEFAULT_SCENE_FP_KEY = "DEFAULT_SCENE_FP_KEY";
        private const string OPENED_PROJECT_BEFORE_KEY = "OPENED_PROJECT_BEFORE_KEY";
        private const string CORE_SCENE_FP = "Assets/Project/Core/Assets/Scenes/CoreScene.unity";
        
        static DefaultSceneSelector() {
            EditorApplication.delayCall += OnLoad;
        }

        private static void OnLoad() {
            OpenCoreScene();
            SetCoreSceneAsDefault();
        }

        private static void OpenCoreScene() {
            var openedProjectBefore = EditorPrefs.HasKey(OPENED_PROJECT_BEFORE_KEY);
            if (openedProjectBefore) {
                return;
            }

            try {
                EditorSceneManager.OpenScene(CORE_SCENE_FP);
            } catch (Exception) {
                // ignored
            }

            EditorPrefs.SetBool(OPENED_PROJECT_BEFORE_KEY, true);
        }

        private static void SetCoreSceneAsDefault() {
            var path = EditorPrefs.GetString(DEFAULT_SCENE_FP_KEY, CORE_SCENE_FP);
            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(path);
            EditorSceneManager.playModeStartScene = sceneAsset;
        }
        
    }
}
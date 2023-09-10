using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.lex.katamari.util.scene
{
    public class SceneMgr : Singleton<SceneMgr>
    {

        private List<LevelLoadingData> _levelsLoading;
        private List<string> _currentlyLoadedScenes;

        public override void Awake()
        {
            base.Awake();
            _levelsLoading = new List<LevelLoadingData>();
            _currentlyLoadedScenes = new List<string>();
        }

        public void Update()
        {
            for (int i = _levelsLoading.Count - 1; i >= 0; i--)
            {
                if (_levelsLoading[i] == null)
                {
                    _levelsLoading.RemoveAt(i);
                    continue;
                }

                if (_levelsLoading[i].ao.isDone)
                {
                    _levelsLoading[i].ao.allowSceneActivation = true;
                    _levelsLoading[i].onLevelLoaded.Invoke(_levelsLoading[i].sceneName);
                    _currentlyLoadedScenes.Add(_levelsLoading[i].sceneName);
                    _levelsLoading.RemoveAt(i);
                }
            }
        }

        public void LoadLevel(string levelName, Action<string> onLevelLoaded, bool isShowingLoadingScreen = false)
        {
            bool value = _currentlyLoadedScenes.Any(x => x == levelName);

            if (value)
            {
                Debug.LogFormat("Current level ({0}) is already loaded into the game.", levelName);
                return;
            }

            LevelLoadingData lld = new LevelLoadingData();
            lld.ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
            lld.sceneName = levelName;
            lld.onLevelLoaded = onLevelLoaded;
            _levelsLoading.Add(lld);

            if (isShowingLoadingScreen)
            {
            }
        }

        public void UnLoadLevel(string levelName)
        {
            foreach (string item in _currentlyLoadedScenes)
            {
                if (item == levelName)
                {
                    SceneManager.UnloadSceneAsync(levelName);
                    _currentlyLoadedScenes.Remove(item);
                    return;
                }
            }

            Debug.LogErrorFormat("Failed to unload level ({0}), most likely was never loaded to begin with or was already unloaded.", levelName);
        }
    }

    [Serializable]
    public class LevelLoadingData
    {
        public AsyncOperation ao;
        public string sceneName;
        public Action<string> onLevelLoaded;
    }

    public static class SceneList
    {
        public const string MENU = "MenuScene";
        public const string GAME = "GameScene";
    }
}

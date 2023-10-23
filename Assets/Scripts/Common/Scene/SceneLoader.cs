using System;
using UnityEngine.SceneManagement;

namespace Match3Bonus
{
    public class SceneLoader
    {
        public void LoadScene(string sceneName, LoadSceneMode loadSceneMode, Action onSceneLoaded)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneName, loadSceneMode);
            
            void OnSceneLoaded(Scene loadedScene, LoadSceneMode loadSceneMode)
            {
                if (loadedScene.name != sceneName)
                {
                    return;
                }

                SceneManager.sceneLoaded -= OnSceneLoaded;
                onSceneLoaded?.Invoke();
            }
        }
    }
}
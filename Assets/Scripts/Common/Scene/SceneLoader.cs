using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Match3Bonus
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private LoadSceneMode _loadSceneMode;
        [SerializeField] private UnityEvent _onSceneLoaded;
        private AsyncOperation _loadOperation;

        public void PreloadScene(string sceneName)
        {
            _loadOperation = SceneManager.LoadSceneAsync(sceneName, _loadSceneMode);
            _loadOperation.completed += OnSceneLoaded;
            _loadOperation.allowSceneActivation = false;
        }

        public void ActivateLoadedScene()
        {
            if (_loadOperation != null)
            {
                _loadOperation.allowSceneActivation = true;
            }
        }

        private void OnSceneLoaded(AsyncOperation operation)
        {
            if (operation != _loadOperation)
            {
                return;
            }

            operation.completed -= OnSceneLoaded;
            _onSceneLoaded?.Invoke();
        }
    }
}

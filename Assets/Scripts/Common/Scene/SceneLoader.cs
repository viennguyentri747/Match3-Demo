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
        private bool _isActivateAsap = false;

        public void PreloadScene(string sceneName)
        {
            _loadOperation = SceneManager.LoadSceneAsync(sceneName, _loadSceneMode);
            _loadOperation.completed += OnSceneLoaded;
            _loadOperation.allowSceneActivation = _isActivateAsap;
        }

        public void SetSceneActivateASAP(bool isOn)
        {
            if (_loadOperation != null)
            {
                _loadOperation.allowSceneActivation = isOn;
            }

            _isActivateAsap = isOn;
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

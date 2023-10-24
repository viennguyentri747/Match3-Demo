using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Match3Bonus
{
    public class SceneUnloader : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onUnloadScene;
        private AsyncOperation _unloadOperation;

        public void UnloadScene(string sceneName)
        {
            _unloadOperation = SceneManager.UnloadSceneAsync(sceneName);
            _unloadOperation.completed += OnLoadComplete;
        }

        private void OnLoadComplete(AsyncOperation operation)
        {
            if (operation != _unloadOperation)
            {
                return;
            }

            _onUnloadScene?.Invoke();
        }
    }
}

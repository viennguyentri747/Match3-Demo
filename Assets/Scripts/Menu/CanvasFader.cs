using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class CanvasFader : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [Range(0, 1f)] [SerializeField] private float _startAlpha;
        [Range(0, 1f)] [SerializeField] private float _endAlpha;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private UnityEvent _onFadeComplete;

        public void StartFade()
        {
            StartCoroutine(UpdateFade());
        }

        private IEnumerator UpdateFade()
        {
            float progress = 0f;
            while (progress < _fadeDuration)
            {
                progress += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(_startAlpha, _endAlpha, progress / _fadeDuration);
                yield return null;
            }

            _onFadeComplete?.Invoke();
        }
    }
}

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

        private readonly CountdownRoutine _countDownRoutine = new();

        public void StartFade()
        {
            StartCoroutine(UpdateFade());
        }

        private IEnumerator UpdateFade()
        {
            yield return _countDownRoutine.RoutineCountdownInvoke(_fadeDuration, () => _onFadeComplete?.Invoke(),
                (countDownTime) =>
                {
                    float progress = _fadeDuration - countDownTime;
                    _canvasGroup.alpha = Mathf.Lerp(_startAlpha, _endAlpha, progress / _fadeDuration);
                });
        }
    }
}

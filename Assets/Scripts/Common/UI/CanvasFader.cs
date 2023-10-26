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
        [SerializeField] private UnityEvent _onRevertFadeComplete;

        private Coroutine _fadeCoroutine;
        private readonly CountDownRoutine _countDownRoutine = new();
        private bool _isReverting;

        public void StartFade()
        {
            StopCoroutineFade();
            _fadeCoroutine = StartCoroutine(UpdateFade(_startAlpha, _endAlpha));
            _isReverting = false;
        }

        public void StartRevertFade()
        {
            StopCoroutineFade();
            _fadeCoroutine = StartCoroutine(UpdateFade(_endAlpha, _startAlpha));
            _isReverting = true;
        }

        private void StopCoroutineFade()
        {
            if (_fadeCoroutine != null)
            {
                StopCoroutine(_fadeCoroutine);
            }
        }

        private IEnumerator UpdateFade(float startAlpha, float endAlpha)
        {
            yield return _countDownRoutine.RoutineCountdownInvoke(_fadeDuration,
                () =>
                {
                    if (_isReverting)
                    {
                        _onRevertFadeComplete?.Invoke();
                    }
                    else
                    {
                        _onFadeComplete?.Invoke();
                    }
                },
                (timeCountDown) =>
                {
                    float progress = (_fadeDuration - timeCountDown)/ _fadeDuration;
                    _canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);
                });


        }
    }
}

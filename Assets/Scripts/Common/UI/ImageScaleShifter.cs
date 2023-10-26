using System.Collections;
using UnityEngine;

namespace Match3Bonus
{
    public class RectScaleShifter : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Vector2 _scaleMin;
        [SerializeField] private Vector2 _scaleMax;
        [SerializeField] private float _scaleDuration;

        private CountDownRoutine _countDownRoutine = new();
        private Coroutine _coroutineShiftScale;

        public void StartShiftScale()
        {
            _coroutineShiftScale = StartCoroutine(RoutineShiftScale());
        }

        private IEnumerator RoutineShiftScale()
        {
            float scaleRange = (_scaleMax - _scaleMin).magnitude;
            float timeScaleUp = _scaleDuration * (_scaleMax.magnitude / scaleRange);
            float timeScaleDown = _scaleDuration - timeScaleUp;

            while (true)
            {
                Vector2 startScale = GetScale();
                yield return _countDownRoutine.RoutineCountdown(timeScaleUp,
                    timeCountDown => UpdateScale(startScale, _scaleMax, timeCountDown, timeScaleUp));

                startScale = GetScale();
                yield return _countDownRoutine.RoutineCountdown(timeScaleDown,
                    timeCountDown => UpdateScale(startScale, _scaleMin, timeCountDown, timeScaleDown));
            }
        }

        private Vector2 GetScale()
        {
            return _rectTransform.localScale;
        }

        private void SetScale(Vector2 newScale)
        {
            _rectTransform.localScale = newScale;
        }

        private void UpdateScale(Vector2 from, Vector2 to, float countDown, float scaleTime)
        {
            float progress = (scaleTime - countDown) / scaleTime;
            SetScale(Vector2.Lerp(from, to, progress));
        }
    }
}

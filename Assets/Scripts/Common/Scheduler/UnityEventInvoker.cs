using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class UnityEventInvoker : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onInvoke;
        [SerializeField] private float _delayFirstInvoke;
        [SerializeField] private bool _isRepeating;
        [SerializeField] private float _repeatInterval;

        private Coroutine _invokeRoutine;
        private float _countdownTimer;

        public void StartInvokeRoutine()
        {
            StopInvokeRoutine();
            ResetIntervalTimer();
            _invokeRoutine = StartCoroutine(RoutineInvokeInterval());
        }

        public void StopInvokeRoutine()
        {
            if (_invokeRoutine != null)
            {
                StopCoroutine(_invokeRoutine);
            }
        }

        private IEnumerator RoutineInvokeInterval()
        {
            yield return new WaitForSeconds(_delayFirstInvoke);

            Invoke();

            while (_isRepeating)
            {
                if (_countdownTimer <= 0)
                {
                    ResetIntervalTimer();
                    Invoke();
                }

                _countdownTimer -= Time.deltaTime;
                LogHelper.LogError(_countdownTimer);
                yield return null;
            }
        }

        public void ResetIntervalTimer()
        {
            _countdownTimer = _repeatInterval;
        }

        private void Invoke()
        {
            _onInvoke?.Invoke();
        }
    }
}

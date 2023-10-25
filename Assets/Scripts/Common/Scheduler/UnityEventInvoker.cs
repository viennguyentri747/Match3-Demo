using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class UnityEventInvoker : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onInvoke;
        [SerializeField] private UnityEvent<float> _onCountdownTimerUpdate;
        [SerializeField] private float _delayFirstInvoke;
        [SerializeField] private bool _isRepeating;
        [SerializeField] private float _repeatInterval;

        private Coroutine _invokeRoutine;
        private float _countdownTimer;

        private float CountdownTimer
        {
            set
            {
                _countdownTimer = value;
                _onCountdownTimerUpdate?.Invoke(value);
            }
            get => _countdownTimer;
        }

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
            CountdownTimer = _delayFirstInvoke;
            yield return UpdateTimerToInvoke();
            ResetIntervalTimer();

            while (_isRepeating)
            {
                yield return UpdateTimerToInvoke();
            }
        }

        private IEnumerator UpdateTimerToInvoke()
        {
            while (true)
            {
                if (CountdownTimer <= 0)
                {
                    ResetIntervalTimer();
                    Invoke();
                    yield break;
                }

                CountdownTimer -= Time.deltaTime;
                yield return null;
            }
        }

        public void ResetIntervalTimer()
        {
            CountdownTimer = _repeatInterval;
        }

        private void Invoke()
        {
            _onInvoke?.Invoke();
        }
    }
}

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

        private readonly CountdownRoutine _countDownRoutine = new();
        private Coroutine _coroutineInvoke;

        public void StartInvokeRoutine()
        {
            StopInvokeRoutine();
            ResetIntervalTimer();
            _coroutineInvoke = StartCoroutine(RoutineInvokeInterval());
        }

        private IEnumerator RoutineInvokeInterval()
        {
            _ = _delayFirstInvoke;
            yield return _countDownRoutine.RoutineCountdownInvoke(_delayFirstInvoke, Invoke, OnTimerUpdate);

            while (_isRepeating)
            {
                yield return _countDownRoutine.RoutineCountdownInvoke(_repeatInterval, Invoke, OnTimerUpdate);
            }
        }

        private void OnTimerUpdate(float countDownTime)
        {
            _onCountdownTimerUpdate?.Invoke(countDownTime);
        }

        public void StopInvokeRoutine()
        {
            if (_coroutineInvoke != null)
            {
                StopCoroutine(_coroutineInvoke);
            }
        }

        public void ResetIntervalTimer()
        {
            _countDownRoutine.ResetCountdown(_repeatInterval);
        }

        private void Invoke()
        {
            _onInvoke?.Invoke();
        }
    }
}

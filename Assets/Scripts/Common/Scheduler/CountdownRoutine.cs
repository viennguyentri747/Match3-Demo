using System;
using System.Collections;
using UnityEngine;

namespace Match3Bonus
{
    public class CountDownRoutine
    {
        private float _countDown;

        public IEnumerator RoutineCountdown(float time, Action<float> onTimerUpdate)
        {
            return RoutineCountdownInvoke(time, null, onTimerUpdate);
        }

        public IEnumerator RoutineCountdownInvoke(float delayBeforeInvoke, Action onInvoke = null,
            Action<float> onTimerUpdate = null)
        {
            _countDown = delayBeforeInvoke;
            while (true)
            {
                if (_countDown <= 0)
                {
                    onInvoke?.Invoke();
                    yield break;
                }

                _countDown -= Time.deltaTime;
                onTimerUpdate?.Invoke(_countDown);
                yield return null;
            }
        }

        public void ResetCountdown(float time)
        {
            _countDown = time;
        }
    }
}

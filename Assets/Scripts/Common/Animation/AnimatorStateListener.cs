using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class AnimatorStateListener : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private UnityEvent<string> _onStateEnter;

        private Coroutine _coroutineListen;

        public void StartListenOnEnter(string stateToListen)
        {
            StopListen();
            if (!IsSameState(stateToListen))
            {
                _coroutineListen = StartCoroutine(RoutineListen(stateToListen));
            }
        }

        private IEnumerator RoutineListen(string stateToListen)
        {
            while (true)
            {
                if (IsSameState(stateToListen))
                {
                    _onStateEnter?.Invoke(stateToListen);
                    yield break;
                }

                yield return null;
            }
        }

        private bool IsSameState(string stateName)
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
        }

        public void StopListen()
        {
            if (_coroutineListen != null)
            {
                StopCoroutine(_coroutineListen);
            }
        }
    }
}

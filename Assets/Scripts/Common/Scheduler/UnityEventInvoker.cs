using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class UnityEventInvoker : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onInvoke;
        [SerializeField] private bool _isRepeating;
        [SerializeField] private float _repeatInterval;
        [SerializeField] private float _delay;
    }
}

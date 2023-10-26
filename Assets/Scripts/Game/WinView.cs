using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class WinView : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onStart;

        public void Start()
        {
            _onStart?.Invoke();
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class TokenButtonView : ButtonView<int>
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private UnityEvent _onLock;
        [SerializeField] private UnityEvent _onUnlock;
        [SerializeField] private UnityEvent _onReveal;
        private bool _isLock;
        private bool _isReveal;
        public bool IsLock => _isLock;
        public bool IsReveal => _isReveal;

        protected override void OnSetup(int index)
        {
        }

        public void UnlockAndHide()
        {
            Unlock();
            Hide();
        }

        private void Hide()
        {
            _isReveal = false;
        }

        public void Reveal(PrizeElement prizeElement)
        {
            _animator.runtimeAnimatorController = prizeElement.TokenAsset.AnimOverrideController;
            _isReveal = true;
            _onReveal?.Invoke();
        }

        public void Lock()
        {
            _isLock = true;
            _onLock?.Invoke();
        }

        public void Unlock()
        {
            _isLock = false;
            _onUnlock?.Invoke();
        }
    }
}

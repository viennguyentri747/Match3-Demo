using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class TokenButtonView : ButtonView<TokenButtonView>
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private UnityEvent _onReveal;

        protected override void OnSetup(TokenButtonView tokenButtonView)
        {
        }

        public void Reveal(PrizeElement prizeElement)
        {
            _animator.runtimeAnimatorController = prizeElement.TokenAsset.AnimOverrideController;
            _onReveal?.Invoke();
        }
    }
}

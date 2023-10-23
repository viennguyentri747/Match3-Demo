using UnityEngine;

namespace Match3Bonus
{
    public class OverridableAnimComp : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void SetAnimController(AnimatorOverrideController overrideController)
        {
            _animator.runtimeAnimatorController = overrideController;
        }

        public void Trigger(string triggerParam)
        {
            _animator.SetTrigger(triggerParam);
        }
    }
}
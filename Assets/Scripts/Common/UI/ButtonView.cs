using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Match3Bonus
{
    public abstract class ButtonView<T> : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private UnityEvent<T> _onClick;
        private T _data;

        public void Setup(T data)
        {
            _data = data;
            OnSetup(data);
        }

        protected abstract void OnSetup(T data);

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _onClick?.Invoke(_data);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Match3Bonus
{
    public class MenuBtnComp : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private Button _button;
        private Action _onClick;

        public void SetData(string buttonText, Action onClick)
        {
            _onClick = onClick;
            _text.text = buttonText;
            SetBtnEnable(true);
        }

        public void SetBtnEnable(bool isEnable)
        {
            _button.enabled = isEnable;
        }

        public void OnClick()
        {
            _onClick?.Invoke();
        }

        private void OnDestroy()
        {
            _onClick = null;
        }
    }
}
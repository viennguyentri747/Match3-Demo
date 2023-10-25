using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Match3Bonus
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Text _timerTxt;
        [SerializeField] private bool _isCapTimeShow;
        [SerializeField] private FloatRange _rangeTimeShow;
        [SerializeField] private UnityEvent _onShow;
        [SerializeField] private UnityEvent _onHide;

        private float _currentTime;
        private bool _isShowing;

        private void Start()
        {
            Hide();
        }

        public void SetTime(float time)
        {
            _currentTime = time;
            CheckShowHide();
            UpdateTimeView();
        }

        private void CheckShowHide()
        {
            bool isShow = !_isCapTimeShow || _currentTime.IsIn(_rangeTimeShow);

            if (isShow && !_isShowing)
            {
                Show();
            }
            else if (!isShow && _isShowing)
            {
                Hide();
            }
        }

        private void UpdateTimeView()
        {
            _timerTxt.text = ((int)_currentTime).ToString();
        }

        private void Show()
        {
            _isShowing = true;
            _onShow?.Invoke();
        }

        private void Hide()
        {
            _isShowing = false;
            _onHide?.Invoke();
        }
    }

    [Serializable]
    public class FloatRange
    {
        [SerializeField] private float _min;
        public float Min => _min;
        [SerializeField] private float _max;
        public float Max => _max;
    }
}

using UnityEngine;

namespace Match3Bonus
{
    public class WindowResizer : MonoBehaviour
    {
        [SerializeField] private float _widthHeightAspect;
        [SerializeField] private float _delayUpdateSize;

        private readonly CountDownRoutine _routineCountdown = new();
        private Coroutine _coroutineResize;
        private int _previousScreenWidth;
        private int _previousScreenHeight;
        private bool _isJustResize = true;

        void OnEnable()
        {
            Resize(Screen.width, Screen.height);
        }

        private void Update()
        {
            bool isWidthChange = _previousScreenWidth != Screen.width;
            if (isWidthChange || _previousScreenHeight != Screen.height)
            {
                if (_coroutineResize != null)
                {
                    StopCoroutine(_coroutineResize);
                }

                StartCoroutine(_routineCountdown.RoutineCountdownInvoke(_delayUpdateSize,
                    () => { Resize(Screen.width, Screen.height, isWidthChange); }));
            }
        }

        private void Resize(float desireWidth, float desireHeight, bool isResizeByWidth = true)
        {
            if (isResizeByWidth)
            {
                int monitorWidth = Screen.currentResolution.width;
                float targetWidth = Mathf.Min(monitorWidth, desireWidth);
                SetResolution(targetWidth, targetWidth / _widthHeightAspect);
            }
            else
            {
                int monitorHeight = Screen.currentResolution.height;
                float targetHeight = Mathf.Min(monitorHeight, desireHeight);
                SetResolution(targetHeight * _widthHeightAspect, targetHeight);
            }
        }

        private void SetResolution(float width, float height)
        {
            int newWidth = Mathf.RoundToInt(width);
            int newHeight = Mathf.RoundToInt(height);

            Screen.SetResolution(newWidth, newHeight, Screen.fullScreen);

            _previousScreenWidth = newWidth;
            _previousScreenHeight = newHeight;

            _isJustResize = true;
        }
    }
}

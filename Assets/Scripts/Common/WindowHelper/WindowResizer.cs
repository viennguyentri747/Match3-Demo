using UnityEngine;

namespace Match3Bonus
{
    public class WindowResizer : MonoBehaviour
    {
        [SerializeField] private float _widthHeightRatio;
        [SerializeField] private float _scaleVsMonitor;

        private readonly CountDownRoutine _routineCountdown = new();
        private Coroutine _coroutineResize;

        void OnEnable()
        {
            Resize(Screen.width, Screen.height);
        }

        private void Resize(float desireWidth, float desireHeight, bool isResizeByWidth = true)
        {
            float resultWidth;
            float resultHeight;

            //Match width height with aspect ratio
            if (isResizeByWidth)
            {
                resultWidth = desireWidth;
                resultHeight = resultWidth / _widthHeightRatio;
            }
            else
            {
                resultHeight = desireHeight;
                resultWidth = resultHeight * _widthHeightRatio;
            }

            //Resize vs monitor
            float maxWidth = Screen.currentResolution.width * _scaleVsMonitor;
            float maxHeight = Screen.currentResolution.height * _scaleVsMonitor;
            bool isNeedResizeVsMonitor = resultWidth > maxWidth || resultHeight > maxHeight;
            if (isNeedResizeVsMonitor)
            {
                float scaleDownRatio = 1 / Mathf.Max(resultWidth / maxWidth, resultHeight / maxHeight);
                resultWidth *= scaleDownRatio;
                resultHeight *= scaleDownRatio;
            }

            SetResolution(resultWidth, resultHeight);
        }

        private void SetResolution(float width, float height)
        {
            int newWidth = Mathf.RoundToInt(width);
            int newHeight = Mathf.RoundToInt(height);

            Screen.SetResolution(newWidth, newHeight, Screen.fullScreen);
        }
    }
}

using UnityEngine;

namespace Match3Bonus
{
    public class WindowResizer : MonoBehaviour
    {
        [SerializeField] private float _widthHeightRatio;
        [SerializeField] private float _scaleVsMonitor;

        void OnEnable()
        {
            Resize(Screen.width, Screen.height);
        }

        private void Resize(float currentWidth, float currentHeight)
        {
            float resultWidth;
            float resultHeight;

            //Resize down to match aspect ratio
            bool isResizeDownByWidth = (currentWidth / currentHeight) < _widthHeightRatio;
            if (isResizeDownByWidth)
            {
                resultWidth = currentWidth;
                resultHeight = resultWidth / _widthHeightRatio;
            }
            else
            {
                resultHeight = currentHeight;
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
            Screen.SetResolution(width.ToInt(), height.ToInt(), Screen.fullScreen);
        }
    }
}

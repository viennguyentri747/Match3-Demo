using UnityEngine;
using UnityEngine.UI;

namespace Match3Bonus
{
    public class SafeArea : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CanvasScaler _canvasScaler;

        private void Start()
        {
            ApplySafeArea();
        }

        private void ApplySafeArea()
        {
            float bottomPixels = Screen.safeArea.y;
            float topPixels = Screen.currentResolution.height - (Screen.safeArea.y + Screen.safeArea.height);

            float bottomRatio = bottomPixels / Screen.currentResolution.height;
            float topRatio = topPixels / Screen.currentResolution.height;

            Vector2 refResolution = _canvasScaler.referenceResolution;
            float bottomSize = refResolution.y * bottomRatio;
            float topSize = refResolution.y * topRatio;

            _rectTransform.offsetMin = new Vector2(_rectTransform.offsetMin.x, bottomSize);
            _rectTransform.offsetMax = new Vector2(_rectTransform.offsetMax.x, -topSize);
        }
    }
}

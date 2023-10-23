using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private MenuButtonView _btnViewTemplate;
        private readonly List<MenuButtonView> _cacheBtns = new();
        [SerializeField] private UnityEvent _onShowButtons;

        public void ShowButtons(List<SOPrize> prizes)
        {
            _btnViewTemplate.ShowCachedViews(prizes, _cacheBtns,
                (btnComp, prize) => { btnComp.Setup(prize); });
            _onShowButtons?.Invoke();
        }
    }
}

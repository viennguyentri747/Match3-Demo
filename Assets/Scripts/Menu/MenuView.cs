using System;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Bonus
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private MenuBtnView _btnViewTemplate;
        [SerializeField] private List<MenuBtnView> _cacheBtns;

        public void ShowButtons(List<SOPrize> prizes, Action<SOPrize> onClick)
        {
            _btnViewTemplate.ShowCachedViews(prizes, _cacheBtns,
                (btnComp, prize) =>
                {
                    btnComp.Setup(prize.Name, () => { onClick?.Invoke(prize); });
                    btnComp.SetBtnEnable(true);
                });
        }

        public void LockButtons()
        {
            foreach (MenuBtnView btnComp in _cacheBtns)
            {
                btnComp.SetBtnEnable(false);
            }
        }
    }
}
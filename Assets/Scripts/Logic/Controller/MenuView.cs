using System;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Bonus
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private MenuBtnComp _btnTemplate;
        [SerializeField] private List<MenuBtnComp> _cacheBtnComps;

        public void ShowButtons(List<SOPrize> prizes, Action<SOPrize> onClick)
        {
            _btnTemplate.ShowCachedViews(prizes, _cacheBtnComps,
                (btnComp, prize) =>
                {
                    btnComp.Set(prize.Name, () => { onClick?.Invoke(prize); });
                    btnComp.SetBtnEnable(true);
                });
        }

        public void LockButtons()
        {
            foreach (MenuBtnComp btnComp in _cacheBtnComps)
            {
                btnComp.SetBtnEnable(false);
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Match3Bonus
{
    public class MenuButtonView : ButtonView<SOPrize>
    {
        [SerializeField] private Text _text;

        protected override void OnSetup(SOPrize prize)
        {
            _text.text = prize.Name;
        }
    }
}

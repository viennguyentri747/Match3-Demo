using System.Collections.Generic;
using UnityEngine;

namespace Match3Bonus
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TokenButtonView _tokenButtonTemplate;
        private readonly List<TokenButtonView> _cacheTokens = new();
        private Queue<PrizeElement> _prizes = new();

        public void ShowTokens(Queue<PrizeElement> prizes)
        {
            _prizes = prizes;
            _tokenButtonTemplate.ShowCachedViews(prizes, _cacheTokens, (view, prize) => { view.Setup(view); });
        }

        public void RevealRandomToken()
        {
            if (_cacheTokens.IsNullOrEmpty())
            {
                return;
            }

            TokenButtonView tokenButtonView = _cacheTokens.GetRandomElement();
            RevealNextPrizeFor(tokenButtonView);
        }

        public void RevealNextPrizeFor(TokenButtonView view)
        {
            if (_prizes.IsNullOrEmpty())
            {
                return;
            }

            PrizeElement nextPrize = _prizes.Dequeue();
            view.Reveal(nextPrize);
        }
    }
}

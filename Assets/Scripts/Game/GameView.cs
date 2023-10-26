using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3Bonus
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TokenButtonView _tokenTemplate;

        private readonly List<TokenButtonView> _cacheTokens = new();
        private readonly List<TokenButtonView> _tempLockTokens = new();
        private TokenButtonView _selectToken;
        private readonly Dictionary<TokenButtonView, PrizeElement> _revealedTokens = new();

        public void ShowTokens(PrizeQueueData prizeQueueData)
        {
            _tokenTemplate.ShowCachedViews(prizeQueueData.PrizeQueue.Count, _cacheTokens,
                (view, index) => { view.Setup(index); });
        }

        public void SetSelectedToken(TokenButtonView selectToken)
        {
            _selectToken = selectToken;
        }

        public void UnSelectToken()
        {
            _selectToken = null;
        }

        public void RevealSelectedOrRandomToken(PrizeElement prize)
        {
            TokenButtonView token = IsValidToReveal(_selectToken)
                ? _selectToken
                : _cacheTokens.Where(IsValidToReveal).ToList().GetRandomElementOrDefault();

            if (token == null)
            {
                LogHelper.LogError("No token to reveal");
                return;
            }

            token.Reveal(prize);
            _revealedTokens[token] = prize;
        }

        public void RevealAuto(PrizeElement prize)
        {
            TokenButtonView token = _cacheTokens.FirstOrDefault(view => view != null && !view.IsReveal);
            if (token == null)
            {
                return;
            }

            token.Reveal(prize, true);
            _revealedTokens[token] = prize;
        }

        public void LockUnRevealedTokensTemporary()
        {
            LockTokens(IsValidToReveal, view => _tempLockTokens.Add(view));
        }

        private bool IsValidToReveal(TokenButtonView token)
        {
            return token != null && !token.IsReveal && !token.IsLock;
        }

        private void LockTokens(Func<TokenButtonView, bool> checkLock, Action<TokenButtonView> onLock)
        {
            foreach (TokenButtonView view in _cacheTokens)
            {
                if (checkLock != null && !checkLock.Invoke(view))
                {
                    continue;
                }

                view.Lock();
                onLock?.Invoke(view);
            }
        }

        public void UnlockTemporaryLockedTokens()
        {
            foreach (TokenButtonView view in _tempLockTokens)
            {
                view.Unlock();
            }

            ClearTempLockTokens();
        }

        private void ClearTempLockTokens()
        {
            _tempLockTokens.Clear();
        }

        public void HighlightMatchedPrizes()
        {
            foreach (KeyValuePair<TokenButtonView, PrizeElement> kvp in _revealedTokens)
            {
                PrizeElement prize = kvp.Value;
                if (!prize.IsMatched)
                {
                    continue;
                }

                TokenButtonView token = kvp.Key;
                token.HighLight();
            }
        }
    }
}

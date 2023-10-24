using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TokenButtonView _tokenTemplate;

        private readonly List<TokenButtonView> _cacheTokens = new();
        private readonly List<TokenButtonView> _tempLockTokens = new();
        private TokenButtonView _selectToken;

        public void ShowTokens(PrizeQueueData prizeQueueData)
        {
            _tempLockTokens.Clear();
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
            TokenButtonView token = _selectToken != null ? _selectToken : _cacheTokens.FirstOrDefault(token => !token.IsReveal);
            if (token == null)
            {
                LogHelper.LogError("No token to reveal");
                return;
            }

            token.Reveal(prize);
        }
        
        public void LockTokensTemporary()
        {
            LockTokens(view => _tempLockTokens.Add(view));
        }

        public void LockTokens()
        {
            LockTokens(null);
        }

        private void LockTokens(Action<TokenButtonView> onLock)
        {
            foreach (TokenButtonView view in _cacheTokens)
            {
                if (view.IsLock)
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
        }
    }
}

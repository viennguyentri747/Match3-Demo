using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class GameController : MonoListener<PrizeQueueData>
    {
        [SerializeField] private GameView _gameView;
        [SerializeField] private UnityEvent _onEnable;
        [SerializeField] private UnityEvent _onWin;

        private PrizeElement _lastMatchedPrize;

        private void OnEnable()
        {
            _onEnable?.Invoke();
            ListenerHub.RegisterListener(this);
        }

        private void OnDisable()
        {
            ListenerHub.UnRegisterListener(this);
        }

        protected override void OnReceiveData(PrizeQueueData data)
        {
            Queue<PrizeElement> queue = data.PrizeQueue;
            _lastMatchedPrize = queue.LastOrDefault(element => element.IsMatched == true);
            _gameView.ShowTokens(queue);
        }

        public void OnPrizeRevealed(PrizeElement prizeElement)
        {
            if (prizeElement != _lastMatchedPrize)
            {
                return;
            }

            _onWin?.Invoke();
        }
    }

    public class PrizeQueueData : IDataToListen
    {
        public Queue<PrizeElement> PrizeQueue { get; }

        public PrizeQueueData(Queue<PrizeElement> prizeQueue)
        {
            PrizeQueue = prizeQueue;
        }
    }
}

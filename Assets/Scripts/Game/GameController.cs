using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class GameController : MonoListener<PrizeQueueData>
    {
        [SerializeField] private GameView _gameView;
        [SerializeField] private UnityEvent _onEnable;

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
            _gameView.ShowTokens(queue);
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

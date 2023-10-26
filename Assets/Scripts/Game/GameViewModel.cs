using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class GameViewModel : MonoListener<PrizeQueueData>
    {
        [SerializeField] private UnityEvent _onEnable;
        [SerializeField] private UnityEvent<PrizeQueueData> _onDataReady;
        [SerializeField] private UnityEvent<PrizeElement> _onRevealNextPrize;
        [SerializeField] private UnityEvent<PrizeElement> _onRevealAuto;
        [SerializeField] private UnityEvent _onWin;
        [SerializeField] private UnityEvent _onEnd;

        private Queue<PrizeElement> _prizes;
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
            _prizes = data.PrizeQueue;
            _lastMatchedPrize = _prizes.LastOrDefault(element => element.IsMatched);
            _onDataReady?.Invoke(data);
        }

        public void RevealRemainPrizesAuto()
        {
            while (!_prizes.IsNullOrEmpty())
            {
                PrizeElement nextPrize = _prizes.Dequeue();
                _onRevealAuto?.Invoke(nextPrize);
            }
        }

        public void RevealNextPrize()
        {
            if (_prizes.IsNullOrEmpty())
            {
                LogHelper.LogError("No prize to reveal");
                return;
            }

            PrizeElement nextPrize = _prizes.Dequeue();
            _onRevealNextPrize?.Invoke(nextPrize);
        }

        public void CheckWin(PrizeElement prize)
        {
            if (prize == _lastMatchedPrize)
            {
                _onWin?.Invoke();
            }
        }

        public void End()
        {
            _onEnd?.Invoke();
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

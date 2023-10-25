using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class MenuViewModel : MonoBehaviour
    {
        [SerializeField] private List<SOPrize> _prizes;
        [SerializeField] private UnityEvent<List<SOPrize>> _onDataReady;
        [SerializeField] private UnityEvent<SOPrize> _onPrizeSelected;

        private readonly IPrizesShuffler<SelectPrizePack> _prizesShuffler = new PrizesShufflerMatchSelected();
        private SOPrize _selectedPrize;

        public void Start()
        {
            _onDataReady?.Invoke(_prizes);
        }

        public void OnSelectPrize(SOPrize selectedPrize)
        {
            _selectedPrize = selectedPrize;
            _onPrizeSelected?.Invoke(selectedPrize);
        }

        public void SendShuffledPrizeData()
        {
            PrizeQueueData queueData = GetShuffledPrizeQueueData();
            List<IListener> listeners = ListenerHub.FindListeners<PrizeQueueData>();
            foreach (IListener listener in listeners)
            {
                listener.ReceiveData(queueData);
            }
        }

        private PrizeQueueData GetShuffledPrizeQueueData()
        {
            SelectPrizePack selectPrizePack = new(_selectedPrize, _prizes);
            Queue<PrizeElement> shuffledPrizes = _prizesShuffler.GenerateShuffledPrizes(selectPrizePack);

            LogHelper.Log($@"Shuffled Queue: {string.Join(",", shuffledPrizes.Select(prize =>
            {
                string logStr = prize.IsMatched ? $"<color=red>{prize.Name}</color>" : prize.Name;
                return logStr;
            }))}");

            return new PrizeQueueData(shuffledPrizes);
        }
    }
}

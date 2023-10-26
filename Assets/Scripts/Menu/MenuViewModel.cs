using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Match3Bonus
{
    public class MenuViewModel : MonoBehaviour
    {
        [SerializeField] private List<SOPrize> _prizes;
        [SerializeField] private UnityEvent _onStart;
        [SerializeField] private UnityEvent<List<SOPrize>> _onDataReady;
        [SerializeField] private UnityEvent<SOPrize> _onPrizeSelected;

        private readonly IPrizesShuffler<SelectPrizePack> _prizesShuffler = new PrizesShufflerMatchSelected();
        private SOPrize _selectedPrize;

        public void Start()
        {
            _onStart?.Invoke();
            LogHelper.LogEnumerable("Prizes", _prizes, prize => prize.Name);
            _onDataReady?.Invoke(_prizes);
        }

        public void OnSelectPrize(SOPrize selectedPrize)
        {
            _selectedPrize = selectedPrize;
            _onPrizeSelected?.Invoke(selectedPrize);
            LogHelper.Log($"Select prize in Menu", selectedPrize.Name);
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

            LogHelper.LogEnumerable("Shuffled Queue", shuffledPrizes, element =>
            {
                string logStr = element.IsMatched ? element.Name.ToStringWith(Color.magenta) : element.Name;
                return logStr;
            });

            return new PrizeQueueData(shuffledPrizes);
        }
    }
}

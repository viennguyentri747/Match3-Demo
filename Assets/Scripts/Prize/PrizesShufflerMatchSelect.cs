using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3Bonus
{
    public class PrizesShufflerMatchSelected : IPrizesShuffler<SelectPrizePack>
    {
        public Queue<PrizeElement> GenerateShuffledPrizes(SelectPrizePack pack)
        {
            Queue<PrizeElement> queue = new();
            int totalPrizes = pack.Prizes.Sum(prizeData => prizeData.TotalCount);
            Dictionary<SOPrize, int> prizesRemainDict =
                pack.Prizes.ToDictionary(prize => prize, prize => prize.TotalCount);
            bool isMatchSelected = pack.SelectedPrize.TotalCount == 0;
            for (int i = 0; i < totalPrizes; i++)
            {
                SOPrize prizeChoice = GetRandomPrize(prizesRemainDict, isMatchSelected, pack.SelectedPrize);
                PrizeElement prizeElement = new(prizeChoice.Name, prizeChoice == pack.SelectedPrize,
                    prizeChoice.TokenAsset, prizeChoice.Reward);
                queue.Enqueue(prizeElement);
                int remainPrizes = --prizesRemainDict[prizeChoice];
                if (!isMatchSelected && remainPrizes == 0)
                {
                    isMatchSelected = true;
                }
            }

            return queue;
        }

        private SOPrize GetRandomPrize(Dictionary<SOPrize, int> remainDict, bool isMatchSelected,
            SOPrize selected)
        {
            List<SOPrize> choices = remainDict.Where(kvp =>
            {
                int remain = kvp.Value;
                SOPrize currentPrize = kvp.Key;
                return remain > 0 && !(remain == 1 && !isMatchSelected && currentPrize != selected);
            }).Select(kvp => kvp.Key).ToList();
            
            int randomIndex = Random.Range(0, choices.Count);
            return choices[randomIndex];
        }
    }

    public class SelectPrizePack : PrizePack
    {
        public SOPrize SelectedPrize { get; }

        public SelectPrizePack(SOPrize selectedPrize, List<SOPrize> prizes) : base(prizes)
        {
            SelectedPrize = selectedPrize;
        }
    }
}
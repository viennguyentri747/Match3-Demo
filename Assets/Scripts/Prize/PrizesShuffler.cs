using System.Collections.Generic;

namespace Match3Bonus
{
    public interface IPrizesShuffler<in T> where T : PrizePack
    {
        public Queue<PrizeElement> GenerateShuffledPrizes(T pack);
    }

    public class PrizePack
    {
        public List<SOPrize> Prizes { get; }

        protected PrizePack(List<SOPrize> prizes)
        {
            Prizes = prizes;
        }
    }
}

namespace Match3Bonus
{
    public class PrizeElement
    {
        public string Name { get; }
        public bool IsMatched { get; }
        public int Reward { get; }
        public TokenAsset TokenAsset { get; }

        public PrizeElement(string name, bool isMatched, TokenAsset tokenAsset, int reward)
        {
            Name = name;
            IsMatched = isMatched;
            TokenAsset = tokenAsset;
            Reward = reward;
        }
    }
}
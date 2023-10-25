using System;
using UnityEngine;

namespace Match3Bonus
{
    [CreateAssetMenu(fileName = nameof(SOPrize), menuName = "Data/" + nameof(SOPrize))]
    public class SOPrize : CustomSO
    {
        [SerializeField] private string _name;
        [SerializeField] private int _reward;
        [SerializeField] private int _totalCount;
        [SerializeField] private TokenAsset _tokenAsset;

        public string Name => _name;
        public int Reward => _reward;
        public int TotalCount => _totalCount;
        public TokenAsset TokenAsset => _tokenAsset;
    }

    [Serializable]
    public class TokenAsset
    {
        [SerializeField] private AnimatorOverrideController _animOverrideController;
        public AnimatorOverrideController AnimOverrideController => _animOverrideController;
    }
}

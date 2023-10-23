using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Match3Bonus
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private List<SOPrize> _prizes;
        [SerializeField] private string _gameScene;
        [SerializeField] private MenuView _view;
         
        private Queue<PrizeElement> _shuffledPrizes = new();
        private readonly IPrizesShuffler<SelectPrizePack> _prizesShuffler = new PrizesShufflerMatchSelected();
        private readonly SceneLoader _sceneLoader = new();

        private void Start()
        {
            _view.ShowButtons(_prizes, OnClickButtonPrize);
        }
        
        private void OnClickButtonPrize(SOPrize selectedPrize)
        {
            _view.LockButtons();
            CreateShuffledPrizes(selectedPrize);
            _sceneLoader.LoadScene(_gameScene, LoadSceneMode.Single, OnGameSceneLoaded);
        }

        private void CreateShuffledPrizes(SOPrize selectedPrize)
        {
            SelectPrizePack selectPrizePack = new(selectedPrize, _prizes);
            _shuffledPrizes = _prizesShuffler.GenerateShuffledPrizes(selectPrizePack);
            LogHelper.Log($@"Shuffled Queue: {string.Join(",", _shuffledPrizes.Select(prize =>
            {
                string logStr = prize.IsMatched ? $"<color=red>{prize.Name}</color>" : prize.Name;
                return logStr;
            }))}");
        }

        private void OnGameSceneLoaded()
        {
           //TODO: send shuffled prizes
        }
    }
}
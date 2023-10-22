using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Match3Bonus
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private List<SOPrize> _prizes;
        [SerializeField] private MenuBtnComp _btnTemplate;
        [SerializeField] private List<MenuBtnComp> _cacheBtnComps;
        [SerializeField] private string _gameScene;

        private Queue<PrizeElement> _shuffledPrizes = new Queue<PrizeElement>();
        private readonly IPrizesShuffler<SelectPrizePack> _prizesShuffler = new PrizesShufflerMatchSelected();
        private SceneLoader _sceneLoader = new();

        private void Start()
        {
            ShowButtons();
        }

        private void ShowButtons()
        {
            _btnTemplate.ShowCachedViews(_prizes, _cacheBtnComps,
                (btnComp, prize) => { btnComp.SetData(prize.Name, () => { OnClickButtonPrize(prize); }); });
        }

        private void OnClickButtonPrize(SOPrize selectedPrize)
        {
            LockButtons();
            CreateShuffledPrizes(selectedPrize);
            _sceneLoader.LoadScene(_gameScene, LoadSceneMode.Single, OnGameSceneLoaded);
        }

        private void LockButtons()
        {
            foreach (MenuBtnComp btnComp in _cacheBtnComps)
            {
                btnComp.SetBtnEnable(false);
            }
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
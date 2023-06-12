using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Source.UISystem
{
    public class GameUIController
    {
        private readonly GameUIView _view;

        private int _score;
        
        public GameUIController(GameUIView view, Button resetButton)
        {
            _view = view;
            resetButton.onClick.AddListener(Reset);
        }

        private void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void GameEnd()
        {
            _view.End();
        }

        public void ScoreUpdate(int addScore)
        {
            _score += addScore;
            _view.Score(_score);
        }

        public void UpdateBallCount(int count)
        {
            _view.BallCount(count);
        }
    }
}
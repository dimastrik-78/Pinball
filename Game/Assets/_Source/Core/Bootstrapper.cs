using _Source.BonusSystem;
using _Source.GameSystem;
using _Source.UISystem;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameUIView view;
        [SerializeField] private Button resetButton;
        [SerializeField] private Bonus[] bonusArray;
        [SerializeField] private BallFalling ballFalling;
        [SerializeField] private GameObject prefBall;
        [SerializeField] private Transform startBallPoint;
        [SerializeField] private int countBall;

        private Game _game;
        private BallPool _ballPool;
        private GameUIController _controller;
        
        private void Awake()
        {
            _ballPool = new BallPool(prefBall);
            _ballPool.InitObject(countBall);
            
            _game = new Game(startBallPoint, _ballPool);

            _controller = new GameUIController(view, resetButton);

            ballFalling.OnBallFall += _game.MoveBall;
            _game.OnEndGame += _controller.GameEnd;
            _game.ChangeBallCount += _controller.UpdateBallCount;

            foreach (var array in bonusArray)
            {
                array.OnCollisionWithBall += _controller.ScoreUpdate;
            }
            
            _game.MoveBall();
        }
    }
}

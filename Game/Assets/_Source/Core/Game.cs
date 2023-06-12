using System;
using _Source.GameSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source.Core
{
    public class Game
    {
        public event Action OnEndGame;
        public event Action<int> ChangeBallCount;
        
        private readonly Transform _startBallPoint;
        private readonly BallPool _ballPool;

        public Game(Transform startBallPoint, BallPool ballPool)
        {
            _startBallPoint = startBallPoint;
            _ballPool = ballPool;

            Init();
        }

        public void MoveBall()
        {
            (GameObject, bool) ball = _ballPool.GetObject();

            if (!ball.Item2)
            {
                OnEndGame?.Invoke();
                return;
            }
            
            ChangeBallCount?.Invoke(_ballPool.GetBallCount());
            ball.Item1.transform.position = _startBallPoint.position;
        }

        private void Init()
        {
            var play = new Play();
            play.Reset.Restart.performed += _ => ResetGame();
            play.Enable();
        }
        
        private void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
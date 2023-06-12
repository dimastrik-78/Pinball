using System.Collections.Generic;
using _Source.Interface;
using UnityEngine;

namespace _Source.GameSystem
{
    public class BallPool : IObjectPool
    {
        private readonly GameObject _prefBall;
        private readonly Queue<GameObject> _ball = new();

        public BallPool(GameObject prefBall)
        {
            _prefBall = prefBall;
        }

        public void InitObject(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _ball.Enqueue(Object.Instantiate(_prefBall));
            }
        }

        public int GetBallCount()
            => _ball.Count;

        public (GameObject, bool) GetObject()
        {
            if (_ball.Count == 0)
            {
                return (null, false);
            }
            
            GameObject ball = _ball.Dequeue();
            ball.SetActive(true);
            return (ball, true);
        }
    }
}
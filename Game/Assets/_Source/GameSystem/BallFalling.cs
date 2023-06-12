using System;
using _Source.Utils;
using UnityEngine;

namespace _Source.GameSystem
{
    public class BallFalling : MonoBehaviour
    {
        public event Action OnBallFall;
        
        [SerializeField] private LayerMask ballMask;

        private void OnTriggerEnter(Collider other)
        {
            if (ballMask.Contains(other.gameObject.layer))
            {
                OnBallFall?.Invoke();
            }
        }
    }
}
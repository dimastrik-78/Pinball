using System;
using _Source.Utils;
using UnityEngine;

namespace _Source.BonusSystem
{
    public class Bonus : MonoBehaviour
    {
        public event Action<int> OnCollisionWithBall;

        [SerializeField] private int giveScore;
        [SerializeField] private bool disableBonus;
        [SerializeField] private LayerMask ballMask;

        private void OnCollisionEnter(Collision other)
        {
            if (ballMask.Contains(other.gameObject.layer))
            {
                OnCollisionWithBall?.Invoke(giveScore);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (ballMask.Contains(other.gameObject.layer))
            {
                OnCollisionWithBall?.Invoke(giveScore);
                
                if (disableBonus)
                {
                    gameObject.SetActive(false);
                    transform.parent = null;
                }
            }
        }
    }
}
using System;
using UnityEngine;

namespace _Source.SpringSystem
{
    public class Spring : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private SpringJoint springJoint;

        private Play _play;
        private SpringTension _springTension;
        
        void Awake()
        {
            _play = new Play();
            _springTension = new SpringTension(rb, springJoint);

            _play.Spring.Start.started += _ => _springTension.Pulling();
            _play.Spring.Start.canceled += _ => _springTension.Release();
        }

        private void Update()
        {
            if (transform.localPosition.y > 0)
            {
                transform.localPosition = new Vector3(0, 0, 0);
            }

            if (transform.localPosition.y < -10)
            {
                transform.localPosition = new Vector3(0, -10, 0);
            }
        }

        private void OnEnable()
        {
            _play.Enable();
        }

        private void OnDisable()
        {
            _play.Disable();
        }
    }
}

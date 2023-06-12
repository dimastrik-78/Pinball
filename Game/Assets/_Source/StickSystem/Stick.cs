using UnityEngine;

namespace _Source.StickSystem
{
    public class Stick : MonoBehaviour
    {
        [SerializeField] private HingeJoint rightStick;
        [SerializeField] private HingeJoint leftStick;

        private Play _pl;
        private StickMovement _stickMovement;

        void Awake()
        {
            _pl = new Play();
            _stickMovement = new StickMovement();
            
            _pl.Stick.Right.performed += _ => StartCoroutine(_stickMovement.Rotation(rightStick));
            _pl.Stick.Left.performed += _ => StartCoroutine(_stickMovement.Rotation(leftStick));
        }

        private void OnEnable()
        {
            _pl.Enable();
        }

        private void OnDisable()
        {
            _pl.Disable();
        }
    }
}

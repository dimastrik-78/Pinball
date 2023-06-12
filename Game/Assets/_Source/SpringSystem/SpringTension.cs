using UnityEngine;

namespace _Source.SpringSystem
{
    public class SpringTension
    {
        private readonly Rigidbody _rb;
        private readonly SpringJoint _springJoint;
        private readonly float _spring;

        public SpringTension(Rigidbody rb, SpringJoint springJoint)
        {
            _rb = rb;
            _springJoint = springJoint;
            _spring = springJoint.spring;
        }

        public void Pulling()
        {
            _rb.useGravity = true;
            _springJoint.spring = 0;
            
        }

        public void Release()
        {
            _rb.useGravity = false;
            _springJoint.spring = _spring;
        }
    }
}
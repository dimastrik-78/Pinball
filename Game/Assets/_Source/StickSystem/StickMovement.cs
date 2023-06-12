using System.Collections;
using UnityEngine;

namespace _Source.StickSystem
{
    public class StickMovement
    {
        public IEnumerator Rotation(HingeJoint joint)
        {
            joint.useMotor = true;

            yield return new WaitForSeconds(0.1f);

            joint.useMotor = false;
        }
    }
}
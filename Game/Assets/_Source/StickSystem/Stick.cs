using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private HingeJoint RightStick;
    [SerializeField] private HingeJoint LeftStick;

    private Play _pl;

    void Awake()
    {
        _pl = new Play();
        _pl.Stick.Right.performed += key => ActionRight();
        _pl.Stick.Left.performed += key => ActionLeft();
        _pl.Enable();
    }

    private void ActionRight()
    {
        StartCoroutine(Rotation(RightStick));
    }

    private void ActionLeft()
    {
        StartCoroutine(Rotation(LeftStick));

    }

    private IEnumerator Rotation(HingeJoint joint)
    {
        joint.useMotor = true;

        yield return new WaitForSeconds(0.1f);

        joint.useMotor = false;
    }
}

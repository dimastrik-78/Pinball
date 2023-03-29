using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private Rigidbody RightStick;
    [SerializeField] private Rigidbody LeftStick;

    private Play _pl;

    void Awake()
    {
        _pl = new Play();
        _pl.Stick.Right.performed += contex => ActionRight();
        _pl.Stick.Left.performed += contex => ActionLeft();
        _pl.Enable();
    }

    private void ActionRight()
    {
        StartCoroutine(Rotation(RightStick, RightStick.rotation, Quaternion.Euler(15, 0, -45f)));
    }

    private void ActionLeft()
    {
        StartCoroutine(Rotation(LeftStick, LeftStick.rotation, Quaternion.Euler(15, 0, 45f)));
    }

    private IEnumerator Rotation(Rigidbody target, Quaternion startPosition, Quaternion endPosition)
    {
        //target.rotation = endPosition;
        target.rotation = Quaternion.Lerp(target.rotation, endPosition, 5f);

        yield return new WaitForSeconds(0.1f);
        
        //target.rotation = startPosition;
        //target.rotation = Quaternion.Lerp(target.rotation, startPosition, 5f);
    }
}

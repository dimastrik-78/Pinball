using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private Transform RightStick;
    [SerializeField] private Transform LeftStick;

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
        
    }

    private void ActionLeft()
    {

    }
}

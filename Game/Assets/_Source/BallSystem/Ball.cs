using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float power;
    
    private Play _pl;

    void Awake()
    {
        _pl = new Play();

        _pl.Newactionmap.Start.performed += contex => StartGame();

        _pl.Enable();
    }

    void Update()
    {
        
    }

    private void StartGame()
    {
        rb.AddForce(Vector3.up * power, ForceMode.Impulse);
    }
}

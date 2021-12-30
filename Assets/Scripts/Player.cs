using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    float leftBorderX = -3.5f;
    float reightBorderX = 3.5f;
    float lowBoardingPlayerY = 2.5f;
    float highBoardingPlayerY = 8.85f;
    float speedTurn = 10f;
    float speedForvard=25;
    
    float acceleration = 1;
    public UnityEvent onIncreaceAcceleration;

    //private bool isPlayerAlive = false;

    Vector3 vectMove;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        // StartCoroutine("SetSpeedForvard");
        SetInputManagerPlayer();
        
    }
    private void Update()
    {
       transform.Translate(0, 0, speedForvard * Time.deltaTime*acceleration);
    }

    private void SetInputManagerPlayer()
    {
        InputManager.Instance.SetPlayer(this);
    }

    private void SetShip() { }

    public void MovePlayer(Vector3 movementVector)
    {
        #region Reight/Left
        transform.Translate(movementVector.normalized*speedTurn*Time.deltaTime);
        if (transform.position.x > 3.5f) { transform.position = new Vector3(reightBorderX,transform.position.y,transform.position.z); }
        if (transform.position.x < -3.5f) { transform.position = new Vector3(leftBorderX, transform.position.y, transform.position.z); }
        #endregion
        RotateMove(movementVector);
    }

    private void RotateMove(Vector3 movementVectorR)
    {
        if (movementVectorR.x > 0) transform.Rotate(0f, 0f,  1);
        if (movementVectorR.x < 0) transform.Rotate(0f, 0f,  -1);
        if (transform.position.y < lowBoardingPlayerY) transform.position = new Vector3(transform.position.x, lowBoardingPlayerY, transform.position.z);
        if (transform.position.y > highBoardingPlayerY) transform.position = new Vector3(transform.position.x, highBoardingPlayerY, transform.position.z);
    }

    public void SetAcceleration(int acceler)
    {
        acceleration = acceler;
       // onIncreaceAcceleration.Invoke();
    }




}

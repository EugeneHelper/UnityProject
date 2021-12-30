using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    private Vector3 movementVector = new Vector3();
    private Player playerObj;
    private SmoothFollow smoothFollowCamera;


    private int ScoreX2 = 2;

    #region Singleton
    private static InputManager _instanse;
    public static InputManager Instance
    {
        get
        {
            return _instanse;
        }
    }
    private void Awake()
    {
        _instanse = this;

    }

    #endregion
    #region InputFunction
    private void MoveInput()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        if (isPlayerAlive())
        {
            playerObj.MovePlayer(movementVector);             
        }
    }

    private void SetAcceleration()
    {
        if (isPlayerAlive())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerObj.SetAcceleration(ScoreX2);
                GetComponent<Scores>().SetScoreAcceleration(ScoreX2);
                smoothFollowCamera.SetParametrs(3, 1);
                
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                playerObj.SetAcceleration(1);
                GetComponent<Scores>().SetScoreAcceleration(1);
                smoothFollowCamera.SetParametrs(6.5f, 3);  
            }
        }
    }
    #endregion

    private void Update()
    {
        MoveInput();
        SetAcceleration();
    }

    
    public void SetPlayer(Player pl)
    {
        playerObj = pl;
    }
    public void DeletePlayer()
    {
        playerObj = null;
    }
    public bool isPlayerAlive()
    {
        if (playerObj!=null) return true;
        else return false;
    }

    public void SetSmoothMovCamera(SmoothFollow cam)
    {
        smoothFollowCamera = cam;
    }

    //IEnumerator StartMovingShip()
    //{
    //    Debug.Log("coroutine Works");
    //    if (Input.anyKey)
    //    {
    //        playerObj.SetSpeedForvard();
    //        StopAllCoroutines();
            
    //    }
    //    yield return null;
    //}



}

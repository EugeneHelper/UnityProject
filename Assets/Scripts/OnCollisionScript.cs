using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionScript : MonoBehaviour
{
    public UnityEvent onGameOver;
    private void OnCollisionEnter(Collision collision)
    {
        if (InputManager.Instance.isPlayerAlive())
        {
            Debug.Log("OnCollision");
            Destroy(this.gameObject);
            InputManager.Instance.DeletePlayer();
            onGameOver.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderTurn : MonoBehaviour
{
    public FishAI fishAI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hello");
        if (other.gameObject.CompareTag("Fish"))
        {
            if (fishAI.moveRight)
            {
                fishAI.moveRight = false;
            }
            else
            {
                fishAI.moveRight = true;
            }
        }
    }
}

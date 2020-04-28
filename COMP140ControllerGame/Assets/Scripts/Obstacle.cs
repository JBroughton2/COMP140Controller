using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public bool moveRight;

    void Update()
    {
        //This will check if the moveRight bool is true, if it is then the obstacle will just start moving to the right, however it should flip and go back when it's false
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //This is the function for checking if it hits the border but it seems to not be working currently.
        if (other.gameObject.CompareTag("Border"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }
}

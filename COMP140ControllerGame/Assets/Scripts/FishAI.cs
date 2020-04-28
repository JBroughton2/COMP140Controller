using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public bool moveRight;
    public bool caught;
    public bool released;

    void Start()
    {
        caught = false;
    }

    void Update()
    {
        //This is checking if the fish has been caught by the player or not, if it has then the fish will stop it's movement functions.
        if (!caught)
        {
            //Checking if the moveRight bool is true or not. this will automatically move the fish to the right if it's true but if not then it should flip and go back the other way.
            if (moveRight)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector2(-1, 1);
            }
        }
        
    }

    //This is a simple flip function that will flip the sprite to make the fish turn around by changing the local scale.
    private void Flip()
    {
        if (moveRight)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        if (!moveRight)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1, transform.localScale.y, transform.localScale.z);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //This checks for the game border and should flip the fish around but doesn't seem to be working which is a problem.
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

    //I use this to give the fish a slight delay after being released before it's destroyed. I would add a nice animation here of it swimming away if I could animate.
    public IEnumerator ReleasedTimer()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}

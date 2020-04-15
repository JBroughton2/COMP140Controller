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
        if (!caught)
        {
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
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hello");
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

    public IEnumerator ReleasedTimer()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}

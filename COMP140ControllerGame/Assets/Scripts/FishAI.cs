using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    [Range(0, 2)]
    private float detectDistance;

    private bool movingRight = true;
    public Transform edgeDetection;
    public bool caught = false;

    private void Update()
    {
        if (!caught)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D edgeInfoRight = Physics2D.Raycast(edgeDetection.position, Vector2.down, detectDistance);
            Debug.DrawRay(edgeDetection.position, Vector2.down, Color.red);
            if (edgeInfoRight.collider == false)
            {
                if (movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
            }
        }
        
    }
}

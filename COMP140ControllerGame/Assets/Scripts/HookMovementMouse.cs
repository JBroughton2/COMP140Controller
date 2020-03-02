using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovementMouse : MonoBehaviour
{
    [SerializeField]
    private float moveSpeedX;
    [SerializeField]
    private float moveSpeedY;

    private bool movingHorizontal;
    private bool movingVertical;

    private void Start()
    {

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A) && !movingVertical || Input.GetKey(KeyCode.D) && !movingVertical)
        {
            Vector3 movementX = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movementX * Time.deltaTime * moveSpeedX;
            movingHorizontal = true;
        }
        else
        {
            movingHorizontal = false;
        }

        if (Input.GetKey(KeyCode.W) && !movingHorizontal || Input.GetKey(KeyCode.S) && !movingHorizontal)
        {
            Vector3 movementY = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
            transform.position += movementY * Time.deltaTime * moveSpeedY;
            movingVertical = true;
        }
        else
        {
            movingVertical = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Fish"))
        {
            Destroy(col.gameObject);
        }
    }


}

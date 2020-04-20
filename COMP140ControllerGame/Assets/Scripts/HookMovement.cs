using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeedX;
    [SerializeField]
    private float moveSpeedY;

    private bool movingHorizontal;
    private bool movingVertical;
    private ArduinoInput arduinoInput;

    void Start()
    {
        arduinoInput = GetComponent<ArduinoInput>();
    }

    void Update()
    {
        //This movement is set up to stop the player from moving up and down at the same time as left and right.
        if(Input.GetKey(KeyCode.A) && !movingVertical || Input.GetKey(KeyCode.D) && !movingVertical)
        {
            //Start by making a new Vector3 called movementX, this will handle all the movement along the X axis.
            Vector3 movementX = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            //We then need to actually move the player using transform and the new movement variable, I'm multiplying it by time and speed to make it smooth and allow me to change the speed.
            transform.position += movementX * Time.deltaTime * moveSpeedX;
            //This will then stop the hook from moving vertically while  it's true.
            movingHorizontal = true;
        }
        else
        {
            //When the player releases the movement key it will set this to false, therefore allowing theplayer to move vertically.
            movingHorizontal = false;
        }

        if (arduinoInput.controllerActive && !movingHorizontal)
        {
            Vector3 movementY = new Vector3(0f, arduinoInput.hookYValue, 0f);
            transform.position += movementY * Time.deltaTime * moveSpeedY;
            movingVertical = true;
        }
        else
        {
            movingVertical = false;
        }

    }

}

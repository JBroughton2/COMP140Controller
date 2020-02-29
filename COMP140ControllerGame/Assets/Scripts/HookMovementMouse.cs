using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovementMouse : MonoBehaviour
{
    [SerializeField]
    private float moveSpeedX;
    [SerializeField]
    private float moveSpeedY;

    private void Start()
    {

    }

    void Update()
    {
        Vector3 movementX = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movementX * Time.deltaTime * moveSpeedX;
        Vector3 movementY = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
        transform.position += movementY * Time.deltaTime * moveSpeedY;
    }


}

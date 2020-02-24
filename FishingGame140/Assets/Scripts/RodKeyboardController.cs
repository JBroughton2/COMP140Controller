using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodKeyboardController : MonoBehaviour
{
    private Transform hook;
    private Vector3 newHookPos;
    [SerializeField]
    private float mouseX;
    [SerializeField]
    private float xMin, xMax;

    void Start()
    {
        hook = this.gameObject.transform;
        mouseX = Input.mousePosition.x;
    }

    
    void Update()
    {
        mouseX = Mathf.Clamp(hook.position.x, xMin, xMax);
        mouseX = Input.mousePosition.x;
        newHookPos = new Vector3(mouseX, newHookPos.y);
        hook.position = newHookPos;

        

    }
}

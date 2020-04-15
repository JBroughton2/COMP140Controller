using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManager : MonoBehaviour
{
    private bool fishHooked;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Fish") && !fishHooked)
        {
            var fishMovement = col.GetComponent<FishAI>();
            col.transform.parent = this.gameObject.transform;
            fishMovement.caught = true;
            fishHooked = true;
        }

        if (col.CompareTag("Obstacle"))
        {
            foreach(Transform child in transform)
            {
                var fishMovement = GetComponentInChildren<FishAI>();
                fishMovement.caught = false;
                StartCoroutine(fishMovement.ReleasedTimer());
                child.parent = null;
                fishHooked = false;
            }
        }
    }
}

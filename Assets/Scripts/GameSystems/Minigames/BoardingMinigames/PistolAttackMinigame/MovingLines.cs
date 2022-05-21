using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLines : MonoBehaviour {

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Target") {
            Debug.Log("Moving Line triggered target " + other.name);
            triggered = true;
        }
        else {
            triggered = false;
        }
    }

    public bool IsTriggered() {
        return triggered;
    }
}

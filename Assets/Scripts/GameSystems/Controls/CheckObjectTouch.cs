using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectTouch : MonoBehaviour {
    //REMAKE

    private void Update() {
        holeHandler();
    }

    public void holeHandler() {
        if ((Input.touchCount == 1) && Input.GetTouch(0).phase == TouchPhase.Began) {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo.collider != null) {
                //We should have hit something with a 2D Physics collider!
                GameObject touchedObject = hitInfo.transform.gameObject;
                //touchedObject should be the object someone touched.
                Debug.Log("Touched " + touchedObject.transform.name);
                touchedObject.GetComponent<Hole>().addPlank();

            }
        }
    }
}

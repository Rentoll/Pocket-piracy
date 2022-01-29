using UnityEngine;

public class AimMovement : MonoBehaviour {

    private float speed = 3;
    void Update() {
        movementHandle();
    }

    private void movementHandle() {
        if (Input.touchCount == 1/*Input.touchCount == 1 /*  && Input.GetTouch(0).phase == TouchPhase.Moved*/) {
            Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            speed = Mathf.Clamp(Vector3.Distance(target, transform.position) * 3, 2, 10);
            transform.Translate(Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime) - transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Target") {
            Debug.Log("Player aim triggered target " + other.name);
            Target triggeredTarget = other.gameObject.GetComponent<Target>();
            triggeredTarget.targetColliededWithAim();
        }
    }

    public void ResetPosition() {
        Debug.Log(transform.name + " position reset");
        transform.position = new Vector3(-4, -4, 0);
    }

}

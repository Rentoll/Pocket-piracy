using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    private bool touchable = false;
    private bool active;

    private float bound = 4;

    private SpriteRenderer targetSprite;

    private void Awake() {
        targetSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void targetActivation() {
        active = true;
        touchable = Random.Range(0, 100) < 50 ? true : false;
        bound *= Random.Range(0, 2) * 2 - 1;
        StartCoroutine(targetMoving());
        StartCoroutine(targetTouchableState());
    }

    private IEnumerator targetMoving() {
        float speed = Random.Range(2, 8);
        while (active) {
            //moving from one border to another
            if (Mathf.Abs(transform.localPosition.y) >= Mathf.Abs(bound)) {
                bound = -bound;
            }
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, bound, transform.localPosition.z), Time.deltaTime * speed);
            yield return null;
        }
    }

    private IEnumerator targetTouchableState() {
        float speedOfChange = Random.Range(2, 5);
        while (active) {
            touchable = !touchable;
            if (touchable) {
                //change for image
                targetSprite.color = Color.green;
            }
            else {
                //change for image
                targetSprite.color = Color.red;
            }
            yield return new WaitForSeconds(speedOfChange);
        }
    }

    public void targetColliededWithAim() {
        active = false;
        if (touchable) {
            successfulShot();
        }
        else {
            unsuccessfulShot();
        }
    }

    private void successfulShot() {
        //change for image
        targetSprite.color = Color.grey;
    }

    private void unsuccessfulShot() {
        //change for image
        targetSprite.color = Color.yellow;
    }

    public bool isHit() {
        if(active) 
            return false;
        return true;
    }
}
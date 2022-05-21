using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class Target : MonoBehaviour {

    [Header("Particles")]
    [SerializeField]
    ParticleSystem hitTarget;
    [SerializeField]
    ParticleSystem missTarget;

    private bool touchable = false;
    private bool active;
    private bool success;

    private float bound = 4;

    private SpriteRenderer targetSprite;

    private void Awake() {
        targetSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void targetActivation() {
        active = true;
        success = false;
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
        success = true;
        targetSprite.color = Color.grey;
        hitTarget.Play();
    }

    private void unsuccessfulShot() {
        //change for image
        success = false;
        targetSprite.color = Color.yellow;
        missTarget.Play();
    }

    public bool isHit() {
        if(active) 
            return false;
        return true;
    }

    public float isSuccess() {
        if (success)
            return 1.0f;
        return 0.0f;
    }
}
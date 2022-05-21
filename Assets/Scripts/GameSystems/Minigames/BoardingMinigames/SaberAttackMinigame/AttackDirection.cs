using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttackDirection : MonoBehaviour {

    [SerializeField]
    private GameObject drawer;

    float cooldownTime = 1.0f;

    private void Awake() {
        SaberAttackMinigame.OnDrawAttackDirection += SaberAttackMinigame_OnDrawAttack;
        gameObject.GetComponent<Image>().fillAmount = 0;
        gameObject.SetActive(false);
    }

    private void SaberAttackMinigame_OnDrawAttack(SwipeDirection data) {
        ChangeAttackDirection(data);
        float cooldownEndTime = Time.deltaTime + cooldownTime;
        StartCoroutine(DrawAttackDirection(cooldownEndTime));
    }

    private void ChangeAttackDirection(SwipeDirection data) {
        switch (data) {
            case SwipeDirection.Up:
                gameObject.transform.eulerAngles = new Vector3(0, 0, 90);
                break;
            case SwipeDirection.Left:
                gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
                break;
            case SwipeDirection.Right:
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case SwipeDirection.Down:
                gameObject.transform.eulerAngles = new Vector3(0, 0, 270);
                break;
            default:
                break;
        }
        //Draw()
    }

    private IEnumerator DrawAttackDirection(float cooldownEndTime) {
        float t = 0;
        float startFill = 0;

        while ((t += Time.deltaTime) <= cooldownEndTime) {
            gameObject.GetComponent<Image>().fillAmount = Mathf.Lerp(startFill, 1, t / cooldownEndTime);
            yield return null;
        }
    }
}


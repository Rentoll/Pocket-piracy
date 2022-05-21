using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoardingBattleAI : MonoBehaviour {

    [SerializeField]
    private GameObject EnemyGameObject;

    public static UnityEvent<string> OnAIAction = new UnityEvent<string>();

    private Pirate enemyPirate;

    [SerializeField]
    private GameObject CurrentAction;
    [SerializeField]
    private GameObject[] Icons;

    private float actionCooldownTime;

    private void Awake() {
        enemyPirate = EnemyGameObject.GetComponent<Pirate>();
        actionCooldownTime = Time.deltaTime;
        
    }

    private void Update() {
        ProcessAI();
    }

    private void ProcessAI() {
        if (Time.time + enemyPirate.AICooldownAction1 > actionCooldownTime) {
            actionCooldownTime = Time.time + enemyPirate.AICooldownAction1 * 2;
            int AIAction = Random.Range(0,2);
            StartCoroutine(DrawActionIndicator(AIAction));
        }
    }

    private IEnumerator DrawActionIndicator(int actionID, float duration = 2f) {

        Debug.Log("Started drawing action indicator");

        float cooldownEndTime = Time.time + duration;
        float buffTime = Time.time;

        Icons[actionID].SetActive(true);

        float elapsedTime = 0;
        float startValue = 0;
        float endValue = 1;
        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            Icons[actionID].GetComponent<SpriteRenderer>().color = new Color(Icons[actionID].GetComponent<SpriteRenderer>().color.r, Icons[actionID].GetComponent<SpriteRenderer>().color.g, Icons[actionID].GetComponent<SpriteRenderer>().color.b, newAlpha);
            yield return null;
        }
        Icons[actionID].SetActive(false);
        UseAction(actionID);
        //attackIndicator.SetActive(false);
        //OnAiAttack?.Invoke();
    }

    private void UseAction(int actionID) {
        //play animation
        switch (actionID) {
            case 0:
                OnAIAction?.Invoke("Pirate_Sword_Attack");
                break;
            case 1:
                OnAIAction?.Invoke("Pirate_Pistol_Attack");
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}

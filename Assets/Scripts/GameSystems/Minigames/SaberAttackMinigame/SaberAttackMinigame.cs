using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaberAttackMinigame : Minigame {

    public static event System.Action<SwipeDirection> OnDrawAttackDirection = delegate { };

    public static UnityEvent<float> OnSaberHit = new UnityEvent<float>();

    private SwipeDirection attackDirection;
    private SwipeData playerDirection;
    private float attackDamageMult = 1f;

    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject AttackDirection;
    [SerializeField]
    private GameObject UI;

    private void Awake() {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
        minigameGroup.SetActive(false);
        countdownBar.SetActive(false);
    }

    private void SwipeDetector_OnSwipe(SwipeData data) {
        Debug.Log("Swipe in Direction: " + data.Direction);
        playerDirection = data;
        checkTargetsCondition();
    }

    public override void startMinigame() {
        UI.GetComponent<UIMasterController>().HideUI();
        minigameGroup.SetActive(true);
        countdownBar.SetActive(true);
        AttackDirection.SetActive(true);
        AttackDirection.SetActive(true);
        attackDamageMult = 1f;
        attackDirection = (SwipeDirection)Random.Range(0, 4);
        StartCoroutine(countdownToEnd());
        OnDrawAttackDirection(attackDirection);
        
    }

    protected override void checkTargetsCondition() {
        if(playerDirection.Direction == attackDirection) {
            Debug.Log("Successfull saber attack");
            attackDamageMult = 1.7f;
            minigameResult();
        }
        else {
            Debug.Log("Unsuccess saber attack");
            attackDamageMult = 0.5f;
            minigameResult();
        }
    }

    protected override IEnumerator countdownToEnd() {
        countdownBar.GetComponent<Healthbar>().deliverDamage(1, minigameTimeInSeconds);
        yield return new WaitForSeconds(minigameTimeInSeconds);
        endMinigame();
    }

    protected override void endMinigame() {
        minigameGroup.SetActive(false);
        countdownBar.SetActive(false);
        AttackDirection.SetActive(false);
        button.GetComponent<ButtonCooldown>().DrawCooldown();
        countdownBar.GetComponent<Healthbar>().fullHealth();
        UI.GetComponent<UIMasterController>().ShowUI();
    }

    protected override void minigameResult() {
        endMinigame();
        //draw attack animation
        //deal damage
    }
}

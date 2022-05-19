using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SaberAttackMinigame : Minigame {

    public static event System.Action<SwipeDirection> OnDrawAttackDirection = delegate { };

    private SwipeDirection attackDirection;
    private SwipeData playerDirection;
    private float attackDamageMult = 1f;

    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject AttackDirection;

    private void Awake() {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data) {
        Debug.Log("Swipe in Direction: " + data.Direction);
        playerDirection = data;
        checkTargetsCondition();
    }

    public override void startMinigame() {
        minigameGroup.SetActive(true);
        countdownBar.SetActive(true);
        AttackDirection.SetActive(true);
        attackDamageMult = 1f;
        attackDirection = (SwipeDirection)Random.Range(0, 4);
        OnDrawAttackDirection(attackDirection);
        
    }

    protected override void checkTargetsCondition() {
        if(playerDirection.Direction == attackDirection) {
            Debug.Log("Success saber attack");
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
    }

    protected override void minigameResult() {
        //draw attack animation
        //deal damage
    }
}

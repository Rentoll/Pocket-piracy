using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MinigameCannon : Minigame {

    private int numberOfTargets;

    [SerializeField]
    private GameObject[] targets;

    [SerializeField]
    private GameObject Aim;

    [SerializeField]
    private GameObject SeaBattle;

    [SerializeField]
    private Button button;

    [SerializeField]
    private ParticleSystem woodenRemains;

    private void Awake() {
        //targets = GameObject.FindGameObjectsWithTag("Target");
        numberOfTargets = targets.Length;
        minigameGroup.SetActive(false);
    }

    private void FixedUpdate() {
        checkTargetsCondition();
    }

    public override void startMinigame() {
        Debug.Log("Started cannon minigame");
        countdownBar.SetActive(true);
        minigameGroup.SetActive(true);
        countdownBar.GetComponent<Healthbar>().fullHealth();
        SeaBattle.SetActive(false);
        foreach (GameObject currentTarget in targets) {
            currentTarget.GetComponent<Target>().targetActivation();
        }
        button.GetComponent<ButtonCooldown>().StopCooldown();
        StartCoroutine(countdownToEnd());

    }

    protected override IEnumerator countdownToEnd() {
        countdownBar.GetComponent<Healthbar>().deliverDamage(1, minigameTimeInSeconds);
        yield return new WaitForSeconds(minigameTimeInSeconds);
        endMinigame();
    }

    protected override void checkTargetsCondition() {
        int hittedtargets = 0;
        foreach (GameObject currentTarget in targets) {
            if (currentTarget.GetComponent<Target>().isHit()) {
                hittedtargets++;
            }
        }
        if (hittedtargets == numberOfTargets) {
            //minigameResult();
            endMinigame();
        }
    }
    protected override float minigameResult() {
        throw new System.NotImplementedException();
    }
    protected override void endMinigame() {
        minigameGroup.SetActive(false);
        countdownBar.SetActive(false);
        SeaBattle.SetActive(true);
        button.GetComponent<ButtonCooldown>().DrawCooldown();
        Aim.GetComponent<AimMovement>().ResetPosition();
        countdownBar.GetComponent<Healthbar>().fullHealth();
        ParticleSystem remains = Instantiate(woodenRemains);
        remains.Play();
        NavalCombat?.Invoke(minigameResult());
    }
}

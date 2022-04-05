using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MinigameCannon : Minigame {

    private int numberOfTargets;

    public static UnityEvent<float> OnCannonShoot = new UnityEvent<float>();

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

    private int successfulHits, allHits; 

    private void Awake() {
        //targets = GameObject.FindGameObjectsWithTag("Target");
        numberOfTargets = targets.Length;
        countdownBar.SetActive(false);
        minigameGroup.SetActive(false);
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
        successfulHits = allHits = 0;
        StartCoroutine(countdownToEnd());

    }

    protected override IEnumerator countdownToEnd() {
        countdownBar.GetComponent<Healthbar>().deliverDamage(1, minigameTimeInSeconds);
        yield return new WaitForSeconds(minigameTimeInSeconds);
        endMinigame();
    }

    private void FixedUpdate() {
        checkTargetsCondition();
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
            minigameResult();
        }
    }
    protected override void minigameResult() {
        float damageMultiplier = 1;
        foreach (GameObject currentTarget in targets) {
            damageMultiplier += currentTarget.GetComponent<Target>().isSuccess() * 0.5f;
        }
        Debug.Log(damageMultiplier);
        OnCannonShoot.Invoke(playerShip.GetComponent<Ship>().calculateDamage() * damageMultiplier);

        endMinigame();
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
        //NavalCombatSystem.OnCannonShoot?.Invoke(5f);
    }
}

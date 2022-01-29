using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RepairMinigame : Minigame {

    private int numberOfHoles;
    private GameObject[] holes;

    [SerializeField]
    private GameObject SeaBattle;

    private void Awake() {
        holes = GameObject.FindGameObjectsWithTag("Hole");
        SeaBattle = GameObject.Find("SeaBattle");
        numberOfHoles = holes.Length;
    }

    private void FixedUpdate() {
        checkTargetsCondition();
    }

    public override void startMinigame() {
        Debug.Log("Started repair minigame");
        countdownBar.SetActive(true);
        minigameGroup.SetActive(true);
        countdownBar.GetComponent<Healthbar>().fullHealth();
        SeaBattle.SetActive(false);
        foreach (GameObject currentTarget in holes) {
            currentTarget.GetComponent<Hole>().holeActivation();
        }

        StartCoroutine(countdownToEnd());
    }

    protected override void checkTargetsCondition() {
        int repairedHoles = 0;
        foreach (GameObject currentHole in holes) {
            if (currentHole.GetComponent<Hole>().checkStatus()) {
                repairedHoles++;
            }
        }
        if (repairedHoles == holes.Length) {
            //minigameResult();
            endMinigame();
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
        SeaBattle.SetActive(true);
        GameObject.FindGameObjectWithTag("SeaRepair").GetComponent<ButtonCooldown>().startCooldown();
        countdownBar.GetComponent<Healthbar>().fullHealth();

    }

    protected override float minigameResult() {
        throw new System.NotImplementedException();
    }
}

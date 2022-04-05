using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RepairMinigame : Minigame {

    private int numberOfHoles;

    [SerializeField]
    private GameObject[] holes;

    [SerializeField]
    private GameObject SeaBattle;

    [SerializeField]
    private Button button;

    private void Awake() {
        //holes = GameObject.FindGameObjectsWithTag("Hole");
        //SeaBattle = GameObject.Find("SeaBattle");
        numberOfHoles = holes.Length;
        minigameGroup.SetActive(false);
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
        button.GetComponent<ButtonCooldown>().StopCooldown();
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
        button.GetComponent<ButtonCooldown>().DrawCooldown();
        countdownBar.GetComponent<Healthbar>().fullHealth();
    }

    protected override void minigameResult() {
        throw new System.NotImplementedException();
    }
}

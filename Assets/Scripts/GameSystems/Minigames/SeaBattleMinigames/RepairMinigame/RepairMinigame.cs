using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RepairMinigame : Minigame {

    public static UnityEvent<float> OnRepair = new UnityEvent<float>();

    private int repairedHoles;

    [SerializeField]
    private GameObject[] holes;

    [SerializeField]
    private GameObject SeaBattle;

    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject text;

    private void Awake() {
        //holes = GameObject.FindGameObjectsWithTag("Hole");
        //SeaBattle = GameObject.Find("SeaBattle");
        minigameGroup.SetActive(false);
        text.SetActive(false);
    }

    private void FixedUpdate() {
        checkTargetsCondition();
    }

    public override void startMinigame() {

        Debug.Log("Started repair minigame");
        text.SetActive(true);
        countdownBar.SetActive(true);
        minigameGroup.SetActive(true);
        countdownBar.GetComponent<Healthbar>().fullHealth();
        //SeaBattle.SetActive(false);
        SeaBattle.transform.localScale = new Vector3(0, 0, 0);

        repairedHoles = 0;

        foreach (GameObject currentTarget in holes) {
            currentTarget.GetComponent<Hole>().holeActivation();
        }
        button.GetComponent<ButtonCooldown>().StopCooldown();
        StartCoroutine(countdownToEnd());
    }

    protected override void checkTargetsCondition() {
        int currentRepairedHoles = 0;
        foreach (GameObject currentHole in holes) {
            if (currentHole.GetComponent<Hole>().checkStatus()) {
                currentRepairedHoles++;
            }
        }
        if (currentRepairedHoles == holes.Length) {
            repairedHoles = holes.Length;
            minigameResult();
            
        }
    }

    protected override void minigameResult() {
        float repairMultiplier = 1 + repairedHoles * 0.5f;

        Debug.Log(repairMultiplier);
        OnRepair?.Invoke(playerShip.GetComponent<Ship>().NumberOfRepairPoints * repairMultiplier);

        endMinigame();
    }

    protected override IEnumerator countdownToEnd() {
        countdownBar.GetComponent<Healthbar>().deliverDamage(1, minigameTimeInSeconds);
        yield return new WaitForSeconds(minigameTimeInSeconds);

        repairedHoles = 0;

        foreach (GameObject currentHole in holes) {
            if (currentHole.GetComponent<Hole>().checkStatus()) {
                repairedHoles++;
            }
        }
        minigameResult();
    }

    protected override void endMinigame() {
        minigameGroup.SetActive(false);
        countdownBar.SetActive(false);
        //SeaBattle.SetActive(true);
        text.SetActive(false);
        SeaBattle.transform.localScale = new Vector3(1, 1, 1);
        button.GetComponent<ButtonCooldown>().DrawCooldown();
        countdownBar.GetComponent<Healthbar>().fullHealth();
    }


}

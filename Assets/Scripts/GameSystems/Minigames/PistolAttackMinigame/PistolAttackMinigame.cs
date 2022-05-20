using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PistolAttackMinigame : Minigame {

    public static UnityEvent<float> OnPistolHit = new UnityEvent<float>();

    [SerializeField]
    private GameObject[] movingLines;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Button button;
    [SerializeField]
    private GameObject UI;

    private float[] bound = new float[] { 9f, 5f };
    private bool active;
    private int currentLine;

    private int maxLines = 2, successfulLines = 0;

    private void Awake() {
        minigameGroup.SetActive(false);
    }

    public override void startMinigame() {
        active = true;
        currentLine = successfulLines = 0;
        UI.GetComponent<UIMasterController>().HideUI();
        minigameGroup.SetActive(true);
        countdownBar.SetActive(true);
        StartCoroutine(countdownToEnd());
        StartCoroutine(TargetMoving());
    }

    private void Update() {
        if ((Input.touchCount == 1) && Input.GetTouch(0).phase == TouchPhase.Began) {
            active = false;
        }
    }

    protected override void checkTargetsCondition() {
        foreach(GameObject line in movingLines) {
            if(line.GetComponent<MovingLines>().IsTriggered()) {
                successfulLines++;
            }
        }
        minigameResult();
    }

    protected override IEnumerator countdownToEnd() {
        countdownBar.GetComponent<Healthbar>().deliverDamage(1, minigameTimeInSeconds);
        yield return new WaitForSeconds(minigameTimeInSeconds);
        endMinigame();
    }

    private IEnumerator TargetMoving() {
        while (currentLine < movingLines.Length) {
            float speed = Random.Range(7, 12);
            while (active) {
                //moving from one border to another
                if (currentLine == 0 && Mathf.Abs(movingLines[currentLine].transform.localPosition.x) >= Mathf.Abs(bound[currentLine]) || currentLine == 1 && Mathf.Abs(movingLines[currentLine].transform.localPosition.y) >= Mathf.Abs(bound[currentLine])) {
                    bound[currentLine] = -bound[currentLine];
                }
                if (currentLine == 0) {
                    movingLines[currentLine].transform.localPosition = Vector3.MoveTowards(movingLines[currentLine].transform.localPosition, new Vector3(bound[currentLine], movingLines[currentLine].transform.localPosition.y, movingLines[currentLine].transform.localPosition.z), Time.deltaTime * speed);
                }
                if(currentLine == 1) {
                    movingLines[currentLine].transform.localPosition = Vector3.MoveTowards(movingLines[currentLine].transform.localPosition, new Vector3(movingLines[currentLine].transform.localPosition.x, bound[currentLine], movingLines[currentLine].transform.localPosition.z), Time.deltaTime * speed);
                }
                yield return null;
            }
            active = true;
            currentLine++;
        }
        checkTargetsCondition();
    }

    protected override void endMinigame() {
        successfulLines = 0;
        minigameGroup.SetActive(false);
        countdownBar.SetActive(false);
        button.GetComponent<ButtonCooldown>().DrawCooldown();
        countdownBar.GetComponent<Healthbar>().fullHealth();
        UI.GetComponent<UIMasterController>().ShowUI();
    }

    protected override void minigameResult() {
        if (successfulLines == maxLines) {
            Debug.Log("Pistol attack win");
            //win
        }
        endMinigame();
    }
}

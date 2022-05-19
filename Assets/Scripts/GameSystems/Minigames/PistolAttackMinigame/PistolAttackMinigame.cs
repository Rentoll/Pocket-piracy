using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAttackMinigame : Minigame {

    [SerializeField]
    private GameObject[] movingLines;

    private float[] bound = new float[] { 9f, 5f };
    private bool active;
    private int currentLine;


    public override void startMinigame() {
        active = true;
        currentLine = 0;
        //minigameGroup.SetActive(true);
        //countdownBar.SetActive(true);
        StartCoroutine(TargetMoving());
    }

    private void Update() {
        if ((Input.touchCount == 1) && Input.GetTouch(0).phase == TouchPhase.Began) {
            active = false;
        }
    }

    protected override void checkTargetsCondition() {
        throw new System.NotImplementedException();
    }

    protected override IEnumerator countdownToEnd() {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
    }

    protected override void minigameResult() {
        throw new System.NotImplementedException();
    }
}

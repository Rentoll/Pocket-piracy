using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameEvasion : Minigame {

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject SeaBattle;

    private void Awake() {
        minigameGroup.SetActive(false);
    }

    public override void startMinigame() {
        //set state of player ship to evasion
        Debug.Log("Started evasion minigame");
        minigameGroup.SetActive(true);

        StartCoroutine(ShipEvasion());

        //countdownBar.SetActive(true);
        
        //countdownBar.GetComponent<Healthbar>().fullHealth();
        SeaBattle.SetActive(false);

        button.GetComponent<ButtonCooldown>().StopCooldown();
        StartCoroutine(countdownToEnd());
    }


    
    private IEnumerator ShipEvasion() {
        Debug.Log("Started camera moving");
        bool active = true;
        float bound = 10;
        float speed = 10;
        bool cameraReturning = false;
        while (active) {
            //moving from one border to another
            /*
            if (Mathf.Abs(transform.localPosition.y) >= Mathf.Abs(bound)) {
                bound = -bound;
            }*/
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.localPosition, new Vector3(bound, mainCamera.transform.localPosition.y, mainCamera.transform.localPosition.z), Time.deltaTime * speed);
            if (mainCamera.transform.localPosition.x >= bound) {
                bound = 0;
                cameraReturning = true;
            }
            if (cameraReturning && mainCamera.transform.localPosition.x <= 0) {
                active = false;
            }
            yield return null;
        }
        Debug.Log("Ended camera moving");
        endMinigame();
    }

    protected override void checkTargetsCondition() {
        throw new System.NotImplementedException();
    }

    protected override IEnumerator countdownToEnd() {
        throw new System.NotImplementedException();
    }

    protected override void endMinigame() {
        minigameGroup.SetActive(false);
        //countdownBar.SetActive(false);
        SeaBattle.SetActive(true);
        button.GetComponent<ButtonCooldown>().DrawCooldown();
        //countdownBar.GetComponent<Healthbar>().fullHealth();
    }

    protected override float minigameResult() {
        throw new System.NotImplementedException();
    }
}

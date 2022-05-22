using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class MinigameEvasion : Minigame {

    public static UnityEvent<bool> OnEvasion = new UnityEvent<bool>();

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
        //SeaBattle.SetActive(false);
        SeaBattle.transform.localScale = new Vector3(0, 0, 0);

        button.GetComponent<ButtonCooldown>().StopCooldown();
        //StartCoroutine(countdownToEnd());
    }


    
    private IEnumerator ShipEvasion() {
        Debug.Log("Started camera moving");


        bool active = true;
        float bound = 10;
        float speed = 10;
        bool cameraReturning = false;

        OnEvasion?.Invoke(active);

        while (active) {
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
        OnEvasion?.Invoke(active);
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
        //SeaBattle.SetActive(true);
        SeaBattle.transform.localScale = new Vector3(1, 1, 1);
        button.GetComponent<ButtonCooldown>().DrawCooldown();
        //countdownBar.GetComponent<Healthbar>().fullHealth();
    }

    protected override void minigameResult() {
        throw new System.NotImplementedException();
    }
}

using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MinigameEngage : Minigame {

    [SerializeField]
    private GameObject enemyShip;
    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject SeaBattle;
    /*
    private Vector3[] enemyShipScale = {
        new Vector3(0.55f, 0.55f, 0.55f),
        new Vector3(0.7f, 0.7f, 0.7f)
    };
    */

    private Vector3[] enemyShipScale = {
        new Vector3(1.2f, 1.2f, 1f),
        new Vector3(1.4f, 1.4f, 1f)
    };

    private int finalSize = 1;

    private int currentEnemySize = 0;

    public override void startMinigame() {
        if (currentEnemySize > finalSize) {
            SceneManager.LoadScene("BoardingBattle");
            //endMinigame();
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Start boarding
        }
        Debug.Log("Started engaging minigame");
        minigameGroup.SetActive(true);

        StartCoroutine(ShipEngage(enemyShip.transform.localScale));

        //countdownBar.SetActive(true);

        //countdownBar.GetComponent<Healthbar>().fullHealth();
        //SeaBattle.SetActive(false);
        SeaBattle.transform.localScale = new Vector3(0, 0, 0);

        button.GetComponent<ButtonCooldown>().StopCooldown();
        //StartCoroutine(countdownToEnd());
    }
    private IEnumerator ShipEngage(Vector3 minScale) {
        Debug.Log("Started sizing enemy ship");

        float time = 3f;
        float speed = 2f;

        float i = 0f;
        float rate = (1f / time) * speed;
        while(i < 0.9f) {
            i += Time.deltaTime * rate;
            enemyShip.transform.localScale = Vector3.Lerp(minScale, enemyShipScale[currentEnemySize], i);
            yield return null;
        }
        currentEnemySize++;
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

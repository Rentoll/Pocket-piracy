using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SaberBlockMinigame : Minigame {

    [SerializeField]
    private Button button;

    public static UnityEvent<bool> OnSaberBlock = new UnityEvent<bool>();

    private void Awake() {
        minigameGroup.SetActive(false);
    }

    public override void startMinigame() {
        minigameGroup.SetActive(true);
        StartCoroutine(countdownToEnd());
    }

    protected override void checkTargetsCondition() {
        throw new System.NotImplementedException();
    }

    protected override IEnumerator countdownToEnd() {
        Debug.Log("Started blocking");
        button.GetComponent<ButtonCooldown>().DrawCooldown();
        bool active = true;

        OnSaberBlock?.Invoke(active);

        yield return new WaitForSeconds(2);


        active = false;

        Debug.Log("Ended blocking");
        OnSaberBlock?.Invoke(active);
        endMinigame();
    }

    protected override void endMinigame() {
        minigameGroup.SetActive(false);
    }

    protected override void minigameResult() {
        throw new System.NotImplementedException();
    }
}

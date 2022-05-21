using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EvasionMinigame : Minigame {

    [SerializeField]
    private Button button;

    public static UnityEvent<bool> OnEvasion = new UnityEvent<bool>();

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
        Debug.Log("Started evading");
        button.GetComponent<ButtonCooldown>().DrawCooldown();
        bool active = true;

        OnEvasion?.Invoke(active);

        yield return new WaitForSeconds(2);


        active = false;

        Debug.Log("Ended evading");
        OnEvasion?.Invoke(active);
        endMinigame();
    }

    protected override void endMinigame() {
        minigameGroup.SetActive(false);
        
    }

    protected override void minigameResult() {
        throw new System.NotImplementedException();
    }
}

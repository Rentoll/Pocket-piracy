using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour {

    private bool isPaused = false;

    public void PauseDrawer() {
        Debug.Log("Stopped Drawing");
        isPaused = true;
    }

    public void DrawCooldownButton(float cooldownTime, Image cooldownImage, Button cooldownButton) {
        float cooldownEndTime = Time.deltaTime + cooldownTime;
        cooldownButton.interactable = false;
        isPaused = false;
        StartCoroutine(DrawCooldown(cooldownTime, cooldownEndTime, cooldownImage, cooldownButton));
    }

    private IEnumerator DrawCooldown(float cooldownTime, float cooldownEndTime, Image cooldownImage, Button cooldownButton) {
        float t = 0;
        float startFill = 0;

        while ((t += Time.deltaTime) <= cooldownEndTime) {
            while (isPaused) {
                yield return null;
            }
            cooldownImage.fillAmount = Mathf.Lerp(startFill, 1, t / cooldownEndTime);
            yield return null;
        }
        cooldownButton.interactable = true;
    }
}

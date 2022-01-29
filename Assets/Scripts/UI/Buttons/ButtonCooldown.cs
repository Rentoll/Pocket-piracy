using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//!!!!Change cooldownTime
public class ButtonCooldown : MonoBehaviour {

    [Header("Image reference")]
    [SerializeField]
    private Image cooldownImage;

    [Header("Button reference")]
    [SerializeField]
    private Button cooldownButton;

    private float cooldownTime = 5;
    private float cooldownEndTime = 0;

    //!!!!!make common function
    private IEnumerator drawCooldown(float cooldownTime, float cooldownEndTime) {
        float t = 0;
        float startFill = 0;
        while ((t += Time.deltaTime) <= cooldownEndTime) {
            cooldownImage.fillAmount = Mathf.Lerp(startFill, 1, t / cooldownEndTime);
            yield return null;
        }
        cooldownButton.interactable = true;
    }

    public void startCooldown() {
        cooldownEndTime = Time.deltaTime + cooldownTime;
        cooldownButton.interactable = false;
        StartCoroutine(drawCooldown(cooldownTime, cooldownEndTime));
    }
}

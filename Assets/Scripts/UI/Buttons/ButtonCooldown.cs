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

    [Header("Drawer reference")]
    [SerializeField]
    private GameObject drawer;

    private float cooldownTime = 5;

    public void DrawCooldown() {
        drawer.GetComponent<Drawer>().DrawCooldownButton(cooldownTime, cooldownImage, cooldownButton);
    }

    public void StopCooldown() {
        drawer.GetComponent<Drawer>().PauseDrawer();
    }

    //!!!!!make common function
    /*
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
    */
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
    [Header("Image references")]
    [SerializeField]
    private Image HealthbarImage;
    [SerializeField]
    private Image HealthbarImageDamaged;

    //private float damageApplyingTime = 2;

    //!!!!Make common function

    private void Awake() {
        fullHealth();
    }

    public void deliverDamage(float damageAmount, float damageApplyingTime = 2) {
        Debug.Log("Healthbar took Damage " + damageAmount);
        HealthbarImage.fillAmount = Mathf.Clamp(HealthbarImage.fillAmount - damageAmount, 0, 1);
        float damageEndTime = Time.deltaTime + damageApplyingTime;
        StartCoroutine(drawDamage(damageApplyingTime, damageEndTime, HealthbarImage.fillAmount));
    }

    private IEnumerator drawDamage(float cooldownTime, float cooldownEndTime, float damageAmount) {
        float t = 0;
        float startFill = HealthbarImageDamaged.fillAmount;
        while ((t += Time.deltaTime) <= cooldownEndTime) {
            HealthbarImageDamaged.fillAmount = Mathf.Lerp(startFill, damageAmount, t / cooldownEndTime);
            yield return null;
        }
    }

    private IEnumerator drawHeal(float cooldownTime, float cooldownEndTime, float healAmount) {
        float t = 0;
        float startFill = HealthbarImage.fillAmount;
        while ((t += Time.deltaTime) <= cooldownEndTime) {
            HealthbarImage.fillAmount = Mathf.Lerp(startFill, healAmount, t / cooldownEndTime);
            yield return null;
        }
        HealthbarImageDamaged.fillAmount = HealthbarImage.fillAmount;
    }

    public void fullHealth() {
        HealthbarImage.fillAmount = 1;
        HealthbarImageDamaged.fillAmount = 1;
    }

    public void addHealth(float healAmount, float damageApplyingTime = 2) {
        Debug.Log("Healthbar Add HP " + healAmount);
        float damageEndTime = Time.deltaTime + damageApplyingTime;
        StartCoroutine(drawHeal(damageApplyingTime, damageEndTime, Mathf.Clamp(HealthbarImage.fillAmount + healAmount, 0, 1)));
    }
}

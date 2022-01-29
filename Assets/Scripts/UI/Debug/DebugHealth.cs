using UnityEngine;

public class DebugHealth : MonoBehaviour {

    [Header("Damage and heal amount (0-1)")]
    [SerializeField]
    [Range(0, 1)]
    private float damageAmount;
    [SerializeField]
    [Range(0, 1)]
    private float healAmount;

    private Healthbar playerHealthbar;

    private void Start() {
        playerHealthbar = GameObject.FindGameObjectWithTag("HealthbarPlayer").GetComponent<Healthbar>();
    }

    public void makeDamage() {
        print("Damage");
        playerHealthbar.deliverDamage(damageAmount);
    }

    public void addHealth() {
        playerHealthbar.addHealth(healAmount);
    }

}

using UnityEngine;

public class Pirate : MonoBehaviour {
    [SerializeField]
    private float healthPoints;
    [SerializeField]
    private float saberAttackCooldown;
    [SerializeField]
    private float saberDamage;
    [SerializeField]
    private float pistolAttackCooldown;
    [SerializeField]
    private float pistolAttackDamage;
    [SerializeField]
    private float evasionCooldown;
    [SerializeField]
    private float swordBlockCooldown;
    [SerializeField]
    private float AICooldownAction;
    private float fullHealthPoints;

    [SerializeField]
    private bool evasion = false;
    [SerializeField]
    private bool saberBlock = false;


    public float AICooldownAction1 { get => AICooldownAction; set => AICooldownAction = value; }
    public float SwordBlockCooldown { get => swordBlockCooldown; set => swordBlockCooldown = value; }
    public float EvasionCooldown { get => evasionCooldown; set => evasionCooldown = value; }
    public float PistolAttackCooldown { get => pistolAttackCooldown; set => pistolAttackCooldown = value; }
    public float SaberDamage { get => saberDamage; set => saberDamage = value; }
    public float SaberAttackCooldown { get => saberAttackCooldown; set => saberAttackCooldown = value; }
    public float HealthPoints { get => healthPoints; set => healthPoints = value; }
    public bool Evasion { get => evasion; set => evasion = value; }
    public bool SaberBlock { get => saberBlock; set => saberBlock = value; }
    public float PistolAttackDamage { get => pistolAttackDamage; set => pistolAttackDamage = value; }
    public float FullHealthPoints { get => fullHealthPoints; set => fullHealthPoints = value; }
}

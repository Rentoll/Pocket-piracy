using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour {
    [SerializeField]
    private int healthPoints;
    [SerializeField]
    private float saberAttackCooldown;
    [SerializeField]
    private float saberDamage;
    [SerializeField]
    private float pistolAttackCooldown;
    [SerializeField]
    private float evasionCooldown;
    [SerializeField]
    private float swordBlockCooldown;
    [SerializeField]
    private float AICooldownAction;

    private float evasion;

    public float AICooldownAction1 { get => AICooldownAction; set => AICooldownAction = value; }
    public float SwordBlockCooldown { get => swordBlockCooldown; set => swordBlockCooldown = value; }
    public float EvasionCooldown { get => evasionCooldown; set => evasionCooldown = value; }
    public float PistolAttackCooldown { get => pistolAttackCooldown; set => pistolAttackCooldown = value; }
    public float SaberDamage { get => saberDamage; set => saberDamage = value; }
    public float SaberAttackCooldown { get => saberAttackCooldown; set => saberAttackCooldown = value; }
    public int HealthPoints { get => healthPoints; set => healthPoints = value; }
}

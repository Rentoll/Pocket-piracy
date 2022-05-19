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

    private float evasion;
}

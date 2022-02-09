using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    [SerializeField]
    private float hullPoints;
    [SerializeField]
    private float repairCooldown;
    [SerializeField]
    private float numberOfRepairPoints;
    [SerializeField]
    private Sprite[] shipCondition;
    //img UI ship
    [SerializeField]
    private float evadeCooldown;
    [SerializeField]
    private float boardingCooldown;
    [SerializeField]
    private float cannonReloadSpeed;
    [SerializeField]
    private float cannonDamage;
    [SerializeField]
    private int cannonNum;

    public float HullPoints { get => hullPoints; set => hullPoints = value; }
    public float RepairCooldown { get => repairCooldown; set => repairCooldown = value; }
    public float NumberOfRepairPoints { get => numberOfRepairPoints; set => numberOfRepairPoints = value; }
    public float EvadeCooldown { get => evadeCooldown; set => evadeCooldown = value; }
    public float BoardingCooldown { get => boardingCooldown; set => boardingCooldown = value; }
    public float CannonReloadSpeed { get => cannonReloadSpeed; set => cannonReloadSpeed = value; }
    public float CannonDamage { get => cannonDamage; set => cannonDamage = value; }
    public int CannonNum { get => cannonNum; set => cannonNum = value; }

    public float calculateDamage() {
        return CannonDamage * CannonNum;
    }

}

using System.Collections;
using System.Collections.Generic;

public class Ship {


    private float hullPoints;
    private float repairCooldown;
    private float numberOfRepairPoints;

    //img Ship
    //img UI ship

    private float evadeCooldown;
    private float boardingCooldown;

    private float cannonReloadSpeed;
    private float cannonDamage;
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

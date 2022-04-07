using UnityEngine;

public class NavalCombatSystem : MonoBehaviour {

    [SerializeField]
    private GameObject playerShip;
    [SerializeField]
    private GameObject enemyShip;

    private bool playerEvading = false;

    [SerializeField]
    private GameObject healthbarPlayer; 
    [SerializeField]
    private GameObject healthbarEnemy;

    private void Awake() {
        MinigameCannon.OnCannonShoot.AddListener(CannonShoot);
        RepairMinigame.OnRepair.AddListener(RepairShip);
        MinigameEvasion.OnEvasion.AddListener(EvadeShip);
        SeaBattleAI.OnAiAttack.AddListener(AttackPlayerShip);

        playerShip.GetComponent<Ship>().FullHullPoints = playerShip.GetComponent<Ship>().HullPoints;
        enemyShip.GetComponent<Ship>().FullHullPoints = enemyShip.GetComponent<Ship>().HullPoints;
    }

    private void CannonShoot(float damage) {
        Debug.Log("Naval Combat System. Player dealt damage " + damage);
        AttackShip(playerShip.GetComponent<Ship>(), enemyShip.GetComponent<Ship>(), damage);
        Debug.Log("Damage in % " + damage / enemyShip.GetComponent<Ship>().FullHullPoints);
        healthbarEnemy.GetComponent<Healthbar>().deliverDamage(damage / enemyShip.GetComponent<Ship>().FullHullPoints);
    }

    private void RepairShip(float repairPoints) {
        Debug.Log("Naval Combat System. Repaired by " + repairPoints);
        Repair(playerShip.GetComponent<Ship>(), repairPoints);
    }

    private void EvadeShip(bool status) {
        Debug.Log("Naval Combat System. Evasion status " + status);
        playerEvading = status;
    }

    public void AttackPlayerShip() {
        //
        //playShootingAnimation();
        if (playerEvading == false) {
            Debug.Log("Enemy ship dealt damage to Player ship.");
            AttackShip(enemyShip.GetComponent<Ship>(), playerShip.GetComponent<Ship>());
            Debug.Log("Damage in % " + enemyShip.GetComponent<Ship>().calculateDamage() / playerShip.GetComponent<Ship>().FullHullPoints);
            healthbarPlayer.GetComponent<Healthbar>().deliverDamage(enemyShip.GetComponent<Ship>().calculateDamage()/playerShip.GetComponent<Ship>().FullHullPoints);
        }
    }

    private void AttackShip(Ship attacker, Ship target, float damage = 0) {
        if (damage == 0) {
            target.HullPoints -= attacker.calculateDamage();
        }
        else {
            target.HullPoints -= damage;
        }
        
        checkWinLoseCondition();
    }

    private void Repair(Ship targetShip, float repairPoints = 0) {
        if (repairPoints == 0) {
            targetShip.HullPoints += Mathf.Clamp(targetShip.HullPoints + targetShip.NumberOfRepairPoints, 0, targetShip.FullHullPoints);
        }
        else {
            Debug.Log("Before repair " + targetShip.HullPoints);
            targetShip.HullPoints += Mathf.Clamp(targetShip.HullPoints + repairPoints, 0, targetShip.FullHullPoints);
            Debug.Log("After repair " + targetShip.HullPoints);
            Debug.Log("Repair in % " + repairPoints / playerShip.GetComponent<Ship>().FullHullPoints);
            healthbarPlayer.GetComponent<Healthbar>().addHealth(repairPoints / playerShip.GetComponent<Ship>().FullHullPoints);
        }
    }




    private void checkWinLoseCondition() {
        if(playerShip.GetComponent<Ship>().HullPoints <= 0) {
            //win()
        }
        if(enemyShip.GetComponent<Ship>().HullPoints <= 0) {
            //lose()
        }
    }




}

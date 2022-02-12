using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class UnityEventFloat : UnityEvent<float> {
}

public class NavalCombatSystem : MonoBehaviour {
    private Ship playerShip;
    private Ship enemyShip;

    private bool playerEvading = false;

    private void Awake() {
    }
    public void AttackPlayerShip() {
        //
        //playShootingAnimation();
        if (playerEvading == false) {
            AttackShip(enemyShip, playerShip);
        }
    }

    public void AttackEnemyShip() {
        AttackShip(playerShip, enemyShip);
    }

    private void AttackShip(Ship attacker, Ship target) {
        target.HullPoints -= attacker.calculateDamage();
        Debug.Log("Enemy attacked Player and dealt " + attacker.calculateDamage() + " damage.");
        checkWinLoseCondition();
    }

    public void PlayerEvasionManeuver() {
        playerEvading = !playerEvading;
    }

    public void PlayerRepair() {
        Repair(playerShip);
    }

    private void Repair(Ship targetShip) {
        targetShip.HullPoints += Mathf.Clamp(targetShip.HullPoints + targetShip.NumberOfRepairPoints, 0, targetShip.FullHullPoints);
    }




    private void checkWinLoseCondition() {
        if(playerShip.HullPoints <= 0) {
            //win()
        }
        if(enemyShip.HullPoints <= 0) {
            //lose()
        }
    }




}

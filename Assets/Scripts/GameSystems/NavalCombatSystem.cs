using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavalCombatSystem : MonoBehaviour {
    private Ship playerShip;
    private Ship enemyShip;

    private void AttackShip(Ship attacker, Ship target) {
        target.HullPoints -= attacker.calculateDamage();
        checkWinLoseCondition();
    }

    private void evade() {
        //evading
    }

    private void repair() {
        //repairing
    }

    private void angage() {
        //angaging
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

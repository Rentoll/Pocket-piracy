using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardingCombat : MonoBehaviour {

    [SerializeField]
    private Pirate playerCaptain;
    [SerializeField]
    private Pirate enemyCaptain;
    [SerializeField]
    private GameObject playerCaptainGameObject;
    [SerializeField]
    private GameObject enemyCaptainGameObject;
    [SerializeField]
    private AnimationMasterController controller;

    [SerializeField]
    private ParticleSystem bloodParticle;

    [SerializeField]
    private GameObject healthbarPlayer;
    [SerializeField]
    private GameObject healthbarEnemy;


    private void Awake() {
        SaberAttackMinigame.OnSaberHit.AddListener(PlayerSaberAttack);
        BoardingBattleAI.OnAIAction.AddListener(AIAction);
        SaberBlockMinigame.OnSaberBlock.AddListener(PlayerBlock);
        EvasionMinigame.OnEvasion.AddListener(PlayerEvade);
        PistolAttackMinigame.OnPistolHit.AddListener(AttackWithPistol);
        playerCaptain.FullHealthPoints = playerCaptain.HealthPoints;
        enemyCaptain.FullHealthPoints = enemyCaptain.HealthPoints;
    }

    private void FixedUpdate() {
        if (playerCaptain.HealthPoints <= 0) {
            SceneManager.LoadScene("LoseScreen");
        }
        else if (enemyCaptain.HealthPoints <= 0) {
            SceneManager.LoadScene("WinScreen");
        }
    }

    private void AIAction(string action) {
        controller.PlayAnimation("enemy", action);
        switch(action) {
            case "Pirate_Sword_Attack":
                EnemySaberAttack();
                break;
            case "Pirate_Pistol_Attack":
                EnemyPistolAttack();
                break;
            default:
                break;
        }
    }

    private void PlayerSaberAttack(float damageMultiplier) {
        controller.PlayAnimation("player", "Pirate_Sword_Attack");
        enemyCaptain.HealthPoints -= playerCaptain.SaberDamage * damageMultiplier;
        Debug.Log("Player attacked with saber. Enemy health = " + enemyCaptain.HealthPoints);
        ParticleSystem blood = Instantiate(bloodParticle, enemyCaptainGameObject.transform);
        blood.Play();
        healthbarEnemy.GetComponent<Healthbar>().deliverDamage(playerCaptain.SaberDamage * damageMultiplier / enemyCaptain.FullHealthPoints);
    }
    private void AttackWithPistol() {
        controller.PlayAnimation("player", "Pirate_Pistol_Attack");
        enemyCaptain.HealthPoints -= playerCaptain.PistolAttackDamage;
        Debug.Log("Player attacked with pistol. Enemy health = " + enemyCaptain.HealthPoints);
        ParticleSystem blood = Instantiate(bloodParticle, enemyCaptainGameObject.transform);
        blood.Play();
        healthbarEnemy.GetComponent<Healthbar>().deliverDamage(playerCaptain.PistolAttackDamage / enemyCaptain.FullHealthPoints);
    }

    private void PlayerEvade(bool status) {
        playerCaptain.Evasion = status;
        if (status) {
            controller.PlayAnimation("player", "Pirate_Evasion");
        }
    }

    private void PlayerBlock(bool status) {
        playerCaptain.SaberBlock = status;
        if (status) {
            controller.PlayAnimation("player", "Pirate_Sword_Block");
        }
    }

    private void EnemySaberAttack() {
        if(playerCaptain.SaberBlock == false) {
            playerCaptain.HealthPoints -= enemyCaptain.SaberDamage;
            Debug.Log("Enemy attacked with saber. Player health = " + playerCaptain.HealthPoints);
            ParticleSystem blood = Instantiate(bloodParticle, playerCaptainGameObject.transform);
            blood.Play();
            healthbarPlayer.GetComponent<Healthbar>().deliverDamage(enemyCaptain.SaberDamage / playerCaptain.FullHealthPoints);
        }
    }

    private void EnemyPistolAttack() {
        if (playerCaptain.Evasion == false) {
            playerCaptain.HealthPoints -= enemyCaptain.PistolAttackDamage;
            Debug.Log("Enemy attacked with saber. Player health = " + playerCaptain.HealthPoints);
            ParticleSystem blood = Instantiate(bloodParticle, playerCaptainGameObject.transform);
            blood.Play();
            healthbarPlayer.GetComponent<Healthbar>().deliverDamage(enemyCaptain.SaberDamage / playerCaptain.FullHealthPoints);
        }
    }


}

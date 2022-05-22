using System.Collections;
using UnityEngine.Events;
using UnityEngine;
/// <summary>
/// AI for enemy ship during naval combat
/// </summary>
public class SeaBattleAI : MonoBehaviour {

    public static UnityEvent OnAiAttack = new UnityEvent();

    [SerializeField]
    private GameObject enemyShipGameObject;
    [SerializeField]
    private GameObject attackIndicator;
    [SerializeField]
    private GameObject attackIndicatorMask;
    [SerializeField]
    private ParticleSystem shootingSmoke;

    public UnityEvent OnAttack;

    private float actionCooldownTime;
    private Ship enemyShip;

    private void Awake() {
        actionCooldownTime = Time.deltaTime;
        attackIndicator.SetActive(false);
        enemyShip = enemyShipGameObject.GetComponent<Ship>();
    }

    private void Update() {
        ProcessAI();
    }

    private void ProcessAI() {
        if (Time.time + enemyShip.CannonReloadSpeed > actionCooldownTime) {
            actionCooldownTime = Time.time + enemyShip.CannonReloadSpeed * 2;
            StartCoroutine(DrawAttackIndicator(attackIndicatorMask));
        }
    }

    private IEnumerator DrawAttackIndicator(GameObject mask, float duration = 5f) {

        Debug.Log("Started drawing attack indicator");

        mask.transform.localPosition = Vector3.zero;

        attackIndicator.SetActive(true);
        float cooldownEndTime = Time.time + duration;
        float buffTime = Time.time;
        float speed = 3f;

        float maskYpos = -11;

        while ((buffTime += Time.deltaTime) <= cooldownEndTime && Mathf.Abs(mask.transform.localPosition.y) < Mathf.Abs(maskYpos)) {
            mask.transform.localPosition = Vector3.MoveTowards(mask.transform.localPosition, new Vector3(mask.transform.localPosition.x, maskYpos, mask.transform.localPosition.z), Time.deltaTime * speed);
            yield return true;
        }
        attackIndicator.SetActive(false);
        ParticleSystem smoke = Instantiate(shootingSmoke);
        shootingSmoke.Play();
        OnAiAttack?.Invoke();
    }

}

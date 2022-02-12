using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class Minigame : MonoBehaviour {
    [SerializeField]
    protected GameObject minigameGroup;
    [SerializeField]
    protected GameObject countdownBar;
    public UnityEventFloat NavalCombat;

    protected float successRate = 0;
    protected float minigameTimeInSeconds = 10;//seconds

    public abstract void startMinigame();
    protected abstract void checkTargetsCondition();
    protected abstract IEnumerator countdownToEnd();
    protected abstract float minigameResult();
    protected abstract void endMinigame(); 


}

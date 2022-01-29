using System.Collections;
using UnityEngine;

public abstract class Minigame : MonoBehaviour {
    [SerializeField]
    protected GameObject minigameGroup;
    [SerializeField]
    protected GameObject countdownBar;

    private float MinigameTime = 10;

    protected float successRate = 0;
    protected float minigameTimeInSeconds = 10;//seconds

    public abstract void startMinigame();
    protected abstract void checkTargetsCondition();
    protected abstract IEnumerator countdownToEnd();
    protected abstract float minigameResult();
    protected abstract void endMinigame(); 


}

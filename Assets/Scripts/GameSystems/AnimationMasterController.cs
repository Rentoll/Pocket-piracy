using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMasterController : MonoBehaviour {
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Animator enemyAnimator;
    private void Update() {
        //PlayAnimation("player", "Pirate_Sword_Attack");
    }
    /// <summary>
    /// Plays animation of target
    /// </summary>
    /// <param name="target"></param>
    /// <param name="animation"> name of animation</param>
    public void PlayAnimation(string target, string animation) {
        if(target == "Player" || target == "player") {
            PlayTargetAnimation(playerAnimator, animation);
        } 
        else if (target == "Enemy" || target == "enemy") {
            PlayTargetAnimation(enemyAnimator, animation);
        }
        else {
            Debug.Log("Wrong Target");
        }
    }

    private void PlayTargetAnimation(Animator animator, string animation) {
        animator.Play(animation);
        Debug.Log(animator.name + " plays animation: " + animation);
    }
}

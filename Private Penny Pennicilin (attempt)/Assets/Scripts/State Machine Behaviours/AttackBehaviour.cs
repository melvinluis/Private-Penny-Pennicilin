using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class AttackBehaviour : StateMachineBehaviour {

    /*
     * Check for 3 things when attacking:
     * - if attack button is released
     * - if player is grounded while still attacking
     * - if player is damaged
     * note: player cannot move or jump while attacking, but can jump + attack (attack in mid-air)
     * */

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (Game.playerController.CheckGrounded()) Game.rb2d.velocity = Vector2.zero;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        // exit attacking
        if (!Input.GetButton("Square")) {
            // Game.anim.Play("playerIdle");
            // manually transition because simply changing "attacking" to false delays the transition until after the attack animation is finished, which introduces a noticeable delay
            Game.anim.SetBool("attacking", false); 
        }

        // can still dash
        if (Input.GetButtonDown("Circle")) {
            if (Game.playerController.CheckGrounded()) Game.anim.Play("playerDash_ground");
            else Game.anim.Play("playerDash_midair");
        }
    }
}

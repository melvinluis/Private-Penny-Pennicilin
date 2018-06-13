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
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        // not allowed to move!
        if (Game.playerController.CheckGrounded()) Game.rb2d.velocity = new Vector2(0, Game.rb2d.velocity.y);

        // exit attacking
        if (!Input.GetButton("Square")) {
            Game.anim.SetBool("attacking", false);
        }

        // take damage

        // set grounded
        Game.anim.SetBool("grounded", Game.playerController.CheckGrounded());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class JumpingStates : StateMachineBehaviour {

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Game.anim.ResetTrigger("jumpTrigger");
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (Input.GetButtonDown("Cross")) {
            // double jump if I wanted it
            Game.playerController.Jump();
            Game.anim.Play("playerJump_Entry"); // manually go to jumpEntry because no transition from jump_loop to jump_entry and this is only relevant for double jumping
        }

        //Game.anim.SetBool("grounded", Game.playerController.CheckGrounded()); // always check if the player has landed
    }
}

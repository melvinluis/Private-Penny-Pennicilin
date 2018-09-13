using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class GroundedStates : StateMachineBehaviour {

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (Input.GetButton("Cross")) {
            // jump
            Game.playerController.Jump();
            Game.anim.SetTrigger("jumpTrigger");
            //Game.anim.SetBool("grounded", false);
        }

        // transition between running and idle states here depending on left stick input
        Game.anim.SetBool("running", Input.GetAxisRaw(Game.horizontalAxis) == 0 ? false : true);
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class DashBehaviour : StateMachineBehaviour {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Game.playerController.Dash();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Game.anim.ResetTrigger("dashTrigger");
    }
}

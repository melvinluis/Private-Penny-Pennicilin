using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class BaseLayerBehaviour : StateMachineBehaviour {
    private bool wasPressed = false;
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // switch weapon
        if (Input.GetButton("Triangle") && !wasPressed) {
            wasPressed = true;
            Game.playerController.SwitchWeapon();
            Game.anim.SetInteger("weaponSelected", Game.playerController.weaponSelected);
            Game.anim.SetInteger("weaponLevel", Game.playerController.weaponLevel[Game.playerController.weaponSelected]);
            Game.anim.Play("Attack Logic");
        }
        if (!Input.GetButton("Triangle") && wasPressed) {
            wasPressed = false;
        }
    }

	// OnStateExit is called before OnStateExit is called on any state inside this state machine
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateMove is called before OnStateMove is called on any state inside this state machine
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called before OnStateIK is called on any state inside this state machine
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMachineEnter is called when entering a statemachine via its Entry Node
	//override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
	//
	//}

	// OnStateMachineExit is called when exiting a statemachine via its Exit Node
	//override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
	//
	//}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class BaseLayerBehaviour : StateMachineBehaviour {
    private bool wasPressed = false;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // switch weapon
        if (Input.GetButton("Triangle") && !wasPressed) {
            wasPressed = true;
            Game.playerController.SwitchWeapon();
            Game.anim.SetInteger("weaponSelected", Game.playerController.weaponSelected);
            Game.anim.SetInteger("weaponLevel", Game.playerController.weaponLevel[Game.playerController.weaponSelected]);
            Game.anim.Play("Attack Logic"); // switch weapon while attacking
        }
        if (!Input.GetButton("Triangle") && wasPressed) {
            wasPressed = false;
        }


#if UNITY_EDITOR
        if (Input.GetButtonDown("L1")) {
            Game.playerController.UpgradeWeapon(Game.anim.GetInteger("weaponSelected"));
            Game.anim.SetInteger("weaponLevel", Game.playerController.weaponLevel[Game.playerController.weaponSelected]);
        }
#endif
    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}
}

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
        }
        if (!Input.GetButton("Triangle") && wasPressed) {
            wasPressed = false;
        }

        // flip Penny depending on movement speed
        if (Input.GetAxisRaw(Game.horizontalAxis) == 1)
            Game.rb2d.transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (Input.GetAxisRaw(Game.horizontalAxis) == -1) {
            Game.rb2d.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        // set grounded
        Game.anim.SetBool("grounded", Game.playerController.CheckGrounded());

#if UNITY_EDITOR
        if (Input.GetButtonDown("L1")) {
            Game.playerController.UpgradeWeapon();
        }
#endif
    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class RangedAttackBehaviour : StateMachineBehaviour {
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // moves slower while attacking in ranged mode
        Game.playerController.playerVelocity = Input.GetAxisRaw(Game.horizontalAxis) * Game.moveSpeedWhileAttacking;
        Game.rb2d.velocity = new Vector2(Game.playerController.playerVelocity, Game.rb2d.velocity.y);
    }
}

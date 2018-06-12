using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class MovingStates : StateMachineBehaviour {

    private Vector2 move;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // left stick input
        if (Input.GetAxisRaw("LeftStickX") == 0) {
            Game.rb2d.velocity = new Vector2(0, Game.rb2d.velocity.y);
        }
        else {
            // input from left stick, animate
            move.x = Input.GetAxisRaw("LeftStickX") * Game.moveSpeed;
            float moveSpeedAbs = Mathf.Abs(move.x);

            // flip sprite depending on movement speed (last sprite state will be kept)
            if (moveSpeedAbs > 0.01f) {
                if (move.x < 0.01f)
                    Game.sr.flipX = false;
                else if (move.x > 0.01f)
                    Game.sr.flipX = true;
            }

            // set rigidbody velocity
            Game.rb2d.velocity = new Vector2(move.x, Game.rb2d.velocity.y);
        }

        // dash
        if (Input.GetButtonDown("Circle")) {
            Game.playerController.Dash();
            Game.anim.SetTrigger("dashTrigger");
        }

        // animator parameters
        Game.anim.SetBool("grounded", Game.playerController.CheckGrounded());
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

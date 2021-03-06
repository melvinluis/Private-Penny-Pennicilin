﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class MovingStates : StateMachineBehaviour {
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //reset firing timer
        Game.knivesTimer = Game.knivesInterval + .1f; // can be exploited by tapping rapidly if the timer was reset in this state, should be tracked elsewhere
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // set rigidbody velocity
        Game.playerController.playerVelocity = Input.GetAxisRaw(Game.horizontalAxis) * Game.moveSpeed;
        Game.rb2d.velocity = new Vector2(Game.playerController.playerVelocity, Game.rb2d.velocity.y);

        // dash
        if (Input.GetButton("Circle")) {
            Game.anim.SetTrigger("dashTrigger");
        }

        // attack
        if (Input.GetButton("Square")) {
            Game.anim.Play("Attack Logic");
            Game.anim.SetBool("attacking", true);
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

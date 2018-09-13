using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class PlayerController : MonoBehaviour {
    
    public Transform[] groundCheck; // transform locations for checking grounded
    public LayerMask groundMask; // layer for checking against grounded or not
    public float groundRadius; // radius of circle around groundCheck for checking grounded or not
    public float playerVelocity; // current player velocity

    private bool grounded = false; // true if player is on the ground

    public int[] weaponLevel; // weapon upgrade status, checked when switching weapons and for switching to animations
    public int weaponSelected; // which weapon is currently selected

    // references
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public Animator anim;

    void Awake () {
        playerVelocity = 0;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    void Start() {
        weaponLevel = new int[] { 0, 0, 0 }; // max lv2 per weapon; -1 is locked weapon
        weaponSelected = 0; // default weapon
    }

    public bool CheckGrounded() {
        // returns true if player is grounded
        for (int i = 0; i < groundCheck.Length; i++) {
            grounded = Physics2D.OverlapCircle(groundCheck[i].position, groundRadius, groundMask);
            if (grounded) return true;
        }
        return false;
    }

    public void Jump() {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Game.jumpForce);
    }

    public void Dash() {
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        rb2d.AddForce(rb2d.transform.rotation.y == 0 ? Game.dashForce : -Game.dashForce);
    }

    public void SwitchWeapon() {
        while (weaponLevel[weaponSelected = weaponSelected + 1 > 2 ? 0 : weaponSelected + 1] == -1);
        anim.SetInteger("weaponSelected", Game.playerController.weaponSelected);
        anim.SetInteger("weaponLevel", Game.playerController.weaponLevel[Game.playerController.weaponSelected]);
        anim.Play("Attack Logic"); // switch weapon while attacking
    }

    public void UpgradeWeapon() {
        int plusone = weaponLevel[weaponSelected] + 1;
        weaponLevel[weaponSelected] = plusone > 2 ? 0 : plusone; // reset to 0 for debugging only
        anim.SetInteger("weaponLevel", Game.playerController.weaponLevel[weaponSelected]);
    }

    public bool IsFacingRight() {
        return rb2d.transform.rotation.y == 0;
    }
}
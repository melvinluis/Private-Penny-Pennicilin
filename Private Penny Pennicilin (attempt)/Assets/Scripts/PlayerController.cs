using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class PlayerController : MonoBehaviour {
    
    public Transform[] groundCheck; // transform locations for checking grounded
    public LayerMask groundMask; // layer for checking against grounded or not
    public float groundRadius; // radius of circle around groundCheck for checking grounded or not

    private bool grounded = false; // true if player is on the ground

    public int[] weaponLevel; // weapon upgrade status, checked when switching weapons and for switching to animations
    public int weaponSelected; // which weapon is currently selected

    // references
    [HideInInspector] public Rigidbody2D rb2d;
    [HideInInspector] public Animator anim;
    [HideInInspector] public SpriteRenderer sr;

    void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>(); // flipX true = facing right
	}

    private void Start() {
        weaponLevel = new int[] { 0, 0, 0 }; // max lv2 per weapon; -1 is locked weapon
        //weaponLevel = new int[] { 0, -1, -1 }; 
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
        rb2d.AddForce(Game.jumpForce);
    }

    public void Dash() {
        rb2d.AddForce(sr.flipX ? Game.dashForce : -Game.dashForce);
    }

    public void SwitchWeapon() {
        while (weaponLevel[weaponSelected = weaponSelected + 1 > 2 ? 0 : weaponSelected + 1] == -1);
    }

    public void UpgradeWeapon(int weapon) {
        weaponLevel[weapon]++;
    }
}
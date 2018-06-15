using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeProjectile : MonoBehaviour {
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    public LayerMask collisionMask; // for damaging enemies and hitting level bounds
	void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}

    public void SetVelocity(Vector2 vel) {
        // need this 'cause gotta determine sprite orientation first
        if (vel.x < 0) sr.flipX = true;
        rb2d.velocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // damage enemies here

        // if (collision.transform.tag == "LevelBounds")
        // if it goes beyond the screen, eliminate it
        // there are levelBounds colliders, right? use those
        // should use an object pool

        rb2d.velocity = Vector2.zero;
        // transform.position = some position off-screen
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class KnifeProjectile : MonoBehaviour {
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    public LayerMask collisionMask; // for damaging enemies and hitting level bounds
	void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}

    private void Update() {
        CheckifVisible();
    }

    public void SetVelocity(Vector2 vel) {
        // this is when the gameObject is spawned, so might as well enable it here
        gameObject.SetActive(true);
        rb2d.velocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // damage enemies here

        ResetObject();
    }

    private void CheckifVisible() {
        // checks if the projectiles are still visible by the scene camera
        float x = Game.gameCamera.WorldToViewportPoint(transform.position).x;
        float y = Game.gameCamera.WorldToViewportPoint(transform.position).y;
        
        if (x > 1 || x < 0 || y > 1 || y < 0) {
            ResetObject();
        }
    }

    private void ResetObject() {
        // go back to the pool, so to speak
        //transform.position = Game.knivesPool.transform.position;
        SetVelocity(Vector2.zero);
        gameObject.SetActive(false);
    }
}

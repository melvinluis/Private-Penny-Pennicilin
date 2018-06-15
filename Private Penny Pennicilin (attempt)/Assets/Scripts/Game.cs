using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global {
    public class Game : MonoBehaviour {
        private static GameObject penny = GameObject.Find("Penny");
        public static PlayerController playerController = penny.GetComponent<PlayerController>();
        public static SpriteRenderer sr = playerController.sr;
        public static Rigidbody2D rb2d = playerController.rb2d;
        public static Animator anim = playerController.anim;

        public static Vector2 jumpForce = new Vector2(0, 300f);
        public static Vector2 dashForce = new Vector2(500f, 0);
        public static Transform projectileSpawnPoint_R = penny.transform.GetChild(2).transform; // where projectiles spawn
        public static Transform projectileSpawnPoint_L = penny.transform.GetChild(3).transform; // where projectiles spawn
        public const float moveSpeed = 3f;

        public static float knivesInterval = .15f; // time between next knife spawn / atkspd
        public static Vector2 knivesVelocity = new Vector2(7f, 0);
        public static float knivesTimer = knivesInterval + .1f; // so projectile immediately spawns upon press
    }
}


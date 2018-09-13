using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global {
    public class Game : MonoBehaviour {
        public static Camera gameCamera = GameObject.Find("DeadzoneCamera").GetComponent<Camera>();

        private static GameObject penny = GameObject.Find("Penny");
        public static PlayerController playerController = penny.GetComponent<PlayerController>();
        public static Rigidbody2D rb2d = playerController.rb2d;
        public static Animator anim = playerController.anim;

        public static Vector2 jumpForce = new Vector2(0, 300f);
        public static Vector2 dashForce = new Vector2(500f, 0);
        public static Transform projectileSpawnPoint = penny.transform.Find("projectileSpawnPoint"); // where projectiles spawn
        public const float moveSpeed = 3.75f;
        public const float moveSpeedWhileAttacking = .75f;
        public static string horizontalAxis = "DPadX";
        //public static string horizontalAxis = "LeftStickX";

        public static float knivesInterval = .3f; // time between next knife spawn / atkspd
        public static Vector2 knivesVelocity = new Vector2(7f, 0);
        public static float knivesTimer = knivesInterval + .1f; // so projectile immediately spawns upon press

        public static GameObject knivesPool = GameObject.Find("KnivesPool");
        public static Transform knives0 = knivesPool.transform.GetChild(0).transform;
        public static Transform knives1 = knivesPool.transform.GetChild(1).transform;
        public static Transform knives2 = knivesPool.transform.GetChild(2).transform;
        public static int maxKnivesInPool = knives0.childCount; // they all should have the same number of knives
    }
}


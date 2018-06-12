using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global {
    public class Game : MonoBehaviour {
        public static PlayerController playerController = GameObject.Find("Penny").GetComponent<PlayerController>();
        public static SpriteRenderer sr = playerController.sr;
        public static Rigidbody2D rb2d = playerController.rb2d;
        public static Animator anim = playerController.anim;

        public static Vector2 jumpForce = new Vector2(0, 300f);
        public static Vector2 dashForce = new Vector2(500f, 0);
        public const float moveSpeed = 3f;
    }
}


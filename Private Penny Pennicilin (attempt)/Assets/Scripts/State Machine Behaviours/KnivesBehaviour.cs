using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class KnivesBehaviour : StateMachineBehaviour {
    public GameObject lv0, lv1, lv2; // prefabs

    // just for reference
    private GameObject temp;
    private Transform whatToSpawn;
    private int currentIndex = 0;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Game.knivesTimer += Time.deltaTime;

        if(Game.knivesTimer > Game.knivesInterval) {
            Game.knivesTimer = 0;
            Spawn();
        }
    }

    private void Spawn() {
        // makes the projectile
        // we're sure that if the state machine enters this state, it's the knife weapon that's selected
        switch (Game.anim.GetInteger("weaponLevel")) {
            case 0:
                whatToSpawn = Game.knives0;
                break;
            case 1:
                whatToSpawn = Game.knives1;
                break;
            case 2:
                whatToSpawn = Game.knives2;
                break;
        }

        temp = whatToSpawn.GetChild(currentIndex).gameObject;
        temp.transform.position = Game.projectileSpawnPoint.position;
        if (Game.playerController.IsFacingRight()) {
            temp.GetComponent<KnifeProjectile>().SetVelocity(Game.knivesVelocity);
            temp.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else {
            temp.GetComponent<KnifeProjectile>().SetVelocity(-Game.knivesVelocity);
            temp.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        currentIndex = currentIndex + 1 == Game.maxKnivesInPool ? 0 : currentIndex + 1;
    }
}

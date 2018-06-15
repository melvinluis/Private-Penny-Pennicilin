using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class KnivesBehaviour : StateMachineBehaviour {
    public GameObject lv0, lv1, lv2; // prefabs

    // just for reference
    private GameObject temp;
    private GameObject whatToSpawn;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Game.knivesTimer += Time.deltaTime;

        if(Game.knivesTimer > Game.knivesInterval) {
            Game.knivesTimer = 0;
            Spawn();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
    }

    private void Spawn() {
        // makes the projectile
        // we're sure that if the state machine enters this state, it's the knife weapon that's selected
        switch (Game.anim.GetInteger("weaponLevel")) {
            case 0:
                whatToSpawn = lv0;
                break;
            case 1:
                whatToSpawn = lv1;
                break;
            case 2:
                whatToSpawn = lv2;
                break;
        }

        if (Game.sr.flipX) {
            temp = Instantiate(whatToSpawn, Game.projectileSpawnPoint_R.position, Quaternion.identity);
            temp.GetComponent<KnifeProjectile>().SetVelocity(Game.knivesVelocity);
        }
        else {
            temp = Instantiate(whatToSpawn, Game.projectileSpawnPoint_L.position, Quaternion.identity);
            temp.GetComponent<KnifeProjectile>().SetVelocity(-Game.knivesVelocity);
        }
    }
}

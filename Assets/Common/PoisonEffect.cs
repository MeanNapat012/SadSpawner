using System.Collections;
using System.Collections.Generic;
using SuperGame.DodgeIt;
using UnityEngine;

namespace SuperGame{
public class PoisonEffect : MonoBehaviour
{
    Player player;
    void OnTriggerEnter2D(Collider2D col)
        {
            if(col.tag == "Player"){
                // EffectPois();
            }
            Destroy(gameObject);
        }
    // public void EffectPois(){
    //     player.moveSpeed = -20f;
    // }
}
}
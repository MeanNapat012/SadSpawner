using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperGame{
public class HealEffect : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D col)
        {
            if(col.tag == "Player")
            {
                col.gameObject.GetComponent<Health>().PlayerHeal();
            }
            Destroy(gameObject);
        }
}
}
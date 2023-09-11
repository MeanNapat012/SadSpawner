using System.Collections;
using System.Collections.Generic;
using PhEngine.Core;
using SuperGame.DodgeIt;
using Unity.VisualScripting;
using UnityEngine;

namespace SuperGame
{
    
    public class HealthItem : MonoBehaviour
    {
        [SerializeField] float speed = 3f;
        public Player player;
         void Update()
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
        
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.tag == "Player")
            {
                col.gameObject.GetComponent<Player>().PlayerHeal();
                
            }
            Destroy(gameObject);
        } 
    }
    
}
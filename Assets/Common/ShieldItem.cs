using System.Collections;
using System.Collections.Generic;
using PhEngine.Core;
using SuperGame.DodgeIt;
using Unity.VisualScripting;
using UnityEngine;

namespace SuperGame
{
    
    public class ShieldItem : MonoBehaviour
    {
        [SerializeField] float speed = 3f;
        [SerializeField] float immunityDuration = 2.0f;

        public Player player;
        public bool IsImmune;
         void Update()
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
        
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.tag == "Player")
            {
                
            }
            Destroy(gameObject);
        }

        IEnumerable Immune()
        {

                IsImmune = true;
                Debug.Log("Immune");
                yield return new WaitForSeconds(immunityDuration);
                IsImmune = false;
        }
    }
    
}

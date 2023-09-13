using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperGame.SubwaySurfer2D;
using TMPro;

namespace SuperGame
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int MaxHealth = 5;
        public int CurrentHealth => currentHealth;
        [SerializeField] int currentHealth = 5;
        [SerializeField] SpriteRenderer renderer;
        [SerializeField] float timenoDamage = 0.5f;
        [SerializeField] bool NoDamage = false;

        [Header("UI")]
        [SerializeField] TMP_Text healthText;

        [SerializeField] PlayerMovement move;

        void Start()
        {
            currentHealth = MaxHealth;
            RefreshHealth();        
        }

        
        void OnCollisionEnter2D(Collision2D other) //Subway
        {
            if (other.gameObject.tag == "Train")
            {
                Vector2 collisionDirection = other.transform.position - transform.position;

                if (Mathf.Abs(collisionDirection.x) > Mathf.Abs(collisionDirection.y))
                {
                    if(move.currentLine == 1 || move.currentLine == -1) 
                    {
                        move.targetPosition = move.targetmiddle.position;
                        move.currentLine= 0;
                    }

                    else if(move.left == true && move.currentLine == 0)
                    {
                        move.left = false;
                        move.targetPosition = move.targetleft.position;
                        move.currentLine = -1; 
                    }

                    else if(move.right == true && move.currentLine == 0)
                    {
                        move.right = false;
                        move.targetPosition = move.targetright.position;
                        move.currentLine = 1;
                    }
                    TakeDamage();
                }
                else
                {
                    GameManager.Instance.Lose();
                }
            }
        }

        public void TakeDamage()
        {
            if(currentHealth <= 0) return;
            if(NoDamage == false){
                currentHealth--;
            }
            DamageEffectPlayer.Instance.PlayOn(renderer);
            RefreshHealth(); 

            if(currentHealth <= 0) 
            {
                GameManager.Instance.Lose();
            }
        }

        void RefreshHealth()
        {
            healthText.text = "Health : " + currentHealth;
        }

        public void PlayerShield(){
           NoDamage = true;
           Debug.Log("NoDamge");
           }
           void Update(){
            if(NoDamage == true){
            timenoDamage -= Time.deltaTime;

                if(timenoDamage <= 0){
                Debug.Log("Damage");
                timenoDamage = 0.5f;
                NoDamage = false;
            }
           }
           }
        public void PlayerHeal(){
            if (currentHealth >= 5)
                return;

            currentHealth++;
            RefreshHealth();
        }
       
}
}
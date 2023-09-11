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
        [SerializeField] int currentHealth = 5;
        [SerializeField] SpriteRenderer renderer;

        [Header("UI")]
        [SerializeField] TMP_Text healthText;

        [SerializeField] PlayerMovement move;

        void Start()
        {
            currentHealth = MaxHealth;
            RefreshHealth();        
        }

        void Upate()
        {
            if(currentHealth <= 0)
            {
                //ให้มึงลองหาที่ทำให้เกมมันจบ ลองดูนะ ไอเปา
            }
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
            currentHealth--;
            DamageEffectPlayer.Instance.PlayOn(renderer);
            RefreshHealth(); 
        }

        void RefreshHealth()
        {
            healthText.text = "Health : " + currentHealth;
        }

    }

}
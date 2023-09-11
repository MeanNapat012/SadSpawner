using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
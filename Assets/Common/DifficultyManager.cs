using System.Collections;
using System.Collections.Generic;
using PhEngine.Core;
using UnityEngine;
using UnityEngine.AI;

namespace  SuperGame
{
    public class DifficultyManager : Singleton<DifficultyManager>
    {
        public int DifficultyLevel => difficultyLevel;
        public int HealthPotionSpawnDelay => healthPotionSpawnDelay;
        public int ArmorSpawnDelay => armorSpawnDelay;
        public int PoisonSpawnDelay => poisonSpawnDelay;

        [SerializeField] int difficultyLevel;
        [SerializeField] GameObject difficultyUI;
        [SerializeField] int healthPotionSpawnDelay;
        [SerializeField] int armorSpawnDelay;
        [SerializeField] int poisonSpawnDelay;
        
        protected override void InitAfterAwake()
        {
            difficultyUI.SetActive(true);
        }

        public void SelectDifficultyLevel(int value)
        {
            difficultyLevel = value;

            if (value == 1)
            {
                healthPotionSpawnDelay = 2;
                armorSpawnDelay = 2;
            }

            if (value == 2)
            {
                healthPotionSpawnDelay = 1;
                armorSpawnDelay = 1;
                poisonSpawnDelay = 1;
            }

            if (value == 3)
            {
                poisonSpawnDelay = 2;
            }

            difficultyUI.SetActive(false);
            GameManager.Instance.StartLevel();
        }
    }
}
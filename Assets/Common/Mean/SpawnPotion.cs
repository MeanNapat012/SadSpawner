using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using PhEngine.Core;

namespace  SuperGame
{
    public class SpawnPotion : Singleton<SpawnPotion>
    {
        public GameObject HealthPotion;
        public GameObject Armor;
        public GameObject Poison;
        [SerializeField] float targetDelay = 3f;
        [SerializeField] float randomOffset = 5f ;
    
        float currentDelay;
        protected override void InitAfterAwake()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (DifficultyManager.Instance.DifficultyLevel == 1)
            {
                SpawnHealthpotion();
                SpawnArmor();
            }

            if (DifficultyManager.Instance.DifficultyLevel == 2)
            {
                SpawnHealthpotion();
                SpawnArmor();
                SpawnPoison();
            }

            if (DifficultyManager.Instance.DifficultyLevel == 3)
            {
                SpawnPoison();
            }
        }

        void SpawnHealthpotion()
        {
            if (currentDelay > 0)
            {
                currentDelay -= Time.deltaTime;
            }
            else
            {
                //int randomNum = Random.Range(0,HealthPotion.Length); // สุ่มขวดยาที่จะออกมา
                var newPotion = Instantiate(HealthPotion, GetRandomSpawnPotion(), Quaternion.identity); //Spawn ยาออกมา
                currentDelay = targetDelay / DifficultyManager.Instance.HealthPotionSpawnDelay;
            }
        }

        void SpawnArmor()
        {
            if (currentDelay > 0)
            {
                currentDelay -= Time.deltaTime;
            }
            else
            {
                //int randomNum = Random.Range(0,HealthPotion.Length); // สุ่มขวดยาที่จะออกมา
                var newPotion = Instantiate(Armor, GetRandomSpawnPotion(), Quaternion.identity); //Spawn ยาออกมา
                currentDelay = targetDelay / DifficultyManager.Instance.ArmorSpawnDelay;
            }
        }

        void SpawnPoison()
        {
            if (currentDelay > 0)
            {
                currentDelay -= Time.deltaTime;
            }
            else
            {
                //int randomNum = Random.Range(0,HealthPotion.Length); // สุ่มขวดยาที่จะออกมา
                var newPotion = Instantiate(Poison, GetRandomSpawnPotion(), Quaternion.identity); //Spawn ยาออกมา
                currentDelay = targetDelay / DifficultyManager.Instance.PoisonSpawnDelay;
            }
        }

        Vector3 GetRandomSpawnPotion()
        {
            return new Vector3(transform.position.x + Random.Range(-randomOffset, randomOffset), transform.position.y, transform.position.z);
     
        }
    }

}

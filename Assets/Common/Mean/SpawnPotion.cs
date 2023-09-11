using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using PhEngine.Core;

namespace  SuperGame
{
    public class SpawnPotion : Singleton<SpawnPotion>
    {
        public GameObject[] Potion;
        [SerializeField] float targetDelay = 3f;
        [SerializeField] float randomOffset = 5f;
    
        float currentDelay;
        protected override void InitAfterAwake()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (currentDelay > 0)
            {
                currentDelay -= Time.deltaTime;
            }
            else
            {
                int randomNum = Random.Range(0,3); // สุ่มขวดยาที่จะออกมา
                var newPotion = Instantiate(Potion[randomNum], GetRandomSpawnPotion(), Quaternion.identity); //Spawn ยาออกมา
                currentDelay = targetDelay / DifficultyManager.Instance.DifficultyLevel;
            }
        }

        Vector3 GetRandomSpawnPotion()
        {
            return new Vector3(transform.position.x + Random.Range(-randomOffset, randomOffset), transform.position.y, transform.position.z);
     
        }
    }

}

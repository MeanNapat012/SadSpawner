using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

namespace SuperGame.DodgeIt
{
    public class Spawner : MonoBehaviour
    {
        //public GameObject[] potion; // เก็บข้อมูลขวดยา เป็น Array
        [SerializeField] Obstacle prefab;
        [SerializeField] float targetDelay = 3f;
        [SerializeField] float randomOffset = 5f;
    
        float currentDelay;
        void Start()
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
                //int randomNum = Random.Range(0,3); // สุ่มขวดยาที่จะออกมา
                //var newPotion = Instantiate(potion[randomNum], GetRandomSpawnPosition(), Quaternion.identity); //Spawn ยาออกมา
                var newObstacle = Instantiate(prefab, GetRandomSpawnPosition(), Quaternion.identity);
                currentDelay = targetDelay / DifficultyManager.Instance.DifficultyLevel;
            }
        }

        Vector3 GetRandomSpawnPosition()
        {
            return new Vector3(transform.position.x + Random.Range(-randomOffset, randomOffset), transform.position.y, transform.position.z);
        }
    }
}

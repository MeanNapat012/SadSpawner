using System.Collections;
using UnityEngine;

namespace SuperGame.FlappyBird
{
    public class Spawner : MonoBehaviour
    {
        public GameObject pillarPrefab; // Prefab ของเสา

        // public GameObject[] Potion;
        public float gapSize = 3.0f; // ระยะห่างช่องว่างของเสา
        public float spawnInterval = 2.0f; // เวลาในการสปอนเสา
        public float destroyDistance = 10.0f; // ระยะในการทำลายเสา

        private void Start()
        {
            StartCoroutine(SpawnPillars());
        }

        private IEnumerator SpawnPillars()
        {
            while (true)
            {
                //int randomNum = Random.Range(0,3); // สุ่มขวดยาที่จะออกมา
                float randomY = Random.Range(-3f, 3.5f); //จะต๋ำและสูงสุดที่เสาจะสปอนได้
                //float randomYPotion = Random.Range(-1f, 1f);
                Vector3 bottomPillarPosition = transform.position + new Vector3(0, -gapSize + randomY, 0);
                //Vector3 PotionPosition = transform.position + new Vector3(3, -gapSize + randomYPotion,0);

                
                Instantiate(pillarPrefab, bottomPillarPosition, Quaternion.identity);
                
                
                GameObject topPillar = Instantiate(pillarPrefab,
                    transform.position + new Vector3(0, gapSize + randomY, 0), Quaternion.identity);
                topPillar.transform.localScale = new Vector3(1f, -1f, 1f);
                
                //var newPotion = Instantiate(Potion[randomNum],transform.position + new Vector3(3, gapSize + randomYPotion, 0), Quaternion.identity);
                //newPotion.transform.localScale = new Vector3(1f, -1f, 1f);
                
                yield return new WaitForSeconds(spawnInterval / DifficultyManager.Instance.DifficultyLevel);
            }
        }

        private void Update()
        {
            // คำสั่งทำลายเสา
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

            foreach (GameObject obstacle in obstacles)
            {
                if (obstacle.transform.position.x < transform.position.x - destroyDistance)
                {
                    Destroy(obstacle);
                }
            }
        }
    }
}
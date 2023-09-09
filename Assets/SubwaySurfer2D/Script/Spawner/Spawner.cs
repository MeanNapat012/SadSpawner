using System.Collections;
using UnityEngine;

namespace SuperGame.SubwaySurfer2D
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawnerLeft;
        [SerializeField] private GameObject spawnerMiddle;
        [SerializeField] private GameObject spawnerRight;
        [SerializeField] private GameObject fencePrefab;
        [SerializeField] private GameObject trainPrefab;
        [SerializeField] private GameObject coinsPrefab;
        [SerializeField] private GameObject[] Potion;
        [SerializeField] private float delay;

        void Start()
        {
            Invoke("ObstructionRandom", delay / DifficultyManager.Instance.DifficultyLevel);
        }

        void ObstructionRandom()
        {
            delay = Random.Range(0.5f, 1.5f);
            int ObstructionRandom = Random.Range(1, 4); // 3 is coins
            int PositionRandom = Random.Range(1, 4);

            GameObject selectedPrefab = null;

            switch (ObstructionRandom)
            {
                case 1:
                    selectedPrefab = fencePrefab;
                    break;
                case 2:
                    selectedPrefab = trainPrefab;
                    break;
                case 3:
                    SpawnPotion(Potion[Random.Range(0, Potion.Length)], GetSpawnPosition(PositionRandom));
                    break;
            }

            if (selectedPrefab != null)
            {
                ObstructionSpawn(selectedPrefab, GetSpawnPosition(PositionRandom));
            }

            Invoke("ObstructionRandom", delay);
        }

        void ObstructionSpawn(GameObject Obstruction, Vector3 spawnPosition)
        {
            Instantiate(Obstruction, spawnPosition, Quaternion.identity);
        }

        void SpawnPotion(GameObject Potion, Vector3 spawnPosition)
        {
            if (Potion != null)
            {
                Instantiate(Potion, spawnPosition, Quaternion.identity);
            }
        }

        Vector3 GetSpawnPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return spawnerLeft.transform.position;
                case 2:
                    return spawnerMiddle.transform.position;
                case 3:
                    return spawnerRight.transform.position;
                default:
                    return Vector3.zero;
            }
        }
    }
}

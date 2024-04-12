using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TrashCan trashCan;

    [Header("Trash Can")]
    [SerializeField] private float percentageAmountToSpawn;
    [SerializeField] private List<GameObject> trashPrefabs;
    [SerializeField] private int totalTrash;

    public float spawnAmount;

    private void Start()
    {
        spawnAmount = transform.childCount * (percentageAmountToSpawn / 100);

        for(int i = 0; i < transform.childCount; i++)
        {
            bool spawn = Random.Range(0f, 1.1f) >= 0.5f ? true : false;

            if(spawn)
            {
                int j = Random.Range(0, trashPrefabs.Count);

                Instantiate(trashPrefabs[j], transform.GetChild(i).position, Quaternion.identity, transform.GetChild(i));
                totalTrash++;

                spawnAmount--;
            }

            if(spawnAmount == 0)
            {
                break;
            }

            if(i == transform.childCount - 1 && spawnAmount > 0)
            {
                i = 0;
            }
        }

        trashCan.TotalTrash = totalTrash;
    }
}

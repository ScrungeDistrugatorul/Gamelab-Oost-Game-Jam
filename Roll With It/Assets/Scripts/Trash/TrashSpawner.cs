using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> trashPrefabs;

    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            bool spawn = Random.Range(0f, 1.1f) >= 0.5f ? true : false;

            if(spawn)
            {
                int j = Random.Range(0, trashPrefabs.Count);

                Instantiate(trashPrefabs[j], transform.GetChild(i).position, Quaternion.identity, transform.GetChild(i));
            }
        }
    }
}

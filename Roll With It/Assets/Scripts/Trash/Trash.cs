using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Trash : MonoBehaviour, IPickUpable
{
    [Header("Trash Info")]
    [SerializeField] private int trashAmount;

    public int PickUpable()
    {
        Destroy(gameObject);

        return trashAmount;
    }
}

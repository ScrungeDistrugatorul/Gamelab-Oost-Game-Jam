using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IPickUpable
{
    [Header("Trash Info")]
    [SerializeField] private int trashAmount;

    public int PickUpable()
    {
        Destroy(this);

        return trashAmount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickUp : MonoBehaviour
{
    [Header("Trash Info")]
    [SerializeField] private int currentTrashAmount;
    [SerializeField] private int maxTrashAmount;

    [Header("Pick Up Settings")]
    [SerializeField] private Transform pickUpTransform;
    [SerializeField] private float pickUpRadius;
    [SerializeField] private LayerMask pickUpLayerMask;

    [Header("Gizmos")]
    [SerializeField] private Color gizmoColor;

    private void Update()
    {
        PickUp();
    }

    private void PickUp()
    {
        Collider[] colliders = Physics.OverlapSphere(pickUpTransform.position, pickUpRadius, pickUpLayerMask);

        foreach(Collider col in colliders)
        {
            if(col.TryGetComponent<IPickUpable>(out IPickUpable pickUpable))
            {
                currentTrashAmount += pickUpable.PickUpable();
            }
        }
    }

    public int GetTrash()
    {
        return currentTrashAmount;
    }

    public void DeleteTrash()
    {
        currentTrashAmount = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(pickUpTransform.position, pickUpRadius);
    }
}

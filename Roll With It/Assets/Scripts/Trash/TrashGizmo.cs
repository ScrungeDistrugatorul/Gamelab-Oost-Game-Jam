using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGizmo : MonoBehaviour
{
    [Header("Trash Gizmos")]
    [SerializeField] private float gizmoRadius;
    [SerializeField] private Color gizmoColor;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        Gizmos.DrawSphere(transform.position, gizmoRadius);
    }
}

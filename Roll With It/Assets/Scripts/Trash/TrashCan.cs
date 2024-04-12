using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [Header("Trash Can Info")]
    [SerializeField] private int trashAmount;
    [SerializeField] private int totalTrash;
    public int TotalTrash { set => totalTrash = value; }

    [Header("Trash Can Settings")]
    [SerializeField] private Transform collectTransform;
    [SerializeField] private float canRadius;
    [SerializeField] private LayerMask trashLayer;

    [Header("Highscore")]
    [SerializeField] private int highscoreMultiplier;

    [Header("Gizmos")]
    [SerializeField] private Color gizmoColor;

    private void Update()
    {
        CollectTrash();
    }

    private void CollectTrash()
    {
        Collider[] colliders = Physics.OverlapSphere(collectTransform.position, canRadius, trashLayer);

        foreach(Collider col in colliders)
        {
            if(col.TryGetComponent<TrashPickUp>(out TrashPickUp trashPickUp))
            {
                int trash = trashPickUp.GetTrash();
                trashAmount += trash;

                GameManager.AddHighscore(trash * highscoreMultiplier);
                trashPickUp.DeleteTrash();

                if(totalTrash == trashAmount && trashAmount != 0)
                {
                    GameManager.EndGame();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(collectTransform.position, canRadius);
    }
}

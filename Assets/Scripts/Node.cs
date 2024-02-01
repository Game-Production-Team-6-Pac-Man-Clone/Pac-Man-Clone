using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask wallLayer;
    public readonly List<Vector2> availableDirections = new();
    private void Start()
    {
        this.availableDirections.Clear();

        CheckAvailableDirection(Vector2.up);
        CheckAvailableDirection(Vector2.down);
        CheckAvailableDirection(Vector2.left);
        CheckAvailableDirection(Vector2.right);
    }

    private void CheckAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, this.wallLayer);

        if (hit.collider == null){
            this.availableDirections.Add(direction);
        }
    }
}

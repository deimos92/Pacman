using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Vector2> availableDirections {  get; private set; }

    private void Start()
    {
        availableDirections = new List<Vector2>();
    }
}

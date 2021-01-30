using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory Inventory;
    public Vector2 Movement;

    private void Awake()
    {
        Movement = new Vector2();
    }
}

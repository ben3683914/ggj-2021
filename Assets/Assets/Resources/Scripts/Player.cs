using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Inventory Inventory;
    public Vector2 Movement;

    private void Awake()
    {
        Instance = this;
        Movement = new Vector2();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player Player;
    public SpriteLibrary SpriteLibrary;

    // events
    public UnityEvent InventoryChangedEvent;

    private void Awake()
    {
        Instance = this;

        // events
        InventoryChangedEvent = new UnityEvent();
    }
}
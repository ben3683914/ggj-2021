﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteLibrary : MonoBehaviour
{
    private Dictionary<Item.ItemType, SpriteDetails> Items;
    
    public Sprite None;
    public Sprite Dildo;
    public Sprite Hammer;
    public Sprite Battery;
    public Sprite Newspaper;
    public Sprite Keys;
    public Sprite Screwdriver;
    public Sprite Wallet;
    public Sprite Cat;
    
    private void Awake()
    {
        Items = new Dictionary<Item.ItemType, SpriteDetails>();
        PopulateSprites();
    }

    private void PopulateSprites()
    {
        // none
        Items.Add(Item.ItemType.None, new SpriteDetails()
        {
            Sprite = None,
            PrefabPath = "Prefabs/item.none"
        });

        // dildo
        Items.Add(Item.ItemType.Dildo, new SpriteDetails()
        {
            Sprite = Dildo,
            PrefabPath = "Prefabs/item.dildo"
        });

        // hammer
        Items.Add(Item.ItemType.Hammer, new SpriteDetails()
        {
            Sprite = Hammer,
            PrefabPath = "Prefabs/item.hammer"
        });

        // screwdriver
        Items.Add(Item.ItemType.Screwdriver, new SpriteDetails()
        {
            Sprite = Screwdriver,
            PrefabPath = "Prefabs/item.screwdriver"
        });

        // battery
        Items.Add(Item.ItemType.Battery, new SpriteDetails()
        {
            Sprite = Battery,
            PrefabPath = "Prefabs/item.battery"
        });



        // keys
        Items.Add(Item.ItemType.Keys, new SpriteDetails()
        {
            Sprite = Keys,
            PrefabPath = "Prefabs/item.keys"
        });
    }

    public SpriteDetails GetSpriteDetails(Item.ItemType type)
    {
        return Items[type];
    }
}

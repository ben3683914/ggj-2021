using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteLibrary : MonoBehaviour
{
    //public Dictionary<Item.ItemType, Sprite> Sprites;
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
        //Sprites = new Dictionary<Item.ItemType, Sprite>();
        Items = new Dictionary<Item.ItemType, SpriteDetails>();
        PopulateSprites();
    }

    private void PopulateSprites()
    {
        Items.Add(Item.ItemType.None, new SpriteDetails()
        {
            Sprite = None,
            PrefabPath = "Prefabs/item.none"
        });

        Items.Add(Item.ItemType.Dildo, new SpriteDetails()
        {
            Sprite = Dildo,
            PrefabPath = "Prefabs/item.dildo"
        });
    }

    public SpriteDetails GetSpriteDetails(Item.ItemType type)
    {
        return Items[type];
    }
}

using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public Item.ItemType Slot1;
    public Item.ItemType Slot2;
    Player player;

    private void Awake()
    {
        Slot1 = Item.ItemType.None;
        Slot2 = Item.ItemType.None;
    }

    private void Start()
    {
        player = GameManager.Instance.Player;
    }

    public bool AddItem(Item.ItemType item)
    {
        var isAdded = false;
        if (Slot1 == Item.ItemType.None)
        {
            Debug.Log($"Inventory - Slot1 Added: { item.ToString() }");
            Slot1 = item;
            isAdded = true;
        }
        else if(Slot2 == Item.ItemType.None)
        {
            Debug.Log($"Inventory - Slot2 Added: { item.ToString() }");
            Slot2 = item;
            isAdded = true;
        }

        if (isAdded)
        {
            UpdateInventory();
            return true;
        }

        Debug.Log($"Inventory - No inventory space");

        return false;
    }

    public void DropItem(int slot)
    {
        float nextAllowedPickupTime = 1f;

        if (slot == 1)
        {
            if(Slot1 != Item.ItemType.None)
            {
                GameObject go = null;
                go = Instantiate(Resources.Load((GameManager.Instance.SpriteLibrary.GetSpriteDetails(Slot1)).PrefabPath), player.transform.position, Quaternion.identity) as GameObject;
                go.GetComponent<Item>().NextAllowedPickTime = Time.time + nextAllowedPickupTime;
                Slot1 = Item.ItemType.None;
                UpdateInventory();
            }
        }
        else if (slot == 2)
        {
            if (Slot2 != Item.ItemType.None)
            {
                GameObject go = null;
                go = Instantiate(Resources.Load((GameManager.Instance.SpriteLibrary.GetSpriteDetails(Slot2)).PrefabPath), player.transform.position, Quaternion.identity) as GameObject;
                go.GetComponent<Item>().NextAllowedPickTime = Time.time + nextAllowedPickupTime;
                Slot2 = Item.ItemType.None;
                GameManager.Instance.InventoryChangedEvent.Invoke();
            }
        }
    }

    public void DestroySlot(int slot)
    {
        if (slot == 1)
            Slot1 = Item.ItemType.None;

        if (slot == 2)
            Slot2 = Item.ItemType.None;

        GameManager.Instance.InventoryChangedEvent.Invoke();
    }

    public void UpdateInventory()
    {
        GameManager.Instance.InventoryChangedEvent.Invoke();
    }
}

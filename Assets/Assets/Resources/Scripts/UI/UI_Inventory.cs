using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public Image UISlot1;
    public Image UISlot2;
    SpriteLibrary spriteLibrary;
    Inventory inventory;

    void Start()
    {
        GameManager.Instance.InventoryChangedEvent.AddListener(UpdateInventorySlotUI);
        inventory = GameManager.Instance.Player.Inventory;
        spriteLibrary = GameManager.Instance.SpriteLibrary;
    }

    private void UpdateInventorySlotUI()
    {
        Debug.Log("UI_Inventory - updating inventory slot graphics");
        UISlot1.sprite = (spriteLibrary.GetSpriteDetails(inventory.Slot1)).Sprite;
        UISlot2.sprite = (spriteLibrary.GetSpriteDetails(inventory.Slot2)).Sprite;
    }
}

using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public ItemType Type;
    public float NextAllowedPickTime = 0f;

    public enum ItemType
    {
        None,
        Dildo,
        Hammer,
        Battery,
        Newspaper,
        Keys,
        Screwdriver,
        Wallet,
        Cat,
        Baseball,
        Basketball,
        Phone
    }
}

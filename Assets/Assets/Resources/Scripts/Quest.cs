using UnityEngine;
using System.Collections;

public class Quest
{
    public Item.ItemType MissingItem;
    public string Description;
    public ReturnLocation.ReturnLocations ReturnLocation;
    public bool Completed = false;

    public void Complete()
    {
        Completed = true;
        Debug.Log($"Completed quest: { ReturnLocation }");
    }
}

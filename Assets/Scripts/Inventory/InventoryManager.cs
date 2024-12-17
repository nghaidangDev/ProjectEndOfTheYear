using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemClass itemToAdd;
    public ItemClass itemToRemove;

    public List<ItemClass> classItems = new List<ItemClass>();

    private void Start()
    {
        AddItems(itemToAdd);
        RemoveItems(itemToRemove);
    }

    public void AddItems(ItemClass itemClass)
    {
        classItems.Add(itemClass);
    }

    public void RemoveItems(ItemClass itemClass)
    {
        classItems.Remove(itemClass);
    }
}

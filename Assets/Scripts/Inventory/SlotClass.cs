using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotClass
{
    private ItemClass item;
    private int quantity;

    public SlotClass(ItemClass _item, int _quantity)
    {
        this.item = _item;
        this.quantity = _quantity;
    }

    public ItemClass GetItem() { return item; }
    public int GetQuantity() { return quantity; }
}

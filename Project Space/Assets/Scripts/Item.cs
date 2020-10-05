using UnityEngine;

public class Item
{
    public Sprite inventoryImage;
    public string name;

    public Item(Sprite inventoryImage, string name)
    {
        this.inventoryImage = inventoryImage;
        this.name = name;
    }
}
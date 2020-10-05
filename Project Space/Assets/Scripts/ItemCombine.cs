using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCombine : MonoBehaviour
{
    public string[] item1, item2, result;
    public Sprite[] resultImage;

    private Item _clickItem1, _clickItem2;

    void Start()
    {
    }

    public void Combine(GameObject item)
    {
        if (_clickItem1 == null)
            _clickItem1 = GameController.GetInstance().PlayerController.FindItem(item);
        else
        {
            _clickItem2 = GameController.GetInstance().PlayerController.FindItem(item);
            int i = FindCombination(_clickItem1, _clickItem2);
            if (i >= 0)
                GameController.GetInstance().PlayerController
                    .CombineItem(new Item(resultImage[i], result[i]), _clickItem1);

            _clickItem1 = null;
            _clickItem2 = null;
        }
    }

    private int FindCombination(Item clickItem1, Item clickItem2)
    {
        for (int i = 0; i < item1.Length; i++)
        {
            if (item1[i].Equals(clickItem1.name) && item2[i].Equals(clickItem2.name)) return i;
        }

        return -1;
    }
}
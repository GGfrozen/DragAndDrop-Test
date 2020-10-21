using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpriteStorage : MonoBehaviour
{
    [SerializeField] private Sprite type1;
    [SerializeField] private Sprite type2;
    [SerializeField] private Sprite type3;
    [SerializeField] private Sprite type4;
    
    
    [SerializeField] private Sprite empty;
    [SerializeField] private Sprite full;

    public static SpriteStorage instance;
    public GameObject item;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public Sprite GetItemSprite(Items item)
    {
        switch (item.type)
        {
            case Type.Type1:
                return type1;
            case Type.Type2:
                return type2;
            case Type.Type3:
                return type3;
            case Type.Type4:
                return type4;
        }

        return type1;
    }

    public Sprite GetSellSprite(SellType type)
    {
        switch (type)
        {
            case SellType.Empty:
                return empty;
            case SellType.Full:
                return full;
        }

        return empty;
    }

    public enum SellType
    {
        Empty,
        Full
    }
}
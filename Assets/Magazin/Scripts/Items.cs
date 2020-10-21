using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Items
{
    public int cost;
    public Type type;
}
public enum Owner
    {
        Player,
        Magazine
    }
public enum Type
    {
        Type1,
        Type2,
        Type3,
        Type4
    }


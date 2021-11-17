using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable<T> where T : LootResource<T>
{
    public List<T> lootDropItems;
}


public class LootResource<T>
{
    public T item;

    public float probabilityWeight;

    public float probabilityPercentage;

    public float probabilityRangeFrom;

    public float probabilityRangeTo;
}

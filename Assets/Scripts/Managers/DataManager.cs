using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDictable<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>();
    public void Init()
    {
        StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : IDictable<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/StatData");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}

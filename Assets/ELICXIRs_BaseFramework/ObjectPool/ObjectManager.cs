using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class ObjectManager<T> where T : ManagedObject
{
    //root(オブジェクトが生成される際の親オブジェクト)
    public Transform RootObject;

    //実際に生成されたオブジェクトのリスト
    public List<T> ObjectList = new List<T>();

    [System.Serializable]
    public class DictionaryData<R> {
        public string key;
        public R value;
    }

    Dictionary<string,T> PrefabDictionary
    {
        get
        {
            if(PD.Count!= PrefabList.Count)
            {
                foreach (var item in PrefabList)
                {
                    PD.TryAdd(item.key, item.value);
                }
            }
            return PD;
        }
    }
    Dictionary<string, T> PD=new Dictionary<string,T>();


    //生成元の辞書
    public List<DictionaryData<T>> PrefabList = new List<DictionaryData<T>>();

    public void AddDictionary(string key,T prefab)
    {
        if (PD.TryAdd(key, prefab)){
            PrefabList.Add(new DictionaryData<T> { key = key, value = prefab });
        }
    }

    public T AddInstance(T prefab)
    {
        if (PrefabDictionary.ContainsValue(prefab))
        {
            T newT = MonoBehaviour.Instantiate(prefab,RootObject);
            ObjectList.Add(newT);
            return newT;
        }
        else
        {            
            return null;
        }
    }

    public T AddInstance(string key)
    {
        if (PrefabDictionary.ContainsKey(key))
        {
            return AddInstance(PrefabDictionary[key]);
        }
        else
        {
            return null;
        }
    }

    public T AddInstanceAndDictionary(string key ,T prefab)
    {        
        AddDictionary(key, prefab);
        return AddInstance(key);
    }


    public virtual void Updater()
    {
        foreach (var item in ObjectList)
        {
            if (item.isActive())
            {
                item.Updater();
            }
        }
    }

    public virtual void LateUpdater()
    {
        foreach (var item in ObjectList)
        {
            if (item.isActive())
            {
                item.LateUpdater();
            }
        }
    }

    public virtual void FixedUpdater()
    {
        foreach (var item in ObjectList)
        {
            if (item.isActive())
            {
                item.FixedUpdater();
            }
        }
    }

}

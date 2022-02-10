using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectManager<T> where T : ManagedObject
{
    //root(オブジェクトが生成される際の親オブジェクト)
    Transform RootObject;

    //実際に生成されたオブジェクトのリスト
    List<T> ObjectList = new List<T>();

    //生成元の辞書
    Dictionary<string, T> PrefabDictionary = new Dictionary<string, T>();

    public ObjectManager(Dictionary<string, T>  dictionary,GameObject root){

        PrefabDictionary = new Dictionary<string, T>(dictionary);
        RootObject = root.transform;
    }

    public void AddDictionary(string key,T prefab)
    {
        PrefabDictionary.TryAdd(key, prefab);
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
            T newT = MonoBehaviour.Instantiate(PrefabDictionary[key], RootObject);
            ObjectList.Add(newT);
            return newT;
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

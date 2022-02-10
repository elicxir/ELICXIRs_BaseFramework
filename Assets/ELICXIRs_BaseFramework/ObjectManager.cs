using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectManager<T> where T : ManagedObject
{
    //実際に生成されたオブジェクトのリスト
    List<T> objects = new List<T>();

    //生成元のリスト
    List<T> prefablist = new List<T>();

    T AddInstance(T prefab)
    {
        T newT = MonoBehaviour.Instantiate(prefab);
        objects.Add(newT);
        return newT;
    }



    public virtual void Updater()
    {
        foreach (var item in objects)
        {
            if (item.isActive())
            {
                item.Updater();
            }
        }
    }

    public virtual void LateUpdater()
    {
        foreach (var item in objects)
        {
            if (item.isActive())
            {
                item.LateUpdater();
            }
        }
    }

    public virtual void FixedUpdater()
    {
        foreach (var item in objects)
        {
            if (item.isActive())
            {
                item.FixedUpdater();
            }
        }
    }

}

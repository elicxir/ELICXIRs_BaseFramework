using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectManager<T> where T : ManagedObject
{

    List<T> objects = new List<T>();

    T AddInstance(T prefab)
    {
        T newT = MonoBehaviour.Instantiate(prefab);
        return newT;
    }


}

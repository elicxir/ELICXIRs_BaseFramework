using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//ObjectManager(ObjectPool)で扱えるオブジェクト
public class ManagedObject : IndividualTimeMonoBehaviour
{
    protected object Manager;

    //This function will be called when this gameObject is instantiated (called only once)
    public virtual void FirstIniter(object manager)
    {
        Manager = manager;
        IndividualTimeSinceStart = 0;
    }

    //This function will be called when this gameObject get actived 
    public virtual void Initer()
    {
        IndividualTimeSinceStart = 0;

    }

    //This function will be called every frame when this gameobject is active
    public virtual void Updater()
    {
        IndividualTimeSinceStart +=I_deltaTime;

    }

    //This function will be called last of every frame when this gameobject is active
    public virtual void LateUpdater()
    {

    }

    //This function will be called every fixed frame (when the physics operation is performed) when this game object is active.

    public virtual void FixedUpdater()
    {

    }

    //This function will be called when this gameObject return to object pool
    public virtual void Finalizer()
    {

    }



}

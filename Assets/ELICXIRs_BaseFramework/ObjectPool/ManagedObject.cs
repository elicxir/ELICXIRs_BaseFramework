using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//ObjectManager(ObjectPool)�ň�����I�u�W�F�N�g
public class ManagedObject : IndividualTimeMonoBehaviour
{
    protected object Manager;

    //This function will be called when this gameObject is instantiated (called only once)
    public virtual void FirstIniter()
    {
    }

    //This function will be called when this gameObject get actived 
    public virtual void Initer()
    {
    }

    //This function will be called every frame when this gameobject is active
    public virtual void Updater()
    {

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

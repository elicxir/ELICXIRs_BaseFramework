using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualTimeMonoBehaviour : MonoBehaviour
{
    protected float IndividualTimeSinceStart = 0;

    public bool TimeProgressFlag
    {
        get;set;
    }
    public float TimeSpeed
    {
        get; set;
    }

    public float TimeProgressMult
    {
        get
        {
            if (TimeProgressFlag)
            {
                return TimeSpeed;
            }
            else
            {
                return 0;
            }
        }
    }

    public float I_deltaTime
    {
        get
        {
            return TimeProgressMult*Time.deltaTime;
        }
    }
}

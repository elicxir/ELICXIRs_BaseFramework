using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class VectorExtensions
{
    /// <summary>
    /// X軸に平行なベクトルかどうか。
    /// </summary>   
    public static bool isXaxisParallel(this Vector2 v)
    {
        return v.y == 0;
    }

    /// <summary>
    /// Y軸に平行なベクトルかどうか。
    /// </summary>
    public static bool isYaxisParallel(this Vector2 v)
    {
        return v.x == 0;
    }

    /// <summary>
    /// X軸に平行なベクトルかどうか。
    /// </summary>
    public static bool isXaxisParallel(this Vector3 v)
    {
        return v.y == 0&& v.z==0;
    }

    /// <summary>
    /// Y軸に平行なベクトルかどうか。
    /// </summary>
    public static bool isYaxisParallel(this Vector3 v)
    {
        return v.x == 0&&v.y==0;
    }
    /// <summary>
    /// Z軸に平行なベクトルかどうか。
    /// </summary>
    public static bool isZaxisParallel(this Vector3 v)
    {
        return v.x==0&&v.y == 0;
    }


    /// <summary>
    /// 軸並行なベクトルかどうか
    /// </summary>
    public static bool isAxisParallel(this Vector2 v)
    {
        return (v.isXaxisParallel() || v.isYaxisParallel()) && v.magnitude > 0;
    }

    /// <summary>
    /// 軸並行なベクトルかどうか
    /// </summary>
    public static bool isAxisParallel(this Vector3 v)
    {
        return (v.isXaxisParallel() || v.isYaxisParallel()|| v.isXaxisParallel()) && v.magnitude > 0;
    }
}

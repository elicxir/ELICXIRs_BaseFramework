using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class VectorEX
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
        return v.y == 0 && v.z == 0;
    }

    /// <summary>
    /// Y軸に平行なベクトルかどうか。
    /// </summary>
    public static bool isYaxisParallel(this Vector3 v)
    {
        return v.x == 0 && v.y == 0;
    }
    /// <summary>
    /// Z軸に平行なベクトルかどうか。
    /// </summary>
    public static bool isZaxisParallel(this Vector3 v)
    {
        return v.x == 0 && v.y == 0;
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
        return (v.isXaxisParallel() || v.isYaxisParallel() || v.isXaxisParallel()) && v.magnitude > 0;
    }
}

///
static class MonoBehaviourEX
{
    /// <summary>
    /// ゲームオブジェクトがアクティブかどうか。bool値を渡すとゲームオブジェクトのアクティブ状態を変更可能
    /// </summary>
    public static bool isActive(this MonoBehaviour m, bool? active = null)
    {
        if (active == null)
        {
            return m.gameObject.activeSelf;
        }
        else
        {
            if(m.gameObject.activeSelf != (bool)active)
            {
                m.gameObject.SetActive((bool)active);
            }

            return (bool)active;
        }
    }

}

static class RectEX
{
    public static Rect Rect_CS(Vector2 center,Vector2 size)
    {
        Rect rect = Rect.zero;

        rect.size = size;
        rect.center = center;

        return rect;
    }
}
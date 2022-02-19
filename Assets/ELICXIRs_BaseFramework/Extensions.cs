using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
            if (m.gameObject.activeSelf != (bool)active)
            {
                m.gameObject.SetActive((bool)active);
            }

            return (bool)active;
        }
    }


    /// <summary>
    /// this.SetRef(ref xxx)の形で使うとxxxの参照を取得することが可能
    /// </summary>
    public static void SetRef<T>(this MonoBehaviour m, ref T variable)
    {
        if (variable == null)
        {
            variable = m.GetComponent<T>();

            if (variable == null)
            {
                Debug.LogError("couldn't find component");
            }
        }

    }


}

static class gameObjectEX
{
    /// <summary>
    /// ゲームオブジェクトがアクティブかどうか。bool値を渡すとゲームオブジェクトのアクティブ状態を変更可能
    /// </summary>
    public static bool isActive(this GameObject m, bool? active = null)
    {
        if (active == null)
        {
            return m.activeSelf;
        }
        else
        {
            if (m.activeSelf != (bool)active)
            {
                m.SetActive((bool)active);
            }

            return (bool)active;
        }
    }


    /// <summary>
    /// this.SetRef(ref xxx)の形で使うとxxxの参照を取得することが可能
    /// </summary>
    public static void SetRef<T>(this GameObject m, ref T variable)
    {
        if (variable == null)
        {
            variable = m.GetComponent<T>();

            if (variable == null)
            {
                Debug.LogError("couldn't find component");
            }
        }

    }


}

static class RectEX
{
    public static Rect Rect_CS(Vector2 center, Vector2 size)
    {
        Rect rect = Rect.zero;

        rect.size = size;
        rect.center = center;

        return rect;
    }
}

static class StringEX
{
    /// <summary>
    /// <>タグと\nを除いて、stringの前からn文字を抽出する
    /// </summary>
    public static string Extraction(this string data, int n)
    {
        string[] SplitText = data.Split('\n');

        int num = n;

        string revisedData = string.Empty;


        for (int k = 0; k < SplitText.Length; k++)
        {
            //文字数カウントを無視する記号範囲かどうか
            bool simbol = false;

            string newstring = string.Empty;

            for (int q = 0; q < SplitText[k].Length; q++)
            {
                string c = SplitText[k].Substring(q, 1);

                switch (c)
                {
                    case "<":
                        simbol = true;
                        newstring += c;
                        break;
                    case ">":
                        simbol = false;
                        newstring += c;
                        break;

                    default:
                        if (!simbol)
                        {
                            if (num > 0)
                            {
                                newstring += c;
                                num--;
                            }

                        }
                        else
                        {
                            newstring += c;
                        }
                        break;
                }
            }

            if (k != SplitText.Length - 1)
            {
                newstring += "\n";
                num--; num--; num--;
            }

            revisedData += newstring;

        }

        return revisedData;
    }

    /// <summary>
    /// <>タグと\nを除いて、stringが何文字あるか
    /// </summary>
    public static int GetStringSum(this string data)
    {
        string[] SplitText = data.Split('\n');

        int sum = 0;

        for (int k = 0; k < SplitText.Length; k++)
        {
            //文字数カウントを無視する記号範囲かどうか
            bool simbol = false;

            for (int q = 0; q < SplitText[k].Length; q++)
            {
                string c = SplitText[k].Substring(q, 1);

                switch (c)
                {
                    case "<":
                        simbol = true;
                        break;
                    case ">":
                        simbol = false;
                        break;

                    default:
                        if (!simbol)
                        {
                            sum++;

                        }

                        break;
                }
            }

            if (k != SplitText.Length - 1)
            {
                sum += 3;
            }

        }

        return sum;

    }

}

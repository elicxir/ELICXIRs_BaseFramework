using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

static class VectorEX
{
    /// <summary>
    /// X���ɕ��s�ȃx�N�g�����ǂ����B
    /// </summary>   
    public static bool isXaxisParallel(this Vector2 v)
    {
        return v.y == 0;
    }

    /// <summary>
    /// Y���ɕ��s�ȃx�N�g�����ǂ����B
    /// </summary>
    public static bool isYaxisParallel(this Vector2 v)
    {
        return v.x == 0;
    }

    /// <summary>
    /// X���ɕ��s�ȃx�N�g�����ǂ����B
    /// </summary>
    public static bool isXaxisParallel(this Vector3 v)
    {
        return v.y == 0 && v.z == 0;
    }

    /// <summary>
    /// Y���ɕ��s�ȃx�N�g�����ǂ����B
    /// </summary>
    public static bool isYaxisParallel(this Vector3 v)
    {
        return v.x == 0 && v.y == 0;
    }
    /// <summary>
    /// Z���ɕ��s�ȃx�N�g�����ǂ����B
    /// </summary>
    public static bool isZaxisParallel(this Vector3 v)
    {
        return v.x == 0 && v.y == 0;
    }


    /// <summary>
    /// �����s�ȃx�N�g�����ǂ���
    /// </summary>
    public static bool isAxisParallel(this Vector2 v)
    {
        return (v.isXaxisParallel() || v.isYaxisParallel()) && v.magnitude > 0;
    }

    /// <summary>
    /// �����s�ȃx�N�g�����ǂ���
    /// </summary>
    public static bool isAxisParallel(this Vector3 v)
    {
        return (v.isXaxisParallel() || v.isYaxisParallel() || v.isXaxisParallel()) && v.magnitude > 0;
    }
}

static class MonoBehaviourEX
{
    /// <summary>
    /// �Q�[���I�u�W�F�N�g���A�N�e�B�u���ǂ����Bbool�l��n���ƃQ�[���I�u�W�F�N�g�̃A�N�e�B�u��Ԃ�ύX�\
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
    /// this.SetRef(ref xxx)�̌`�Ŏg����xxx�̎Q�Ƃ��擾���邱�Ƃ��\
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
    /// �Q�[���I�u�W�F�N�g���A�N�e�B�u���ǂ����Bbool�l��n���ƃQ�[���I�u�W�F�N�g�̃A�N�e�B�u��Ԃ�ύX�\
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
    /// this.SetRef(ref xxx)�̌`�Ŏg����xxx�̎Q�Ƃ��擾���邱�Ƃ��\
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
    /// <>�^�O��\n�������āAstring�̑O����n�����𒊏o����
    /// </summary>
    public static string Extraction(this string data, int n)
    {
        string[] SplitText = data.Split('\n');

        int num = n;

        string revisedData = string.Empty;


        for (int k = 0; k < SplitText.Length; k++)
        {
            //�������J�E���g�𖳎�����L���͈͂��ǂ���
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
    /// <>�^�O��\n�������āAstring�����������邩
    /// </summary>
    public static int GetStringSum(this string data)
    {
        string[] SplitText = data.Split('\n');

        int sum = 0;

        for (int k = 0; k < SplitText.Length; k++)
        {
            //�������J�E���g�𖳎�����L���͈͂��ǂ���
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

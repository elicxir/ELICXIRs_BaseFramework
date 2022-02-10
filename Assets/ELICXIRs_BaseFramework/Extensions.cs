using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class VectorExtensions
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

///
static class MonoBehaviourExtensions
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
            if(m.gameObject.activeSelf != (bool)active)
            {
                m.gameObject.SetActive((bool)active);
            }

            return (bool)active;
        }
    }

}


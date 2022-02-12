using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventCommand 
{
    
    //���̃R�}���h�̎��ɍs���R�}���h�̔ԍ����w�肷��
    //(�K�v�ɉ�����override����Ɗg���\)
    protected int Next(int nowIndex, List<EventCommand> list)
    {
        int result;

        result = nowIndex + 1;

        if (result > list.Count - 1)
        {
            result = -1;
        }

        return result;
    }

    //���̃R�}���h�̎��ɍs���R�}���h�̔ԍ����w�肷��
    public int NextCommandIndex(int nowIndex, List<EventCommand> list)
    {
        return Next(nowIndex, list);
    }

    //�R�}���h�̏������e
    public virtual IEnumerator Command()
    {
        yield break;
    }
}

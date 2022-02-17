using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventCommand 
{
    
    //このコマンドの次に行うコマンドの番号を指定する
    //(必要に応じてoverrideすると拡張可能)
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

    //このコマンドの次に行うコマンドの番号を指定する
    public int NextCommandIndex(int nowIndex, List<EventCommand> list)
    {
        return Next(nowIndex, list);
    }

    //コマンドの処理内容
    public virtual IEnumerator Command()
    {
        yield break;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public virtual IEnumerator DoEvent(EventProgram program)
    {
        int index = 0;

        print("event:"+this.name + " start");

        if (program.commands.Count > 0)
        {
            do
            {
                if (program.commands[index] != null)
                {
                    yield return StartCoroutine(program.commands[index].Command());
                    index = program.commands[index].NextCommandIndex(index, program.commands);

                }
                else
                {
                    yield break;
                }
            }
            while (index != -1);
        }
        else
        {
            yield break;
        }
    }

}

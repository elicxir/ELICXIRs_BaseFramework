using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EventProgram")]
public class EventProgram : ScriptableObject
{
    public List<EventCommand> commands = new List<EventCommand>();
}

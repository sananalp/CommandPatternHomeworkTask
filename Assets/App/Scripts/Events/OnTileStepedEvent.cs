using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTileStepedEvent : GameEvent
{
    public MoveCommand MoveCommand;


    public OnTileStepedEvent(MoveCommand moveCommand)
    {
        MoveCommand = moveCommand;
    }
}

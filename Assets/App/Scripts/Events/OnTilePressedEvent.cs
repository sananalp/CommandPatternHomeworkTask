using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

public class OnTilePressedEvent : GameEvent
{
    public readonly int CheckId;
    public readonly MeshRenderer Mesh;


    public OnTilePressedEvent(int checkId, MeshRenderer mesh)
    {
        CheckId = checkId;
        Mesh = mesh;
    }
}

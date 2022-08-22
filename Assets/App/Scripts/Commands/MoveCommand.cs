using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Transform playerTransform;
    private Vector3 initialPosition;
    private Vector3 destinationPosition;
    private float speed;


    public MoveCommand(Transform _playerTransform, Vector3 _initialPosition, Vector3 _destinationPosition, float _speed)
    {
        playerTransform = _playerTransform;
        initialPosition = _initialPosition;
        destinationPosition = _destinationPosition;
        speed = _speed;
    }

    public void Execute()
    {
        CommandManager.Instance.Move(playerTransform, destinationPosition, speed);
        EventManager.Instance.Raise(new OnTileStepedEvent(this));
    }

    public void Undo()
    {
        CommandManager.Instance.Move(playerTransform, initialPosition, speed);
        EventManager.Instance.Raise(new OnTileStepedEvent(this));
    }
    public float ReturnExecutionTime()
    {
        var distance = Vector3.Distance(initialPosition, destinationPosition);

        return distance / speed;
    }
}
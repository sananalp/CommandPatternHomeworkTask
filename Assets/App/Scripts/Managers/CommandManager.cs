using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using App.UI.Events;
using DynamicBox.EventManagement;

public class CommandManager : MonoBehaviour
{
    public static CommandManager Instance;
    private List<ICommand> commands = new List<ICommand>();
    private IEnumerator moveCoroutine;
    private IEnumerator undoCoroutine;
    private bool isUndoing;
    private MoveCommand moveCommand;

    void OnEnable()
    {
        EventManager.Instance.AddListener<OnReplayButtonClickedEvent>(OnReplayButtonClickedHandler);
        EventManager.Instance.AddListener<OnTileStepedEvent>(GetCommand);
    }
    void OnDisable()
    {
        EventManager.Instance.RemoveListener<OnReplayButtonClickedEvent>(OnReplayButtonClickedHandler);
        EventManager.Instance.RemoveListener<OnTileStepedEvent>(GetCommand);
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
    private void GetCommand(OnTileStepedEvent eventDetails)
    {
        moveCommand = eventDetails.MoveCommand;
    }
    private void OnReplayButtonClickedHandler(OnReplayButtonClickedEvent eventDetails)
    {
        moveCommand.Undo();

        Undo();
    }
    public void Move(Transform playerTransform, Vector3 targetPosition, float speed)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = MoveCoroutine(playerTransform, targetPosition, speed);
        StartCoroutine(moveCoroutine);
    }
    public void Undo()
    {
        if (isUndoing == false)
        {
            isUndoing = true;
            undoCoroutine = UndoCoroutine();
            StartCoroutine(undoCoroutine);
        }
    }
    public void AddCommand(ICommand command)
    {
        commands.Add(command);
    }

    IEnumerator MoveCoroutine(Transform playerTransform, Vector3 targetPosition, float speed)
    {
        while (playerTransform.position != targetPosition)
        {
            var movePoint = Vector3.MoveTowards(playerTransform.position, targetPosition, speed * Time.deltaTime);

            playerTransform.position = movePoint;

            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator UndoCoroutine()
    {
        commands.Reverse();

        foreach(var command in commands)
        {
            command.Undo();

            yield return new WaitForSeconds(command.ReturnExecutionTime());
        }

        commands.Clear();
        isUndoing = false;
    }
}
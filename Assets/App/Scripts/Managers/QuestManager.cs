using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using App.UI.Events;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private Transform tileContainer;
    private int playerStep;
    private TileController[] tiles;


    void Start()
    {
        GenerateRandomTileId();
    }
    void OnEnable()
    {
        EventManager.Instance.AddListener<OnTilePressedEvent>(OnTilePressedHandler);
        EventManager.Instance.AddListener<OnReplayButtonClickedEvent>(OnReplayButtonClickedHandler);
    }
    void OnDisable()
    {
        EventManager.Instance.RemoveListener<OnTilePressedEvent>(OnTilePressedHandler);
        EventManager.Instance.RemoveListener<OnReplayButtonClickedEvent>(OnReplayButtonClickedHandler);
    }

    private void GenerateRandomTileId()
    {
        tiles = tileContainer.GetComponentsInChildren<TileController>();

        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].Id = i;
        }

        for (int i = 0; i < tiles.Length; i++)
        {
            var randomTileIndex = Random.Range(i, tiles.Length);

            var temp = tiles[i].Id;
            tiles[i].Id = tiles[randomTileIndex].Id;
            tiles[randomTileIndex].Id = temp;
        }
    }

    private void OnTilePressedHandler(OnTilePressedEvent eventDetails)
    {
        if (playerStep == eventDetails.CheckId)
        {
            eventDetails.Mesh.material.color = Color.green;
            playerStep++;

            if (playerStep == tiles.Length)
            {
                EventManager.Instance.Raise(new OnWinReachedEvent(true));
            }
        }
        else
        {
            eventDetails.Mesh.material.color = Color.red;
            EventManager.Instance.Raise(new OnLoseReachedEvent(true));
        }
    }
    private void OnReplayButtonClickedHandler(OnReplayButtonClickedEvent eventDetails)
    {
        GenerateRandomTileId();
        EventManager.Instance.Raise(new OnWinReachedEvent(false));
        EventManager.Instance.Raise(new OnLoseReachedEvent(false));
    }
}
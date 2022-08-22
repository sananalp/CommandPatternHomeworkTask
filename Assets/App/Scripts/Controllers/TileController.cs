using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public int Id;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventManager.Instance.Raise(new OnTilePressedEvent(Id, meshRenderer));
        }
    }
}

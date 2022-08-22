using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 initialPosition;
    private Vector3 destinationPosition;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    initialPosition = transform.position;
                    destinationPosition = hit.point;

                    ICommand moveCommand = new MoveCommand(transform, initialPosition, destinationPosition, moveSpeed);
                    
                    moveCommand.Execute();

                    CommandManager.Instance.AddCommand(moveCommand);
                }
            }
        }
    }
}

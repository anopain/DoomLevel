using System;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private DoorDirection doorDirection;
    [SerializeField] private bool canOpen = true;
    [SerializeField] private float speed = 2f;

    [SerializeField] private float maxMovement = 10f;

    private enum DoorDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    private void Start()
    {
        door = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canOpen) return;

        switch (doorDirection)
        {
            case DoorDirection.Up:
                door.transform.Translate(Vector3.up * maxMovement * Time.deltaTime * speed);
                break;
            case DoorDirection.Down:
                door.transform.Translate(Vector3.down * maxMovement * Time.deltaTime * speed);
                break;
            case DoorDirection.Left:
                door.transform.Translate(Vector3.left * maxMovement * Time.deltaTime * speed);
                break;
            case DoorDirection.Right:
                door.transform.Translate(Vector3.right * maxMovement * Time.deltaTime * speed);
                break;
            default: //Default movement direction UP
                door.transform.Translate(Vector3.up * maxMovement * Time.deltaTime * speed);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!canOpen) return;

        switch (doorDirection)
        {
            case DoorDirection.Up:
                door.transform.Translate(Vector3.down * maxMovement * Time.deltaTime * speed);
                break;
            case DoorDirection.Down:
                door.transform.Translate(Vector3.up * maxMovement * Time.deltaTime * speed);
                break;
            case DoorDirection.Left:
                door.transform.Translate(Vector3.right * maxMovement * Time.deltaTime * speed);
                break;
            case DoorDirection.Right:
                door.transform.Translate(Vector3.left * maxMovement * Time.deltaTime * speed);
                break;
            default:
                door.transform.Translate(Vector3.down * maxMovement * Time.deltaTime * speed);
                break;
        }
    }
}

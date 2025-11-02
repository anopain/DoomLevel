using Unity.VisualScripting;
using UnityEngine;
public class Doors : MonoBehaviour 
{
    [SerializeField] private GameObject door;
    [SerializeField] private DoorDirection doorDirection;
    [SerializeField] private bool canOpen = true;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private float speed = 2f;

    [SerializeField] private float maxMovement = 10f;
    
    [SerializeField] private Vector3 closedPosition;
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private Vector3 doorDirectionVector;

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
        closedPosition = door.transform.position;
//        openPosition = door.transform.position;
    }

    public void CanOpenToggle()
    {
        canOpen = !canOpen;
    }
    public void DoorOpenToggle()
    {
        isOpen = !isOpen;
        if (isOpen) OpenDoor(doorDirection);
        else CloseDoor(doorDirection);
        Debug.Log($"{name} is now {(canOpen ? "Open" : "Closed")}");
    }

    private void SetDoorDirectionVector()
    {
        Switch (doorDirection);
        {
            case DoorDirection.Up:
                doorDirectionVector = Vector3.up;
                break;
                
            case DoorDirection.Down:
                doorDirectionVector = Vector3.down;
                break;
        }
        
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

    private void OpenDoor(DoorDirection doorDir)
    {
        if (!canOpen) return;

        switch (doorDir)
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

    private void CloseDoor(DoorDirection doorDir)
    {
        if (!canOpen) return;

        switch (doorDir)
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

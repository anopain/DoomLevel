using Unity.VisualScripting;
using UnityEngine;
public class Doors : MonoBehaviour 
{
    [SerializeField] private GameObject door;
    [SerializeField] private DoorDirection doorDirection;
    [SerializeField] private bool canOpen = true;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private bool triggerOnly = false;
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
        door = door != null ? door : this.gameObject;
        closedPosition = door.transform.position;
        SetDoorDirectionVector();
        openPosition = door.transform.position + doorDirectionVector.normalized * maxMovement;
    }

    private void Update()
    {
        Vector3 targetPosition = isOpen ? openPosition : closedPosition;
        door.transform.position = Vector3.Lerp(door.transform.position, targetPosition, Time.deltaTime * speed);
    }
    public void CanOpenToggle()
    {
        canOpen = !canOpen;
    }
    public void TriggerOnlyToggle()
    {
         triggerOnly = !triggerOnly;
    }
    public void DoorOpenToggle()
    {
        isOpen = !isOpen;
    }

    private void SetDoorDirectionVector()
    {
        switch (doorDirection)
        {
            case DoorDirection.Up:
                doorDirectionVector = Vector3.up;
                break;
                
            case DoorDirection.Down:
                doorDirectionVector = Vector3.down;
                break;
                
            case DoorDirection.Left:
                doorDirectionVector = Vector3.left;
                break;

            case DoorDirection.Right:
                doorDirectionVector = Vector3.right;
                break;

            default: //Default movement direction UP
                doorDirectionVector = Vector3.up;
                break;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!canOpen || triggerOnly) return;
            isOpen = true;
    
    }

    private void OnTriggerExit(Collider other)
    {
        if (!canOpen || triggerOnly) return;
            isOpen = false;
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

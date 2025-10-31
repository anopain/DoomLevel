using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private bool canOpen = true;
    [SerializeField] private float speed = 2f;

    [SerializeField] private float maxMovement = 10f;

    public enum DoorDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    [SerializeField] private DoorDirection doorDirection;
    void Start()
    {
        door = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canOpen == false) return;

        if (doorDirection == DoorDirection.Up)
        {
            door.transform.Translate(Vector3.up * maxMovement * Time.deltaTime * speed);
        }
        else if (doorDirection == DoorDirection.Down)
        {
            door.transform.Translate(Vector3.down * maxMovement * Time.deltaTime * speed);
        }
        else if (doorDirection == DoorDirection.Left)
        {
            door.transform.Translate(Vector3.left * maxMovement * Time.deltaTime * speed);
        }
        else if (doorDirection == DoorDirection.Right)
        {
            door.transform.Translate(Vector3.right * maxMovement * Time.deltaTime * speed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (canOpen == false) return;

        if (doorDirection == DoorDirection.Up)
        {
            door.transform.Translate(Vector3.down * maxMovement * Time.deltaTime * speed);
        }
        else if (doorDirection == DoorDirection.Down)
        {
            door.transform.Translate(Vector3.up * maxMovement * Time.deltaTime * speed);
        }
        else if (doorDirection == DoorDirection.Left)
        {
            door.transform.Translate(Vector3.right * maxMovement * Time.deltaTime * speed);
        }
        else if (doorDirection == DoorDirection.Right)
        {
            door.transform.Translate(Vector3.left * maxMovement * Time.deltaTime * speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
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


    private void 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

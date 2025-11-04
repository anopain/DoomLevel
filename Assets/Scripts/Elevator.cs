using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject elevator;
    [SerializeField] private bool moveElevatorUp = false;
    [SerializeField] private float elevatorSpeed = 2.0f;
    [SerializeField] private Vector3 upperPosition;
    [SerializeField] private Vector3 lowerPosition;
    [SerializeField] private float maxMovement = 10f;
    private void Start()
    {
        elevator = elevator != null ? elevator : this.gameObject;
        upperPosition = transform.position;
        lowerPosition = transform.position + Vector3.up * maxMovement;
    }

    public void ElevatorToggle()
    {
        moveElevatorUp = !moveElevatorUp;
    }

    private void OnTriggerEnter(Collider other)
    {
            if (transform.position == upperPosition)
            {
                moveElevatorUp = false;
            }        
    }

    void Update()
    {
        if (moveElevatorUp)
        {
            Vector3 targetPosition = moveElevatorUp ? upperPosition : lowerPosition;
            elevator.transform.position = Vector3.Lerp(elevator.transform.position, targetPosition, Time.deltaTime * elevatorSpeed);
        }else if (!moveElevatorUp && elevator.transform.position == upperPosition)
        {
            Vector3 targetPosition = moveElevatorUp ? lowerPosition : upperPosition;
            elevator.transform.position = Vector3.Lerp(elevator.transform.position, targetPosition, Time.deltaTime * elevatorSpeed);
        }
    }
}

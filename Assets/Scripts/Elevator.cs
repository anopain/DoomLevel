using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject elevator;
    [SerializeField] private GameObject upperLimit;
    [SerializeField] private bool moveElevatorUp = false;
    [SerializeField] private float elevatorSpeed = 2.0f;
    [SerializeField] private Vector3 upperPosition;
    [SerializeField] private Vector3 lowerPosition;
    [SerializeField] private float maxMovement = 10f;
    [SerializeField] private Vector3 currentVelocity = Vector3.zero;
    [SerializeField] private bool playerOnTop = false;
    private void Start()
    {
        elevator = elevator != null ? elevator : this.gameObject;
        upperPosition = transform.position;
        lowerPosition = transform.position + Vector3.up * maxMovement;
        lowerPosition.y = upperLimit.transform.position.y;
    }

    public void ElevatorToggle()
    {
        moveElevatorUp = !moveElevatorUp;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player") && playerOnTop)
       {
           ElevatorToggle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (elevator.transform.position.y < upperPosition.y + 1f)
        {
            playerOnTop = false;
        }
        else if (elevator.transform.position.y > lowerPosition.y -1f)
        {
            playerOnTop = true;
        }
    }
       private void Update()
        {

            Vector3 targetPosition = moveElevatorUp ? lowerPosition : upperPosition;
            elevator.transform.position = Vector3.SmoothDamp(elevator.transform.position, targetPosition, ref currentVelocity, elevatorSpeed);
        }
}

using UnityEngine;
public class ElevatorSwitch : MonoBehaviour
{
    [SerializeField] private Elevator linkedDoor;
    [SerializeField] private bool readyToPress = false;
    [SerializeField] private bool oneWay = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            readyToPress = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            readyToPress = false;
        }
    }
    private void Update()
    {
        if (!readyToPress || !Player.Instance.interacting) return;
        linkedDoor?.ElevatorToggle();

        //        Debug.Log("Secret Switch toggled. isOpen: " + isOpen);
    }
}

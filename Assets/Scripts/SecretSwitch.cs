using UnityEngine;
public class SecretSwitch : MonoBehaviour
{
    [SerializeField] private Doors linkedDoor;
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
        linkedDoor?.DoorOpenToggle();  
        
//        Debug.Log("Secret Switch toggled. isOpen: " + isOpen);
    }
}

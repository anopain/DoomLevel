using UnityEngine;

public class RedKeyCard : Doors
{
    [SerializeField] private Doors linkedDoor;
    [SerializeField] private bool readyToPress = false;
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
        {
            linkedDoor.CanOpenToggle();
//        Debug.Log("Secret Switch toggled. isOpen: " + isOpen);
            Destroy(this.gameObject, 1);
        }
    }
}

using UnityEngine;
public class SecretSwitch : Doors
{
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
        if (readyToPress && Player.Instance.interacting)
        {
            isOpen = !isOpen;
            Debug.Log("Secret Switch toggled. isOpen: " + isOpen);
        }
    }
}

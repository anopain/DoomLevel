using UnityEngine;

public class SecretSwitch : Doors
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger Entered");

        if (other.CompareTag("Player") && Player.Instance.interacting)
        {
            Debug.Log("Secret Switch Activated!");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

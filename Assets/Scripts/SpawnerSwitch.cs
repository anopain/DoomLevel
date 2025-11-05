using UnityEngine;

public class SpawnerSwitch : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject linkedObject;
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
        SpawnObject();

        //        Debug.Log("Secret Switch toggled. isOpen: " + isOpen);
    }
    private void SpawnObject()
    {
        if (linkedObject != null)
        {
            Instantiate (linkedObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }

}
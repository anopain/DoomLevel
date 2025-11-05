using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private GameObject toRotate;
    [SerializeField] private float rotationSpeed = 45f; // degrees per second
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toRotate = toRotate != null ? toRotate : this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        toRotate.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        toRotate.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        toRotate.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}

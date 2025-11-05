using UnityEngine;
using UnityEngine.UIElements;

namespace Fed
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 10f;
        [SerializeField] private float destroyTime = 3f;
        private AudioSource audioSource;

        [SerializeField] private ParticleSystem Sparks;

        private void Start()
        {
            //AudioSource is attached to projectile. Play on awake is enabled so need to play in code.
            //            audioSource = GetComponent<AudioSource>();
            //            audioSource.Play(); 
            Destroy(gameObject, destroyTime);
        }

        public void Update()
        {

            transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);


        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Hit collider: {other.name}");
            if (other.name != "Player")
            {
                Debug.Log("OnTriggerEnter...");
                if (Sparks != null)
                {
                    Debug.Log("InsideIf OnTriggerEnter.");
                    Instantiate(Sparks, transform.position, Quaternion.identity);
                }
            Destroy (gameObject);
            }
        }
    }
}
using System.Collections;
using UnityEngine;

namespace Fed
{
    public class SpawnedSlime : MonoBehaviour
    {
        public int slimeIdleTime;
        public int dizzyTime;
        private int slimeIdleTimeMin = 3;
        private int slimeIdleTimeMax = 6;
        public int slimeSpeed = 4;
        [SerializeField] private int activateSlime = 7;
        public bool slimeActive = false;

        [SerializeField] private GameObject slimeBody;

        private Rigidbody rb;

        private Animator anim;

        [SerializeField] private GameObject SlimeVFX;

        public enum SlimeState
        {
            Idle,
            Move,
            Dizzy
        }

        private SlimeState slimeCurrent = SlimeState.Idle;

        private void Start()
        {
            Instantiate(SlimeVFX, transform);
            slimeBody = transform.Find("Slime").gameObject;
            slimeBody.SetActive(false);            
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            if (rb == null)
                Debug.Log("Slime has no RigidBody!");

            StartCoroutine(DelayedExecution());
            //            StartCoroutine(StateManager());

            //Random time between 5-20 before slime activation
            //            activateSlime = ReturnRandomInt(10, 20);
//            activateSlime = 7;
            //            Debug.Log($"Slime activation after: {activateSlime} seconds.");
        }

        private void Update()
        {

        }

        private IEnumerator DelayedExecution()      //Slime activator
        {
            yield return new WaitForSeconds(activateSlime);
            //            Debug.Log("Slime activated.");
            slimeBody.SetActive(true);                                                        //ACTIVATE SLIME BODY!!!!!
            slimeActive = true;
            StartCoroutine(StateManager());
        }

        private IEnumerator StateManager()
        {

            while (slimeActive)
            {
                yield return StartCoroutine(HandleState(slimeCurrent));
                yield return null;
            }
        }

        private IEnumerator HandleState(SlimeState state)
        {
            //            Debug.Log("Entering state: " + state);
            switch (state)
            {
                case SlimeState.Idle:   //Slime Idle actions
                    {
                        //                        Debug.Log("SlimeState: Idle");
                        yield return StartCoroutine(IdleCoroutine());
                        slimeCurrent = SlimeState.Move;

                        break;
                    }
                case SlimeState.Move:   //Slime Moving actions
                    {
                        //                        Debug.Log("SlimeState: Move");
                        yield return StartCoroutine(MoveCoroutine());
                        slimeCurrent = SlimeState.Dizzy;

                        break;
                    }
                case SlimeState.Dizzy:  //Slime being Dizzy
                    {
                        //                        Debug.Log("SlimeState: Dizzy");
                        yield return StartCoroutine(DizzyCoroutine());
                        slimeCurrent = SlimeState.Idle;

                        break;
                    }
            }
            //            Debug.Log("Exiting state: " + state);

        }


        IEnumerator IdleCoroutine()      //Idle state
        {
            //slimeIdle = false;
            anim.SetTrigger("Idle");
            slimeIdleTime = ReturnRandomInt(slimeIdleTimeMin, slimeIdleTimeMax);
            //            Debug.Log($"DizzyTime: {slimeIdleTime}");
            yield return new WaitForSeconds(slimeIdleTime);
        }

        IEnumerator MoveCoroutine()
        {
            //isMoving = false;
            anim.SetTrigger("Walk");
            TurnSlimeDegrees();

            //Time factors
            float accelerationTime = 2f;
            float constantSpeedTime = 2f;
            float decelerationTime = 2f;
            float elapsedTime = 0f;
            //Speed factors
            float maxSpeed = slimeSpeed;
            float currentSpeed = 0;

            //Acceleration
            //            Debug.Log("Accelerate");
            while (elapsedTime < accelerationTime)
            {
                currentSpeed = Mathf.Lerp(0, maxSpeed, elapsedTime / accelerationTime);
                MoveSlime(currentSpeed);
                elapsedTime += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }

            //Constant Speed phase
            elapsedTime = 0f;
            //            Debug.Log("Maintain Speed");
            while (elapsedTime < constantSpeedTime)
            {
                MoveSlime(maxSpeed);
                elapsedTime += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
            //Deceleration
            elapsedTime = 0f;
            //            Debug.Log("Decelerate");
            while (elapsedTime < decelerationTime)
            {
                currentSpeed = Mathf.Lerp(maxSpeed, 0, elapsedTime / accelerationTime);
                MoveSlime(currentSpeed);
                elapsedTime += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
        }

        IEnumerator DizzyCoroutine()
        {
            anim.SetTrigger("Dizzy");
            dizzyTime = ReturnRandomInt(slimeIdleTimeMin, slimeIdleTimeMax);
            //            Debug.Log($"DizzyTime: {dizzyTime}");
            yield return new WaitForSeconds(dizzyTime);

        }

        private void MoveSlime(float speed)
        {
            Vector3 newPosition = Vector3.forward * speed * Time.fixedDeltaTime;
            transform.Translate(newPosition);
        }

        private void TurnSlimeDegrees()
        {
            int degrees = ReturnRandomInt(0, 360);      //Get turn direction degrees

            transform.Rotate(0f, degrees, 0f);
        }

        private int ReturnRandomInt(int min, int max)
        {
            return Random.Range(min, max + 1);
        }
    }
}

/*
private Vector3 GetRandomDirection()
{
    int direction = ReturnRandomInt(0, 4);
    switch (direction)
    {
        case 0: return Vector3.forward;
        case 1: return Vector3.back;
        case 2: return Vector3.left;
        case 3: return Vector3.right;
        default: return Vector3.zero;
    }
}
*/
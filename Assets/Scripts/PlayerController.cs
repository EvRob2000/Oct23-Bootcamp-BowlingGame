using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerMoveSpeed;
    public float arrowMinX, arrowMaxX;
    public float throwForce;

    [SerializeField] private Transform throwingArrow;
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private Rigidbody selectedBall;

    // [] is an array, a collection of objects, combines objects of the same type
    [SerializeField] private Rigidbody[] balls;

    [SerializeField] private Animator arrowAnimator;

    Vector3 ballOffset;
    bool wasBallThrown;

    // Start is called before the first frame update
    void Start()
    {
        ballOffset = ballSpawnPoint.position - throwingArrow.position;

        // calling this method at Start
        // StartThrow();
    }

    // Update is called once per frame
    void Update()
    {
       // how you call methond inside another method
       TryMoveArrow();
       TryShootBall();
    }

    public void StartThrow()
    {
        //set aiming boolean to true
        // "Aiming" is the name of the bool in the animator
        arrowAnimator.SetBool("Aiming", true);

        wasBallThrown = false;



        // makes a random number from the start of the array to the maxmimum possible array number
        int ballToSpawnIndex = Random.Range(0, balls.Length);

        // instantiate spawns in an object
        // first element in an array [] has an index of 0, then 1, then 2, so on..
        // Quatermnion takes rotation of game object that has the script on it
        //.position puts the object at the position that is called before it
        // makes the ball that spawns the one that was originall selectedBall
        selectedBall = Instantiate(balls[ballToSpawnIndex], ballSpawnPoint.position, Quaternion.identity);
    }

    void TryMoveArrow()
    {
        if (!wasBallThrown)
        {
            // throwingArrow.position += throwingArrow.right * Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;

            float movePosition = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;
            // comma lets you continue code on next line
            throwingArrow.position = new Vector3(Mathf.Clamp(throwingArrow.position.x + movePosition, arrowMinX, arrowMaxX),
                throwingArrow.position.y, throwingArrow.position.z);

            // move ball with arrow
            selectedBall.transform.position = throwingArrow.position + ballOffset;

        }
    }

    void TryShootBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && wasBallThrown == false)
        {
            wasBallThrown = true;
            selectedBall.AddForce(throwingArrow.forward * throwForce, ForceMode.Impulse);

            //disables the throwing arrow
            arrowAnimator.SetBool("Aiming", false);
        }
    }
}

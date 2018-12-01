/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    public Vector3 throwSpeed;
    //private GameObject ballClone;
    private Rigidbody rbBall;

    private void Start()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            rbBall.AddForce(throwSpeed);
        }
    }*/

/*  * References:    *  https://code.tutsplus.com/tutorials/create-a-basketball-free-throw-game-with-unity--cms-21203  *  https://www.youtube.com/watch?v=vduSC2YHFnw  *  https://forum.unity.com/threads/flicking-shooting-throwing-tossing-lobbing-slicing-script.91726/  *   *   *  Free udemy course on creating basketball game in Unity  *      https://www.udemy.com/unity-game-developer/  *  Link below is for a $5 asset of basketball shooting and soccer - may be a easy solution  *      https://assetstore.unity.com/packages/templates/simple-soccer-basketball-68851  */


using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.UI;  public class Shoot : MonoBehaviour
{      private Vector3 throwSpeed;     private Rigidbody rbBall;
    bool ballShot;

    bool shooting;

    public Text forceAngle;

    private float angleForce = 0f;

    private float throwZ = -200f;

    private float throwX = 0f;

    Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
    float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

    float throwForceInXandY = 1f; // to control throw force in X and Y directions

    float throwForceInZ = 50f; // to control throw force in Z direction
    
    private void Start()     {

        rbBall = GetComponent<Rigidbody>();

        ballShot = false;     }      void Update()     {

        if (!ballShot)
        {
            Swipe();
        }

    }



    void Swipe(){
        // if you touch the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            // getting touch position and marking time when you touch the screen
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        // if you release your finger
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            // marking time when you release it
            touchTimeFinish = Time.time;

            // calculate swipe time interval 
            timeInterval = touchTimeFinish - touchTimeStart;

            // getting release finger position
            endPos = Input.GetTouch(0).position;

            // calculating swipe direction in 2D space
            direction = startPos - endPos;

            // add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
            rbBall.isKinematic = false;
            rbBall.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval);

            // Destroy ball in 4 seconds
            Destroy(gameObject, 3f);

        }
    }
}










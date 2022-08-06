using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllInput : MonoBehaviour
{
    public bool AiON = false;
    public Vector2 Direction { get; set; }
    private float directionDistance;

    [SerializeField] private Rigidbody2D playerRigidbody;
    private Rigidbody2D thisBody;

    int direction;
    private void Awake()
    {
            thisBody = GetComponent<Rigidbody2D>();        
    }

    private void FixedUpdate()
    {
        if(AiON)
        {
            GetDistance(playerRigidbody);

            //thisBody.velocity = new Vector2((thisBody.velocity.x + speed) * Time.fixedDeltaTime, thisBody.velocity.y);

            if(directionDistance > 0.3f)
            {

                Debug.Log(direction);
                float speed = 0.5f;
                float maxSpeed = speed;
                if(thisBody.velocity.x < maxSpeed)
                {
                    speed += 0.1f * Time.fixedDeltaTime;
                    if(speed == maxSpeed || directionDistance < 0.5f)
                    {
                        speed = 0;
                        // punch
                        //or start courotine
                    }
                }
                thisBody.velocity = new Vector2( -direction  * (speed) , thisBody.velocity.y);
                    //new Vector2( thisBody.velocity.x * playerRigidbody.position.x - ;+ * Time.fixedDeltaTime 
                    //new Vector2(playerRigidbody.position.x - (speed * thisBody.velocity.x) * Time.fixedDeltaTime, thisBody.position.y);
            }
        }
        //Setirection();
        else
        {
            ;
        }    
    }
    public void Setirection()
    {

    }

    private void GetDistance(Rigidbody2D playerRigidbody)
    {
        Vector2 otherPos;

            //Debug.Log(AiON);
            otherPos = playerRigidbody.position;

            directionDistance = Vector2.Distance(transform.position, otherPos);
        if (playerRigidbody.position.x > thisBody.position.x)
            direction = -1;
        else
            direction = 1;
            //Debug.Log(directionDistance);
    }

    private void PlayerControll()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    public float moveSpeed;

    public float positionFromPoibt;
    public Transform startPosint;
    public Transform playerPosition;

    [SerializeField] private bool isTurn;
    public float closeCombatDistance;

    bool isIdle = false;
    bool isRun = false;
    bool isAttack = false;

    private void Start()
    {
        playerPosition = GameObject.FindObjectOfType<Player>().transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isIdle == true)
        {
            Idle();
        }
        if (isAttack == true)
        {
            Attack();
        }
        if (isRun == true)
        {
            Run();
        }

    }

    private void FixedUpdate()
    {

        if (Vector2.Distance(rigidbody2D.velocity, playerPosition.position) < positionFromPoibt && isAttack == false)
        {
            isIdle = true;
        }

        if (Vector2.Distance(rigidbody2D.position, playerPosition.position) < closeCombatDistance)
        {
            isAttack = true;
        }


        if (Vector2.Distance(rigidbody2D.position, playerPosition.position) > closeCombatDistance)
        {
            isRun = true;
            isAttack = false;
        }
    }

    private void Idle()
    {
        if(rigidbody2D.velocity.x  > playerPosition.position.x + positionFromPoibt)
        {
            isTurn = false ;
        }
        else if(rigidbody2D.velocity.x < playerPosition.position.x - positionFromPoibt)
        {
            isTurn = true;
        }

        if(isTurn)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + moveSpeed * Time.deltaTime, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(-rigidbody2D.velocity.x + moveSpeed * Time.deltaTime, rigidbody2D.velocity.y);
        }
    }

    private void Run()
    {
        rigidbody2D.velocity = Vector2.MoveTowards(rigidbody2D.velocity, startPosint.position, moveSpeed * Time.fixedDeltaTime);
    }


    private void Attack()
    {
        rigidbody2D.velocity = Vector2.MoveTowards(rigidbody2D.velocity, -playerPosition.position, moveSpeed * Time.fixedDeltaTime);
    }

}

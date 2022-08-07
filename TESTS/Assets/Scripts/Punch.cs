using System;
using UnityEngine;

[Serializable]
public class Punch 
{
    private IMovementInput input;
    private PunchSettings settings;
    private Rigidbody2D rigidbody;

    //[SerializeField] private Transform attackPoint;

    [SerializeField] private bool isPunch = false;

    //private float nextAttackTime = 0;

    private float drag;

    public bool IsPunch { get { return isPunch; } }


    public Punch(IMovementInput Input, PunchSettings Settings, Rigidbody2D Rigidbody2D) //, Transform AttackPoint)
    {
        this.input = Input;
        this.settings = Settings;
        //this.attackPoint = AttackPoint;
        this.rigidbody = Rigidbody2D;

        drag = rigidbody.drag;
    }


    public void HandleAttack()   // (float direction)
    {
        float nextAttackTime = 0.5f; // settings.NextAttackTime;

        if (Time.time >= nextAttackTime)
        {
            isPunch = false;

            //float drag = rigidbody.drag;
            if (input.IsPunch)
            {

                isPunch = true;
                //input.
                //Vector2 temp = rigidbody.velocity;
                //temp.x = -rigidbody. velocity.x * Time.fixedDeltaTime; 
                //rigidbody.velocity = temp;
                //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, settings.AttackRange, settings.EnemyMask);

                //foreach (Collider2D enemy in hitEnemies)
                //{
                //    Debug.Log("We hit " + enemy.name);
                //}

                nextAttackTime = Time.time + 1f / settings.AttackRate;
                //rigidbody.drag = drag;
            }

        }
    }



    //
}

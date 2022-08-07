using System;
using UnityEngine;

[Serializable]
public class Punch 
{
    private IMovementInput input;
    private PunchSettings settings;
    [SerializeField] private Transform attackPoint;

    [SerializeField] private bool isPunch = false;

    //private float nextAttackTime = 0;

    public bool IsPunch { get { return isPunch; } }

    public Punch(IMovementInput Input, PunchSettings Settings, Transform AttackPoint)
    {
        this.input = Input;
        this.settings = Settings;
        this.attackPoint = AttackPoint;
    }


    public void HandleAttack()   // (float direction)
    {
        float nextAttackTime = 0; // settings.NextAttackTime;

        if (Time.time >= nextAttackTime)
        {
            isPunch = false;
            if (input.IsPunch)
            {
                isPunch = true;
                //input.

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, settings.AttackRange, settings.EnemyMask);

                foreach (Collider2D enemy in hitEnemies)
                {
                    Debug.Log("We hit " + enemy.name);
                }

                nextAttackTime = Time.time + 1f / settings.AttackRate;
                isPunch = true;
            }

        }
    }



    //
}

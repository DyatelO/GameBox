using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Punch/Settings", fileName = "PunchSettings")]
public class PunchSettings : ScriptableObject
{
    [SerializeField] private bool isPunch = false;
    // [SerializeField] private Transform attackPoint;
    [SerializeField] private float damage = 15;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private float attackRate = 2f;
    [SerializeField] private LayerMask enemyMask;

    private CircleCollider2D circleCollider2D;

    Vector2 position;
    float offsetPoint; //= attackPoint.localPosition.x;

    private float nextAttackTime = 0f;


    public bool IsPunch { get { return isPunch; } }
    //public Transform AttackPoint { get { return attackPoint; } }
    public float Damage { get { return damage; } }
    public float AttackRange { get { return attackRange; } }
    public float AttackRate { get { return attackRate; } }
    public LayerMask EnemyMask { get { return enemyMask; } }

    public float NextAttackTime { get { return nextAttackTime; } }




    //public Collider2D CircleCollider2D { get { return circleCollider2D; } }





}

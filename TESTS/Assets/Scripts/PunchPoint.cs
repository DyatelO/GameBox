using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchPoint : MonoBehaviour
{
    public Transform attackPoint ;
    [SerializeField] private PunchSettings settings;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void FindEnemyForPunch()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
                                                            attackPoint.position,
                                                            settings.AttackRange,
                                                            settings.EnemyMask
                                                            );

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);

        }
    }
}

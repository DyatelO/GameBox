using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    private bool isAlive;
    private bool isHurt = false;

    public bool  IsHurt{ get { return isHurt; } }


    private void Start ()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        isHurt = true;
        CheckHealth();

    }

    private void CheckHealth()
    {
        if (currentHealth > 0)
        {
            isHurt = false;
        }
        if(currentHealth <= 0)
        {
            isAlive = false;
            //SetActive(false);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vrag : MonoBehaviour
{
    bool died = false;
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage (int damage) {
        if (died) { 
            return;
        }

        currentHealth -= damage;
        if (damage < 40) {
            StartCoroutine(Hurt1());
        } else {
            StartCoroutine(Hurt2());
        }
        if (currentHealth <= 0) {
            Die();
        }
    }

    IEnumerator Hurt1() {
        yield return new WaitForSeconds(0.45f);
        healthBar.SetHealt(currentHealth);
        animator.SetTrigger("HurtEnemy");
    }

    IEnumerator Hurt2() {
        yield return new WaitForSeconds(0.9f);
        healthBar.SetHealt(currentHealth);
        animator.SetTrigger("HurtEnemy");
    }

    void Die() {
        animator.SetBool("IsDead", true);
        this.enabled = false;
        died = true;
    }

}

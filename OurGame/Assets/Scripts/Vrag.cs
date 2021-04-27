using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vrag : MonoBehaviour
{
    public bool died = false;
    public Animator animator;
    public int maxHealth;
    public int currentHealth;
    public GameObject Person;
    public HealthBar healthBar;
    public int ID;
    void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage (int damage) {
        if (died) {
            return;
        }

        currentHealth -= damage;
        if (damage > 0 && damage < 40) {
            StartCoroutine(Hurt1());
        } else if(damage >=40) {
            StartCoroutine(Hurt2());
        }else {
            StartCoroutine(Heal());
        }
        if (currentHealth <= 0) {
            Die();
        }
    }

    IEnumerator Hurt1() {
        yield return new WaitForSeconds(0.5f);
        healthBar.SetHealt(currentHealth);
        if (Person.tag == "Vrag") animator.SetTrigger("HurtEnemy");
        else animator.SetTrigger("HurtTeam");
    }

    IEnumerator Hurt2() {
        yield return new WaitForSeconds(0.9f);
        healthBar.SetHealt(currentHealth);
        if (Person.tag == "Vrag") animator.SetTrigger("HurtEnemy");
        else animator.SetTrigger("HurtTeam");
    }

    IEnumerator Heal() {
        yield return new WaitForSeconds(0.15f);
        healthBar.SetHealt(currentHealth);
        animator.SetTrigger("HealTeam");
    }

    void Die() {
        died = true;
        animator.SetBool("IsDead", true);
        if (Person.tag == "Vrag") {
            PlayerPrefs.SetInt("enemiesAlive", PlayerPrefs.GetInt("enemiesAlive") - 1);
        } else {
            PlayerPrefs.SetInt("teamAlive", PlayerPrefs.GetInt("teamAlive") - 1);
        }
    }
}

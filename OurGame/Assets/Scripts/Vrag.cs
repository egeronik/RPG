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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage (int damage) {

        if (died) { 
            Debug.Log("Нахуя ты пиздишь говно?"); 
            return;
        }

        currentHealth -= damage;
        if (damage < 40) {
            StartCoroutine(Hurt1());
            Debug.Log("Ебнул");
        } else {
            StartCoroutine(Hurt2());
            Debug.Log("Сильно ебнул");
        }
        if (currentHealth <= 0) {
            Die();
        }
    }

    IEnumerator Hurt1() {
        yield return new WaitForSeconds(0.45f);
        healthBar.SetHealt(currentHealth);
        animator.SetTrigger("Hurt");
    }

    IEnumerator Hurt2() {
        yield return new WaitForSeconds(0.9f);
        healthBar.SetHealt(currentHealth);
        animator.SetTrigger("Hurt");
    }

    void Die() {
        Debug.Log("Чел в говне");
        animator.SetBool("IsDead", true);
        this.enabled = false;
        died = true;
    }

}

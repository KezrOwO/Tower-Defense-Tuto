using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 10f;
    [HideInInspector] public float speed = 10f;
    public float startHealth = 100f;
    private float health;
    public int worth = 50;
    public GameObject deathEffect;

    public Image healthBar;

    private bool isDead = false;
    private void Start()
    {
        speed = baseSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
            Die();
    }

    public void Slow(float amount)
    {
        speed = baseSpeed * (1f - amount);
    }

    private void Die()
    {
        isDead = true;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        PlayerStats.money += worth;
        Destroy(effect, 1.5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float baseSpeed = 10f;
    [HideInInspector] public float speed = 10f;
    public float health = 100f;
    public int worth = 50;
    public GameObject deathEffect;

    private void Start()
    {
        speed = baseSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
            Die();
    }

    public void Slow(float amount)
    {
        speed = baseSpeed * (1f - amount);
    }

    private void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        PlayerStats.money += worth;
        Destroy(gameObject);
        Destroy(effect, 1.5f);
    }
}

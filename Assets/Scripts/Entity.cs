using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected private int maxHealth;
    [SerializeField] protected private int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        CheckDeath(currentHealth);
    }

    protected void DamageEntity(int damage)
    {
        currentHealth -= damage;
    }

    protected void CheckDeath(int health)
    {
        if (currentHealth <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != gameObject.tag
            && other.CompareTag("Player"))
        {
            DamageEntity(1);
        }

        if (other.CompareTag("Obstacle"))
        {
            DamageEntity(1);
        }
    }
}

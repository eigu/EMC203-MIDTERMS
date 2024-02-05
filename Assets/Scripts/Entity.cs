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
        EntityDeath(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EntityDamaged(1);
        }
    }

    private void EntityDamaged(int damage)
    {
        currentHealth -= damage;
    }

    private void EntityDeath(int health)
    {
        if (currentHealth <= 0) Destroy(gameObject);
    }
}

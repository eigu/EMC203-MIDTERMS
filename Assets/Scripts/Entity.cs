using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected private int maxHealth;
    public int currentHealth;

    private bool hasTakenDamage = false;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    protected void DamageEntity(int damage)
    {
        if (currentHealth <= 0) Destroy(gameObject);

        if (!hasTakenDamage && currentHealth > 0)
        {
            hasTakenDamage = true;
            currentHealth -= damage;
        }

        StartCoroutine(ResetDamageFlag());
    }

    private IEnumerator ResetDamageFlag()
    {
        yield return new WaitForSeconds(0.3f);
        hasTakenDamage = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == gameObject.tag)
        {
            return;
        }

        DamageEntity(1);
    }
}

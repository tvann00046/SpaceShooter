using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Settings")]
    public int maxHealth = 1;

    [Header("VFX")]
    public GameObject hitEffectPrefab;

    private int currentHealth;

    void Awake()
    {
        // Khởi tạo máu 1 lần duy nhất
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Tạo hiệu ứng nổ / hit
        if (hitEffectPrefab != null)
        {
            Instantiate(
                hitEffectPrefab,
                transform.position,
                Quaternion.identity
            );
        }

        // Enemy chết
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            LevelManager.Instance.GetDamage(enemy.GetDamageToPlayer());
            Destroy(collision.gameObject);
            WaveManager.Instance.EnemyDead();
        }
    }
}

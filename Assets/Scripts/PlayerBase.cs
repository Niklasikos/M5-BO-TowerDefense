using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            IEnemy enemy = collision.gameObject.GetComponent<IEnemy>();
            LevelManager.Instance.GetDamage(enemy.DamageToPlayer);
            Destroy(collision.gameObject);
        }
    }
}

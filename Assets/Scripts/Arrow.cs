using UnityEngine;

public enum ProjectileOptions
{
    Arrow,
    MageOrb,
    CanonBall
}
public class Projectile : MonoBehaviour
{
    public ProjectileOptions projectileOptions;
    public GameObject target;
    private int damage;
    [SerializeField] private float speed = 10f;
    private float EffectLenght;
    void Start()
    {

    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        Vector2 direction = target.transform.position - transform.position; //crack
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject == target)
        {
            switch (projectileOptions)
            {
                case ProjectileOptions.Arrow:
                    Enemy enemy1 = collision.gameObject.GetComponent<Enemy>();
                    enemy1.GetDamage(damage);
                    Destroy(gameObject);
                    break;

                case ProjectileOptions.MageOrb:
                    Enemy enemy2 = collision.gameObject.GetComponent<Enemy>();
                    enemy2.GetDamage(damage);
                    enemy2.GetEffect(EffectLenght);
                    Destroy(gameObject);
                    break;
            }

        }
    }

    public void SetDamage(int DamageSet)
    {
        damage = DamageSet;
    }

    public void SetSpeed(float speedSet)
    {
        speed = speedSet;
    }

    public void SetEffect(float EffectSet)
    {
        EffectLenght = EffectSet;
    }
}

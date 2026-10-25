using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject target;
    private int damage;
    [SerializeField] private float speed = 10f;
    void Start()
    {

    }

    void Update()
    {
        if(target == null)
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
        if(collision.gameObject.CompareTag("Enemy") && collision.gameObject == target)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.GetDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int DamageAdded)
    {
        damage = DamageAdded;
    }
}

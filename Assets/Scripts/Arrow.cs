using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject target;
    public int damage;
    [SerializeField] private float speed = 10f;
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        Vector2 direction = target.transform.position - transform.position; //crack
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
        if(target == null)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.GetDamage(damage);
            Destroy(gameObject);
        }
    }
}

using Unity.Mathematics;
using UnityEngine;

public class GymArrow : MonoBehaviour
{
    public GameObject target;
    public int damage = 20;
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

    }
}

using Unity.Mathematics;
using UnityEngine;

public class GymArrow : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float speed = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform);
    }
}

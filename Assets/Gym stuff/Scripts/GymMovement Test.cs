using UnityEngine;

public class GymMovementTest : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float health = 100f;
    private int currentTarget = 0;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[currentTarget].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, positions[currentTarget].position) < 0.1f)
        {
            if(currentTarget < positions.Length - 1)
            {
                currentTarget++;
            }
        }
        
    }
}

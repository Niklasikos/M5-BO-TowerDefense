using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float speed;
    protected Transform[] positions;
    private SpriteRenderer sR;
    private int currentTarget;
    public bool isAlive = true;
    public void Init(Transform[] points)
    {
        positions = points;
    }
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(isAlive)
        {
            if(positions == null)
            {
                return;
            }
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

    public void GetDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            StartCoroutine(Death());
        }
        else
        {
            StartCoroutine(Hit());
        }

    }

    private IEnumerator Death()
    {
        isAlive = false;
        sR.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sR.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        float elapsed = 0f;
        float duration = 1f;
        Color startingC = sR.color;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            sR.color = Color.Lerp(startingC, Color.clear, elapsed / duration);
            yield return null;
        }
        Destroy(gameObject);
        yield return null;
    }

    private IEnumerator Hit()
    {
        sR.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sR.color = Color.white;
    }
}

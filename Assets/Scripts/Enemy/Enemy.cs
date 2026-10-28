using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private int minCoins;
    [SerializeField] private int maxCoins;
    [SerializeField] private GameObject EffectGO;
    [field: SerializeField] public int DamageToPlayer { get; set; }
    private Transform[] positions;
    private SpriteRenderer sR;
    private SpriteRenderer EffectSR;
    private int currentTarget;
    private float speedBeforeEffect;
    private Coroutine effectCoroutine;
    public bool isAlive = true;
    public void Init(Transform[] points)
    {
        positions = points;
    }
    void Start()
    {
        EffectGO.SetActive(false);
        sR = GetComponent<SpriteRenderer>();
        EffectSR = EffectGO.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isAlive)
        {
            if (positions == null)
            {
                return;
            }
            transform.position = Vector2.MoveTowards(transform.position, positions[currentTarget].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, positions[currentTarget].position) < 0.1f)
            {
                if (currentTarget < positions.Length - 1)
                {
                    currentTarget++;
                }
            }
        }

    }

    public void GetDamage(int damage)
    {
        if (!isAlive)
            return;

        health -= damage;

        if (health <= 0)
        {
            isAlive = false;
            StartCoroutine(Death());
        }
        else
        {
            StartCoroutine(Hit());
        }
    }

    public void GetEffect(float time)
    {
        if (effectCoroutine != null)
        {
            StopCoroutine(effectCoroutine);
        }
        else
        {
            EffectGO.SetActive(true);
            speedBeforeEffect = speed;
            speed *= 0.5f;
        }

        effectCoroutine = StartCoroutine(Effect(time));
    }

    private IEnumerator Effect(float time)
    {
        yield return new WaitForSeconds(time);
        speed = speedBeforeEffect;
        EffectGO.SetActive(false);
        effectCoroutine = null;
    }

    private IEnumerator Death()
    {
        int Coins = Random.Range(minCoins, maxCoins);
        LevelManager.Instance.AddCoins(Coins);
        sR.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sR.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        float elapsed = 0f;
        float duration = 1f;
        Color startingC = sR.color;
        Color startingCEffect = EffectSR.color;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            sR.color = Color.Lerp(startingC, Color.clear, elapsed / duration);
            EffectSR.color = Color.Lerp(startingCEffect, Color.clear, elapsed / duration);
            yield return null;
        }
        WaveManager.Instance.EnemyDead();
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

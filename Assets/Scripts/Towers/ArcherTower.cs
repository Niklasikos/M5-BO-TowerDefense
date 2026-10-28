using UnityEngine;
using System.Linq;

public class ArcherTower : Tower
{
    private bool upgraded2 = false;
    private bool upgraded3 = false;
    private CircleCollider2D cc;
    [Header("Spawn Level 1 Stats")]
    [SerializeField] private int damage = 10;
    [SerializeField] private float radius = 3f;
    [SerializeField] private float shootingTimer = 2f;

    [Header("Level 2 Stats")]
    [SerializeField] private int damageAdded2 = 5;
    [SerializeField] private float radiusAdded2 = 0.5f;
    [SerializeField] private float shootingTimerReduced2 = 0.25f;

    [Header("Level 3 Stats")]
    [SerializeField] private int damageAdded3 = 10;
    [SerializeField] private float radiusAdded3 = 1f;
    [SerializeField] private float shootingTimerReduced3 = 0.25f;
    [Space]
    [SerializeField] private GameObject Attack;


    private float elapsed;
    void Awake()
    {
        cc = GetComponent<CircleCollider2D>();
        cc.radius = radius;
    }

    protected override void Update()
    {
        base.Update();
        elapsed += Time.deltaTime;
        if (targets.Count == 0)
            return;

        if (elapsed > shootingTimer)
        {
            GameObject arrow = Instantiate(Attack, transform.position, Quaternion.identity);
            arrow.GetComponent<Projectile>().projectileOptions = ProjectileOptions.Arrow;
            arrow.GetComponent<Projectile>().target = targets.FirstOrDefault(target => target != null);
            arrow.GetComponent<Projectile>().SetDamage(damage);
            elapsed = 0f;
        }
    }

    public void LevelStats(int level)
    {
        switch (level)
        {
            case 1:
                // niks
                break;
            case 2 when !upgraded2:
                damage += damageAdded2;
                cc.radius += radiusAdded2;
                shootingTimer -= shootingTimerReduced2;
                upgraded2 = true;
                break;

            case 3 when !upgraded3:
                damage += damageAdded3;
                cc.radius += radiusAdded3;
                shootingTimer -= shootingTimerReduced3;
                upgraded3 = true;
                break;
            default:
                //blug
                break;
        }
    }
}

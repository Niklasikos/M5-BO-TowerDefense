using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    protected List<GameObject> targets = new List<GameObject>();
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        EnemyRemove();
    }

    protected void EnemyRemove()
    {
        targets.RemoveAll(target =>
        {
            Enemy enemy = target.GetComponent<Enemy>();
            return enemy == null || !enemy.isAlive;
        });        
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        targets.Add(collision.gameObject);
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        targets.Remove(collision.gameObject);
    }
}

using Unity.Mathematics;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GymTower : MonoBehaviour
{
    [SerializeField] private GameObject gymArrow;
    private float shootingTimer = 2f;
    private float elapsed = 0f;
    private List<GameObject> targets = new List<GameObject>();
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (targets.Count == 0)
            return;
        targets.RemoveAll(target =>
        {
            Enemy enemy = target.GetComponent<Enemy>();
            return enemy == null || !enemy.isAlive;
        });
        if (targets.Count == 0)
            return;
        if (elapsed > shootingTimer)
        {
            GameObject arrow = Instantiate(gymArrow, transform.position, quaternion.identity);
            arrow.GetComponent<Arrow>().target = targets.FirstOrDefault(target => target != null);
            elapsed = 0f;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        targets.Add(collision.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        targets.Remove(collision.gameObject);
    }
}

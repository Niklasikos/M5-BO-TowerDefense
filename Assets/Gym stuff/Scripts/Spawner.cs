using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform[] pathpoints;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy() // gonna give the enemys the path on spawn with getcomponent
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            GameObject spawn = Instantiate(enemy1, transform.position, Quaternion.identity);
            Enemy enemy = spawn.GetComponent<Enemy>();
            enemy.Init(pathpoints);            
        }
    }
}
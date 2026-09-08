using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform[] pathpoints;
    [SerializeField] private GameObject enemy01;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy() // gonna give the enemys the path on spawn with getcomponent
    {
        yield return new WaitForSeconds(5f);
        Instantiate(enemy01, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Instantiate(enemy01, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Instantiate(enemy01, transform.position, Quaternion.identity);
        yield return null;
    }
}
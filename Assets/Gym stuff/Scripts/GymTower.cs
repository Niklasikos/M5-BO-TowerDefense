using Unity.Mathematics;
using UnityEngine;

public class GymTower : MonoBehaviour
{
    [SerializeField] private GameObject gymArrow;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject arrow = Instantiate(gymArrow, transform.position, quaternion.identity);
        arrow.GetComponent<GymArrow>().target = collision.gameObject;
    }
}

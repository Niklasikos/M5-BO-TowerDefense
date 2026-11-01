using UnityEngine;

public class FastEnemy : Enemy
{
    [SerializeField] private int Health;
    [SerializeField] private float Speed;
    private void Awake()
    {
       health = Health;
       speed = Speed; 
    }
}

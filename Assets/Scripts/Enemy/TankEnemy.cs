using UnityEngine;

public class TankEnemy : Enemy
{
    [SerializeField] private int Health;
    [SerializeField] private float Speed;
    private void Awake()
    {
       health = Health;
       speed = Speed; 
    }
}

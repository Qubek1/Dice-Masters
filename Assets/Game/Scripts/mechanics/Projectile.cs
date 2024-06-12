using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public DamageType damageType;
    public Player target;
    public float velocity;
    public float acceleration;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.transform.position) < velocity * Time.deltaTime)
        {
            target.TakeDamage(damage, damageType);
            GameManager.effectsRemaining--;
            Destroy(gameObject);
        }
        transform.position += transform.forward * velocity * Time.deltaTime;
        velocity += acceleration * Time.deltaTime;
    }
}

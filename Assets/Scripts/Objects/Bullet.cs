using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 50;
    public float Speed = 350;
    public float MaxLifeTime = 2.5f;
    private float timer_LifeTime = 0;

    void Update()
    {
        timer_LifeTime += Time.deltaTime;
        if (timer_LifeTime > MaxLifeTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Health h = other.gameObject.GetComponent<Health>();
        if (h != null)
        {
            h.Hitted(damage);
        }
        Destroy(gameObject);
    }
}

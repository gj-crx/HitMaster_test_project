using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP = 100;
    public delegate void hitted(float damage);
    /// <summary>
    /// Called each time after object takes damage
    /// </summary>
    public hitted Hitted;

    [SerializeField]
    private GameObject RagdollPrefab;
    private void Awake()
    {
        Hitted = BasicOnHit; //Other scripts can also use this delegate to add diffent effects on hit
    }


    void Update()
    {
        
    }
    private void Die()
    {
        Instantiate(RagdollPrefab, transform.position, transform.rotation);
        GameData.Levels[GameData.GetIndexOutOfName(transform.parent.name)].EnemiesCount--;
        Destroy(gameObject);
    }
    private void BasicOnHit(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _damage;

    [SerializeField] private  float speed;


    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController player))
        {
            player.ReceiveDamage(_damage);
        }

        Kill();
    }

    private void Kill()
    {
        gameObject.SetActive(false);
    }
}

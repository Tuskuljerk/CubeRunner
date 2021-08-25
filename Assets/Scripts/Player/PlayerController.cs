using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private float _speed;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    
    private void Start()
    {
        //_targetPosition = transform.position;
        HealthChanged?.Invoke(_health);
    }

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        float yAxis = Input.GetAxis("Vertical");

        Vector3 _playerPosition = transform.position;

        _playerPosition.y += yAxis * _speed * Time.deltaTime;
        transform.position = _playerPosition;
        

    }


    public void ReceiveDamage(int _damage)
    {
        _health -= _damage;
        HealthChanged?.Invoke(_health);
        Debug.Log(_health);
        if (_health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {

        Died?.Invoke();
        
    }
}

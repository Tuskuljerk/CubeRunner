using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private Heart _heart;

    private List<Heart> _hearts = new List<Heart>();


    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if(_hearts.Count < value)
        {
            int createHealth = value - _hearts.Count;
            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }
        } else if (_hearts.Count > value)
        {
            int deleteHealth = _hearts.Count - value;
            for (int i = 0; i < deleteHealth; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heart, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());

        newHeart.ToFill();
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}

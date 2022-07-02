using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] public UnityEvent _onDamage;
        [SerializeField] public UnityEvent _onDeath;
        [SerializeField] public OnChangedHealth _onChange;

        public int Health => _health;

        public void ModifyHealth(int value)
        {
            _health += value;
            _onChange?.Invoke(value);
            if (value < 0)
            {
                _onDamage?.Invoke();
            }
            if (_health <= 0)
            {
                _onDeath?.Invoke();
            }
        }

        public void SetHealth(int health)
        {
            _health = health;
        }

    }

    [Serializable]
    public class OnChangedHealth : UnityEvent<int>
    {

    }
}

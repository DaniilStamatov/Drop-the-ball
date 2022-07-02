using Assets.Scripts.Components;
using Assets.Scripts.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onDestinationReached;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private HealthComponent _health;
        [SerializeField] private TextMeshPro _text;
        private BallSettings _settings;
        private Player _player;

        private void Start()
        {
            GetComponent<MoveUp>().OnShootHappend();
            _health = GetComponent<HealthComponent>();
            _health.SetHealth(_settings.Health);
            _player = FindObjectOfType<Player>();

            _text = gameObject.transform.GetChild(0).GetComponent<TextMeshPro>();
            _health._onChange.AddListener(UpdateHealth);
            UpdateHealth(_health.Health);
        }

        public void Init(in BallSettings settings)
        {
            _settings = settings;
        }

        private void PlayParticle()
        {
            var particle = Instantiate(_particle, transform.position, Quaternion.identity);
            var main = particle.main;
            particle.Play();
        }

        public void UpdateHealth(int health)
        {
            health = _health.Health;
            _text.text = health.ToString();
        }

        private void FixedUpdate()
        {
            if (transform.position.y >= _settings.Destination.y)
            {
                _onDestinationReached?.Invoke();
                PlayParticle();
                Destroy(gameObject);
            }
        }

        public void AddScore()
        {
            _player.AddScore(1);
            Debug.Log(_player.Current);
        }

        private void OnDestroy()
        {
            _health._onChange.RemoveListener(UpdateHealth);
        }
    }
    public struct BallSettings
    {
        public Vector3 Destination;
        public int Health;
        public float speed;
    }
}
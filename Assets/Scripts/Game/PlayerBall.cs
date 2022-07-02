using Assets.Scripts.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Game
{
    public class PlayerBall : MonoBehaviour
    {
        [SerializeField] private GameObject _ball;
        [SerializeField] private float _ballSpeed;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private GameObject _point;
        [SerializeField] private int _numberOfPoints;
        [SerializeField] private float _spaceBetweenPoints;
        
        private GameObject[] _points;
        private Vector2 _direction;

        public event Action OnShoot;


        private void Start()
        {
            _points = new GameObject[_numberOfPoints];
            for (int i = 0; i < _numberOfPoints; i++)
            {
                _points[i] = Instantiate(_point, _shootPoint.position, Quaternion.identity, _shootPoint);
            }
        }

        private void SetRotation()
        {
            Vector2 position = transform.position;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _direction = mousePosition - position;
            transform.right = _direction;
        }

        private void Update()
        {
            SetRotation();
            if (Input.GetMouseButtonDown(0))
            {
                Throw();
                OnShoot?.Invoke();
            }

            for (var i = 0; i < _numberOfPoints; i++)
            {
                _points[i].transform.position = PointPosition(i * _spaceBetweenPoints);
            }
        }

        private void Throw()
        {
            GameObject ball = Instantiate(_ball, _shootPoint.position, _shootPoint.rotation);
            ball.GetComponent<Rigidbody2D>().velocity = transform.right * _ballSpeed;
            
        }

        private Vector2 PointPosition(float time)
        {
            Vector2 position = (Vector2)_shootPoint.position + (_direction.normalized * _ballSpeed * time) + 0.5f * Physics2D.gravity * (time * time);
            return position;
        }

     
    }
}

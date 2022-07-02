using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class MoveUp : MonoBehaviour
    {
        [SerializeField] private float _step;

        public Vector2 _newPosition;

        private PlayerBall _ball;

        private void Start()
        {
            _ball = FindObjectOfType<PlayerBall>();
            _ball.OnShoot += OnShootHappend;
        }



        public void OnShootHappend()
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + _step), _step);
        }

        private void OnDestroy()
        {
            _ball.OnShoot -= OnShootHappend;
        }

    }
}

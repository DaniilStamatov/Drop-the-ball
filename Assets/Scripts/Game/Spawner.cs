using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] [Range(0f, 0.5f)] private float _constraint;
        [SerializeField] private Camera _camera;
        [SerializeField] private Ball _prefab;
        [SerializeField] private float _size;
        private PlayerBall _playerBall;

        private void Start()
        {
            _playerBall = FindObjectOfType<PlayerBall>();
            SpawnAll();
            _playerBall.OnShoot += SpawnAll;
        }

        private void Spawn()
        {
            var startPosition = GetRandomPosition(0f);
            var destination = new Vector3(startPosition.x, startPosition.y + 4f, startPosition.z);

            var settings = new BallSettings()
            {
                speed = 100f,
                Destination = destination,
                Health = Random.Range(1, 5),
            };


            Instantiate(_prefab, startPosition, Quaternion.identity).Init(settings);

        }

        private void SpawnAll()
        {
            var size = Random.Range(1, 4);
            var balls = new Ball[size];


            foreach (var ball in balls)
            {
                Spawn();
            }

        }

        private void OnDestroy()
        {
            _playerBall.OnShoot -= SpawnAll;
        }

        private Vector3 GetRandomPosition(float screenY)
            => _camera.ViewportToWorldPoint(new Vector3(Random.Range(0f + _constraint, 1f - _constraint), screenY, 20f));
    }
}

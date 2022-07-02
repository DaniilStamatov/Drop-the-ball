using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class BallPrefab: MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            StartCoroutine(Countdown());
        }


        private IEnumerator Countdown()
        {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }
    }
}

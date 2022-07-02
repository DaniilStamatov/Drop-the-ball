using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    public class EnterTriggerDetector : MonoBehaviour
    {

        [SerializeField] private InterEvent _event;
        [SerializeField] private string _tag;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                _event?.Invoke(other.gameObject);
            }
        }

    }
    [Serializable]
    public class InterEvent : UnityEvent<GameObject>
    {
    }
}


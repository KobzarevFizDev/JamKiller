using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.HandItem
{
    public class BottleSoulItem : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;


        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }

        public void Throw(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
        }

    }
}

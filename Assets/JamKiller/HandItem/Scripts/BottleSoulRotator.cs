using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.HandItem
{
    public class BottleSoulRotator : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private void Update()
        {
            transform.rotation *= Quaternion.Euler(0, _speed * Time.deltaTime, 0);
        }

    }
}

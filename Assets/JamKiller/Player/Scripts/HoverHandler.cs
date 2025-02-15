using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.Player
{
    public class HoverHandler : MonoBehaviour
    {
        [SerializeField] private Transform _raycastPoint;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _hoverHeight = 0.2f;
        [SerializeField] private float _dampingFactor = 0.2f;
        [SerializeField] private float _springStrength = 4f;

        private LayerMask _layerMask;

        private bool _isActiveHover = true;

        public bool IsGrounded { private set; get; }

        private void Start()
        {
            _layerMask = LayerMask.GetMask("Ground");
        }

        public void DeactivateHover()
        {
            _isActiveHover = false;
        }

        public void ActivateHover()
        {
            _isActiveHover = true;
        }

        private void FixedUpdate()
        {
            if (_isActiveHover == false)
            {
                IsGrounded = false;
                return;
            }

            if (Physics.Raycast(_raycastPoint.position, Vector3.down, out RaycastHit hit, 1f, _layerMask))
            {
                float distanceToGround = hit.distance;
                float x = distanceToGround - _hoverHeight;
                float force = -_springStrength * x - _dampingFactor * _rigidbody.velocity.y;
                Vector3 forceDir = force * Vector3.up;
                _rigidbody.AddForce(forceDir, ForceMode.Impulse);
                IsGrounded = true;
            }
        }
    }
}

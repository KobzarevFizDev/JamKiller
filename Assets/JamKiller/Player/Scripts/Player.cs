using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JamKiller.Units;

namespace JamKiller.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private HoverHandler _hoverHandler;
        [SerializeField] private float _jumpHeight = 2f;
        [SerializeField] private float _moveForce = 5f;
        [SerializeField] private float _maxSpeed = 5f;
        [SerializeField] private float _acceleration = 5f;

        private float _jumpSpeed => (float)Math.Sqrt(2 * -Physics.gravity.y * _jumpHeight);

        public bool IsGrounded => _hoverHandler.IsGrounded;

        private Coroutine _jumpRoutine;

        public void Jump()
        {
            if (_jumpRoutine != null)
                StopCoroutine(_jumpRoutine);
            _jumpRoutine = StartCoroutine(JumpRoutine());
        }

        public void ApplyRot(float lookBackward)
        {
            _rigidbody.angularVelocity = Vector3.zero;
            Quaternion rot = Quaternion.Euler(0, lookBackward, 0);
            _rigidbody.MoveRotation(rot);
        }

        public void Move(float moveForward, float moveBackward)
        {
            Vector3 dir = transform.forward * moveForward + transform.right * moveBackward;
            dir = Vector3.ClampMagnitude(dir, 1f);
            Vector3 currentVelocity = _rigidbody.velocity;


            if (moveForward * moveForward + moveBackward * moveBackward > 0)
            {
                Vector3 targetVelocity = dir * _maxSpeed;
                targetVelocity.y = _rigidbody.velocity.y;
                currentVelocity.x = Mathf.Lerp(currentVelocity.x, targetVelocity.x, Time.fixedDeltaTime * _acceleration);
                currentVelocity.z = Mathf.Lerp(currentVelocity.z, targetVelocity.z, Time.fixedDeltaTime * _acceleration);
            }
            else if (_hoverHandler.IsGrounded)
            {
                currentVelocity.x = Mathf.Lerp(currentVelocity.x, 0, Time.fixedDeltaTime * _acceleration);
                currentVelocity.z = Mathf.Lerp(currentVelocity.z, 0, Time.fixedDeltaTime * _acceleration);

            }

            _rigidbody.velocity = currentVelocity;
        }

        private IEnumerator JumpRoutine()
        {
            _hoverHandler.DeactivateHover();
            _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
            yield return new WaitForFixedUpdate();
            yield return new WaitUntil(() => _rigidbody.velocity.y <= 0);
            _hoverHandler.ActivateHover();
        }
    }

}

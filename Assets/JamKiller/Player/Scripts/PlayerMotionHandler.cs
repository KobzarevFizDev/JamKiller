using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using JamKiller.Cameras;

namespace JamKiller.Player
{
    public class PlayerMotionHandler : MonoBehaviour
    {
        [SerializeField] private float _maxLookUpLimit = 40f;
        [SerializeField] private float _lookSmoothing = 10f;

        private float _lookUp;
        private float _lookBackward;

        private float _smoothedLookUp;
        private float _smoothedLookBackward;

        private float _moveForward;
        private float _moveBackward;


        private Player _player;
        private PlayerCamera _playerCamera;

        [Inject]
        private void Constructor(Player player, PlayerCamera playerCamera)
        {
            _player = player;
            _playerCamera = playerCamera;
        }

        public void HandleLookInput(float deltaLookUp, float deltaLookBackward)
        {
            _lookUp -= deltaLookUp;
            _lookBackward += deltaLookBackward;
            _lookUp = Mathf.Clamp(_lookUp, -_maxLookUpLimit, _maxLookUpLimit);

            _smoothedLookUp = Mathf.Lerp(_smoothedLookUp, _lookUp, _lookSmoothing * Time.deltaTime);
            _smoothedLookBackward = Mathf.Lerp(_smoothedLookBackward, _lookBackward, _lookSmoothing * Time.deltaTime);
        }

        public void HandleMoveInput(float moveForward, float moveBackward)
        {
            _moveForward = moveForward;
            _moveBackward = moveBackward;
        }

        public void HandleJump()
        {
            if (_player.IsGrounded)
                _player.Jump();
        }

        private void FixedUpdate()
        {
            _player.Move(_moveForward, _moveBackward);
            _player.ApplyRot(_smoothedLookBackward);
        }

        private void LateUpdate()
        {
            Vector3 playerPos = _player.transform.position;
            _playerCamera.SetPosition(playerPos);
            _playerCamera.SetRotation(_smoothedLookUp, _smoothedLookBackward);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace JamKiller.Player
{

    public class PlayerMotionInputHandler: ITickable, ILateDisposable
    {
        private PlayerMotionHandler _playerMotionHandler;
        private float _lookSens;
        private InputMaster _inputMaster;

        public PlayerMotionInputHandler(PlayerMotionHandler playerMotionHandler, float lookSens)
        {
            _playerMotionHandler = playerMotionHandler;
            _lookSens = lookSens;

            _inputMaster = new InputMaster();
            _inputMaster.Enable();

            _inputMaster.Player.Jump.performed += OnJump;
        }

        private void OnJump(InputAction.CallbackContext obj)
        {
            _playerMotionHandler.HandleJump();
        }

        void ITickable.Tick()
        {
            ReadLookInput();
            ReadMoveInput();
        }

        private void ReadLookInput()
        {
            var lookInput = Mouse.current.delta.ReadValue();
            float deltaLookUp = lookInput.y * _lookSens;
            float deltaLookBackward = lookInput.x * _lookSens;

            _playerMotionHandler.HandleLookInput(deltaLookUp, deltaLookBackward);
        }

        private void ReadMoveInput()
        {
            var moveInput = _inputMaster.Player.Move.ReadValue<Vector2>();
            float moveForward = moveInput.y;
            float moveBackward = moveInput.x;

            _playerMotionHandler.HandleMoveInput(moveForward, moveBackward);
        }


        void ILateDisposable.LateDispose()
        {
            _inputMaster.Player.Jump.performed -= OnJump;
        }
    }
}

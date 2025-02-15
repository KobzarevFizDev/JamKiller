using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.Cameras
{

    public class PlayerCamera : MonoBehaviour
    {
        [field: SerializeField] public Camera Camera { private set; get; }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(float lookUp, float lookBackward)
        {
            transform.rotation = Quaternion.Euler(lookUp, lookBackward, 0);
        }
    }
}

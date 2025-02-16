using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace JamKiller.Units
{
    public class UnitAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private int _forwardHash = Animator.StringToHash("Forward");
        private int _backwardHash = Animator.StringToHash("Backward");

        private void Start()
        {
            


        }
    }
}

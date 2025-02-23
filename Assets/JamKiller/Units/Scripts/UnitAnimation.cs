using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.VFX;

namespace JamKiller.Units
{
    public class UnitAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private VisualEffect _fireVFX;

        private int _forwardHash = Animator.StringToHash("Forward");
        private int _backwardHash = Animator.StringToHash("Backward");
        private int _fireSpellHash = Animator.StringToHash("Spell");

        private void Awake()
        {
            _fireVFX.Stop();
        }

        private void Start()
        {

            _animator.SetFloat(_forwardHash, 1f);
            _animator.SetFloat(_backwardHash, 0f);

        }

        private void Update()
        {
            
        }

        public void PlaySpellFire()
        {
            _animator.SetTrigger(_fireSpellHash);
        }

        public void StartSpell()
        {
            _fireVFX.Play();
        }

        public void FinishSpell()
        {
            _fireVFX.Stop();
        }
    }
}

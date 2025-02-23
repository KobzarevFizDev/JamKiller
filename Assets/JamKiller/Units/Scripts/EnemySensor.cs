using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.Units
{
    public class EnemySensor : MonoBehaviour
    {
        [Range(10f, 270f)]
        [SerializeField] private float _fov = 60;
        [Range(1f, 50f)]
        [SerializeField] private float _distanceDetect = 10f;

        private LayerMask _detectMask;

        private void Awake()
        {
            _detectMask = LayerMask.GetMask("Unit");
        }

        public bool CheckEnemy(TeamId teamOfUnit, out IUnit enemyUnit)
        {
            enemyUnit = null;

            float startAngle = -_fov / 2f;
            float finishAngle = _fov / 2f;
            int numberOfRays = 10;
            for(int i = 0; i < numberOfRays; i++)
            {
                float t = (float)i / (numberOfRays - 1);
                float angle = Mathf.Lerp(startAngle, finishAngle, t);
                Quaternion rot = Quaternion.Euler(0, angle, 0);
                Vector3 dir = rot * transform.forward;

                Debug.DrawLine(transform.position, transform.position + dir * _distanceDetect, Color.yellow);

                bool detected = Physics.Raycast(transform.position, dir, out RaycastHit hitInfo, _distanceDetect, _detectMask);
                if (detected)
                {
                    if (hitInfo.transform.gameObject.TryGetComponent<IUnit>(out IUnit findedUnit))
                    {
                        enemyUnit = findedUnit;
                        return true;
                    }
                    else
                    {
                        throw new System.InvalidOperationException("Incorrect layer mask for enemy sensor");
                    }
                }
            
            }

            return false;
        }
    }
}

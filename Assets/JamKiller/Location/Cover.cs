using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;
using JamKiller.Player;
using JamKiller.GOB;

namespace JamKiller.Location
{
    public class Cover : MonoBehaviour
    {
        [SerializeField] private BoxCollider _boxCollider;

        private Player.Player _player;

        private LayerMask _layerMask;
        public Vector3 Pivot => transform.position + _boxCollider.center;

        [Inject]
        private void Constructor(Player.Player player)
        {
            _player = player;
            _layerMask = LayerMask.GetMask("Cover");
        }

        public bool TryGetSafePosition(out Vector3 safePosition)
        {
            safePosition = Vector3.zero;

            Vector3 playerPosition = _player.transform.position;
  
            Vector3 dir = Vector3.Normalize(Pivot - playerPosition);

            RaycastHit[] hits = Physics.RaycastAll(playerPosition, dir, 100f, _layerMask);
            bool hasSafePlace = hits.Length > 0;

            Debug.DrawLine(playerPosition, Pivot, Color.green);

            if (hasSafePlace)
            {
                RaycastHit hitInfo = hits.OrderBy(h => (h.point - Pivot).sqrMagnitude).First();
                Vector3 offset = Pivot - hitInfo.point;
                safePosition = Pivot + offset;
                safePosition.y = 0;
            }

            return hasSafePlace;
        }
    }
}

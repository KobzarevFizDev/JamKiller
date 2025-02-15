using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JamKiller.HandItem
{
    public class HandItemFactory 
    {
        private const string PATH_TO_PREFAB = "BottleSoul";

        private BottleSoulItem _bottleSoulPrefab;
        
        public HandItemFactory()
        {
            LoadPrefab();
        }

        public BottleSoulItem CreateBottle(Vector3 pos, Quaternion rot)
        {
            var createdBottle = GameObject.Instantiate<BottleSoulItem>(_bottleSoulPrefab);
            createdBottle.transform.SetPositionAndRotation(pos, rot);
            return createdBottle;
        }

        private void LoadPrefab()
        {
            _bottleSoulPrefab = Resources.Load<BottleSoulItem>(PATH_TO_PREFAB);
            if (_bottleSoulPrefab == null)
                throw new System.ArgumentException($"Not found prefab with path = {PATH_TO_PREFAB}");
        }
    }
}

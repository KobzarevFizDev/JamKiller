using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Cameras;
using JamKiller.HandItem;
using Zenject;


namespace JamKiller.Player
{

    public class PlayerActionHandler : MonoBehaviour
    {
        private PlayerCamera _playerCamera;
        private HandItemFactory _handItemFactory;
        private UICamera _uiCamera;

        [Inject]
        private void Constructor(PlayerCamera playerCamera, 
                                 UICamera uiCamera,
                                 HandItemFactory handItemFactory)
        {
            _playerCamera = playerCamera;
            _uiCamera = uiCamera;
            _handItemFactory = handItemFactory;
        }

        public void ThrowBottle(Transform from)
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            Vector3 fromScreenPos = RectTransformUtility.WorldToScreenPoint(_uiCamera.Camera, from.position);
            Vector3 fromWorldPos = _playerCamera.Camera.ScreenToWorldPoint(new Vector3(fromScreenPos.x, fromScreenPos.y, 1f));

            Ray ray = _playerCamera.Camera.ScreenPointToRay(screenCenter);
            Vector3 toWorldPos;
            if(Physics.Raycast(ray, out RaycastHit hit))
                toWorldPos = hit.point;
            else
                toWorldPos = _playerCamera.Camera.ScreenToWorldPoint(new Vector3(screenCenter.x, screenCenter.y, 100f));
            Vector3 throwDir = Vector3.Normalize((toWorldPos - fromWorldPos));

            BottleSoulItem createdBottle = _handItemFactory.CreateBottle(fromWorldPos, Quaternion.identity);
            createdBottle.Throw(throwDir * 20f);


        }
    }
}

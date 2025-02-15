using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace JamKiller.HandItem
{
    public class ThrowHandItem : MonoBehaviour
    {
        [SerializeField] private RectTransform _handItemImage;
        
        private HandItemFactory _bottleSoulFactory;

        [Inject]
        private void Constructor(HandItemFactory bottleSoulFactory)
        {
            _bottleSoulFactory = bottleSoulFactory;
        }


        public void Throw()
        {
            //RectTransformUtility.ScreenPointToWorldPointInRectangle(_handItemImage, _handItemImage.)
        }
    }
}

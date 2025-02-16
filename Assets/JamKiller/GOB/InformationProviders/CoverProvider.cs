using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.Location;
using JamKiller.GOB;
using System.Linq;

namespace JamKiller.Location
{
    public class CoverProvider
    {
        private Cover[] _covers;

        public CoverProvider(Cover[] covers)
        {
            _covers = covers;
        }

        public Cover GetNearestCover(IUnit unit)
        {
            Cover nearestCover =  _covers.OrderBy(c => (c.Pivot - unit.GetPosition()).sqrMagnitude).FirstOrDefault();
            if (nearestCover == null)
                throw new System.ArgumentException("Not fund neares cover");

            return nearestCover;
        }
    }
}

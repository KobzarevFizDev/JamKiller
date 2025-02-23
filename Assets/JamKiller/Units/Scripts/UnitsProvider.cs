using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JamKiller.GOB;
using System.Linq;

namespace JamKiller.Units
{
    public enum TeamId { Player, PC }

    public class UnitsProvider : MonoBehaviour
    {
        [SerializeField] private MoqUnit[] _units;

        public IUnit GetEnemyUnitForTeam(TeamId teamId)
        {
            MoqUnit unit = _units.FirstOrDefault(u => u.GetTeamId() != teamId);
            return unit.GetComponent<IUnit>();
        }
    }
}

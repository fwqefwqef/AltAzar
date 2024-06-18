using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltAzar
{
    internal class AltAzar_Fantasy_Ex : Skill_Extended, IP_TurnEnd
	{
		public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
		{
			BattleSystem.instance.AllyTeam.AP += 1;
		}

        public void TurnEnd()
        {
            this.SelfDestroy();
        }
    }
}

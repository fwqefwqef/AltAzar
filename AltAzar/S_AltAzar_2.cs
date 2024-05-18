using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltAzar
{
    public class S_AltAzar_2 : Skill_Extended
	{
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingle(SkillD, Targets);
            AltAzar_Ex_0.SwordAdd(this.BChar, -1);
            AltAzar_Ex_0.SwordAdd(this.BChar, 0);

        }
    }
}

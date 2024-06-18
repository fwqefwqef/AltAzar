using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltAzar
{
    internal class S_AltAzar_SwordInfinity : Skill_Extended
	{
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
			{
				if (skill != this.MySkill && skill.ExtendedFind_DataName("AltAzar_Ex_0") == null)
				{
					AltAzar_Ex_0.Add(skill, this.BChar);
				}
			}
		}
	}
}

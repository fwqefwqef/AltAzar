using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;

namespace AltAzar
{
	internal class S_AltAzar_StormingBlade : Skill_Extended, IP_SkillUse_Team
	{
		public override void Init()
		{
			base.Init();
			this.UseNum = 0;
		}
		public override void FixedUpdate()
		{
			this.APChange = -this.UseNum;
		}

		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			this.UseNum = 0;
		}

		public void SkillUseTeam(Skill skill)
		{

			if (skill.AP == 1 && skill.NotCount == true)
			{
				this.UseNum++;
			}
			else if (skill.AP == 2 && skill.NotCount == false)
			{
				this.UseNum++;
			}
			else if (skill.MySkill.KeyID == GDEItemKeys.Skill_S_Azar_P_0)
            {
				this.UseNum++;
			}
		}

		// Token: 0x04000D53 RID: 3411
		public int UseNum;
	}
}

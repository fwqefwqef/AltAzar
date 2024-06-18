using System;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;

namespace AltAzar
{
    internal class B_AltAzar_DancingSword : Buff, IP_SkillUse_Team_Target
	{
		public IEnumerator Effect(BattleChar Target)
		{
			yield return new WaitForSeconds(0.06f);
			Skill skill = Skill.TempSkill(GDEItemKeys.Skill_S_Azar_2_Plus, this.BChar, this.BChar.MyTeam);
			Skill_Extended extend = new Skill_Extended();
			extend.PlusPerStat.Damage = 50;
			skill.ExtendedAdd(extend);

			skill.PlusHit = true;
			this.BChar.ParticleOut(skill, Target);
			yield break;
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x0007CB58 File Offset: 0x0007AD58
		public void SkillUseTeam_Target(Skill skill, List<BattleChar> Targets)
		{
			if (!skill.FreeUse && !Targets[0].Info.Ally)
			{
				foreach (BattleChar target in Targets)
				{
					BattleSystem.DelayInput(this.Effect(target));
				}
			}
		}
	}
}

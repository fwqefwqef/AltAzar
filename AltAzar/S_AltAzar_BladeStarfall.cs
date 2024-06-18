using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;
using UnityEngine;

namespace AltAzar
{
	public class S_AltAzar_BladeStarfall : Skill_Extended
	{
		public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
		{
			int num = 0;
			List<Skill> list = new List<Skill>();
			list.AddRange(this.BChar.MyTeam.Skills);

			List<Skill> hand = BattleSystem.instance.AllyTeam.Skills;
			for (int i = 0; i < hand.Count; i++)
			{
				if (hand[i].MySkill.KeyID == GDEItemKeys.Skill_S_Azar_P_0)
				{
					hand[i].Delete(false);
					i--;
					num++;
				}
			}

			BattleSystem.DelayInput(this.Wait());
			for (int i = 0; i < num; i++)
			{
				BattleSystem.DelayInput(this.Effect());
				BattleSystem.DelayInput(this.Wait());
			}
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x0007C39C File Offset: 0x0007A59C
		public IEnumerator Effect()
		{
			for (int i = 0; i < BattleSystem.instance.EnemyList.Count; i++)
			{
				Skill skill = Skill.TempSkill(GDEItemKeys.Skill_S_Azar_2_Plus, this.BChar, this.BChar.MyTeam);
				Skill_Extended extend = new Skill_Extended();
				extend.PlusPerStat.Damage = 50;
				skill.ExtendedAdd(extend);
				if (BattleSystem.instance.EnemyList.Count == 1)
				{
					skill.ExtendedAdd_Battle(new Extended_Cri100());
				}
				skill.NoAttackTimeWait = true;
				skill.PlusHit = true;
				this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.EnemyList[i]);
			}
			yield return new WaitForSeconds(0.1f);
			yield break;
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x0007C3AB File Offset: 0x0007A5AB
		public IEnumerator Wait()
		{
			yield return new WaitForSeconds(0.15f);
			yield break;
		}
	}
}

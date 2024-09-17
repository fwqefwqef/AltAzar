using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AltAzar
{
	public class S_AltAzar_IllusionFlash : Skill_Extended
	{

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0007C488 File Offset: 0x0007A688
		public override string DescExtended(string desc)
		{
			return base.DescExtended(desc).Replace("&a", this.illusionSkill.TargetDamage.ToString());
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x0007C4BC File Offset: 0x0007A6BC
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			int num = 0;
			foreach (Skill skill in this.BChar.MyTeam.Skills)
			{
				if (skill.MySkill.KeyID == GDEItemKeys.Skill_S_Azar_P_0)
				{
					num++;
				}
				//if (skill.ExtendedFind("Azar_Ex_0", true) != null)
				//{
				//	num++;
				//}
				//if (skill.ExtendedFind("AltAzar_Ex_0", true) != null)
    //            {
				//	num++;
    //            }
			}
			BattleSystem.DelayInput(this.Effect(Targets[0], num));
			
			// delete all illusion sword on the hand
			List<Skill> hand = BattleSystem.instance.AllyTeam.Skills;
			for (int i = 0; i < hand.Count; i++)
			{
				if (hand[i].MySkill.KeyID == GDEItemKeys.Skill_S_Azar_P_0)
				{
					hand[i].Delete(false);
					i--;
				}
			}
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0007C554 File Offset: 0x0007A754
		public override void Init()
		{
			base.Init();
			this.illusionSkill.Init(new GDESkillData(GDEItemKeys.Skill_S_Azar_3_Plus), this.BChar, this.BChar.MyTeam);
			Skill_Extended extend = new Skill_Extended();
			extend.PlusPerStat.Damage = 60;
			this.illusionSkill.ExtendedAdd(extend);
			this.illusionSkill.PlusHit = true;
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x0007C58E File Offset: 0x0007A78E
		public IEnumerator Effect(BattleChar Target, int Count)
		{
			yield return new WaitForSeconds(0.1f);
			int num;
			for (int i = 0; i < Count; i = num + 1)
			{
				if (BattleSystem.instance.EnemyTeam.AliveChar_GetInstance().Count != 0)
				{
					Skill skill = Skill.TempSkill(GDEItemKeys.Skill_S_Azar_3_Plus, this.BChar, this.BChar.MyTeam);
					skill.PlusHit = true;
					Skill_Extended extend = new Skill_Extended();
					extend.PlusPerStat.Damage = 60;
					skill.ExtendedAdd(extend);

					if (Target.IsDead && BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
					{
						this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
					}
					else
					{
						this.BChar.ParticleOut(this.MySkill, skill, Target);
					}
				}
				yield return new WaitForSeconds(0.07f);
				num = i;
			}
			yield break;
		}

		// Token: 0x04000D51 RID: 3409
		private Skill illusionSkill = new Skill();
	}
}

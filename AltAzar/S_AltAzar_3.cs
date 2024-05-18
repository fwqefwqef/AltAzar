using GameDataEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AltAzar
{
    public class S_AltAzar_3 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
			List<Skill> hand = BattleSystem.instance.AllyTeam.Skills;

			int num = -5;
			for (int i = 0; i < hand.Count; i++)
			{
				if (hand[i] == this.MySkill)
				{
					num = i;
					break;
				}
			}

				Skill skill = Skill.TempSkill("S_Azar_3_Plus", BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam);
				Skill_Extended damage = new Skill_Extended();
				damage.PlusPerStat.Damage = 50;
				skill.ExtendedAdd(damage);

				for (int i = 0; i < hand.Count; i++)
				{
					if (hand[i].MySkill.KeyID == GDEItemKeys.Skill_S_Azar_P_0)
                    {
						BattleSystem.DelayInput(this.Attack(skill, Targets[0]));
						hand[i].Delete(false);
						i--;
					}
				}
		}
		public IEnumerator Attack(Skill skill, BattleChar target)
		{
			yield return new WaitForSeconds(0.1f);


			if (target.IsDead)
			{
				this.BChar.ParticleOut(skill, this.BChar.BattleInfo.EnemyList.Random<BattleEnemy>());
			}
			else
			{
				this.BChar.ParticleOut(skill, target);
			}
			yield break;
		}
	}
}

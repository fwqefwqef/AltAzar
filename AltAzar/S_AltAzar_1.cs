using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;
using UnityEngine;

namespace AltAzar
{
    public class S_AltAzar_1 : Skill_Extended
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
			int cast = 0;
			if (num > 0) // not at top of hand
			{
				if (hand[num - 1].MySkill.KeyID == GDEItemKeys.Skill_S_Azar_P_0)
                {
					// autocast it
					BattleSystem.DelayInput(this.Attack(hand[num - 1], Targets[0]));
					hand[num - 1].Delete(false);
					cast++;
				}
			}

			num = -5; // re-find location of ascending slice
			for (int i = 0; i < hand.Count; i++)
			{
				if (hand[i] == this.MySkill)
				{
					num = i;
					break;
				}
			}

			if (num >= 0 && num <= BattleSystem.instance.AllyTeam.Skills.Count - 1) // not at bottom of hand
			{
				if (hand[num + 1].MySkill.KeyID == GDEItemKeys.Skill_S_Azar_P_0)
				{
					BattleSystem.DelayInput(this.Attack(hand[num + 1], Targets[0]));
					hand[num + 1].Delete(false);
					cast++;
				}
			}

			for (int i = 0; i < cast; i++) // return swords to top of hand...
            {
				AltAzar_Ex_0.SwordAdd(this.BChar, 0);
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;
using UnityEngine;

namespace AltAzar
{
    public class S_AltAzar_AscendingSlice : Skill_Extended
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
			for (int i=num+1; i < hand.Count; i++)
            {
				if (hand[i].MySkill.KeyID == GDEItemKeys.Skill_S_Azar_P_0)
                {
					BattleSystem.DelayInput(this.Attack(hand[i], Targets[0]));
					hand[i].Delete(false);
					cast++;
					i--;
				}
			}

			for (int i = 0; i < cast; i++) // return swords to top of hand...
            {
				AltAzar_Ex_0.SwordAdd(this.BChar, 0);
            }
		}

		public IEnumerator Attack(Skill skill, BattleChar target)
		{
			yield return new WaitForSeconds(0.05f);

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

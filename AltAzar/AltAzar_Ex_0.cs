using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;
using UnityEngine;

namespace AltAzar
{
	public class AltAzar_Ex_0 : Skill_Extended
	{
		public static int num = -1;
		public override void FixedUpdate() 
		{
			base.FixedUpdate();
			if (this.MasterChar.IsDead)
			{
				this.SelfDestroy();
			}

			// keep updating the position of the sword in hand
			List<Skill> hand = BattleSystem.instance.AllyTeam.Skills;
			for (int i = 0; i < hand.Count; i++)
			{
				if (hand[i] == this.MySkill)
				{
					num = i;
					break;
				}
			}
		}

		public override void SkillUseHand(BattleChar Target)
		{
			List<Skill> hand = BattleSystem.instance.AllyTeam.Skills;
            //Debug.Log("Illusion Sword buff location " + num);
            AltAzar_Ex_0.SwordAdd(this.MasterChar, -1);
		}

		public override void DiscardSingle(bool Click)
		{
			List<Skill> hand = BattleSystem.instance.AllyTeam.Skills;
            //Debug.Log("Illusion Sword buff location " + num);
			AltAzar_Ex_0.SwordAdd(this.MasterChar, -1);
		}

		public static void Add(Skill skill, BattleChar User)
		{
			if (skill.ExtendedFind_DataName(GDEItemKeys.SkillExtended_Azar_Ex_0) == null)
			{
				AltAzar_Ex_0 azar_Ex_ = Skill_Extended.DataToExtended("AltAzar_Ex_0") as AltAzar_Ex_0;
				azar_Ex_.MasterChar = User;
				skill.ExtendedAdd(azar_Ex_);
			}
			Debug.Log("Added Illusion Buff");
		}

		public static void SwordAdd(BattleChar bc, int num)
        {
            Skill skill = Skill.TempSkill(GDEItemKeys.Skill_S_Azar_P_0, bc, bc.MyTeam);
            skill.NotCount = true;
            skill.isExcept = true;
            skill.AutoDelete = 2; // discard after 2 turns
            skill.AP = 1;
            skill.MySkill.UseAp = 1;

            Skill sword = skill.CloneSkill(false, null, null, false);
            Skill_Extended damage = new Skill_Extended();
            damage.PlusPerStat.Damage = 50;
            sword.ExtendedAdd(damage);


            if (num == -1) // bottom index
            {
                bc.MyTeam.Add(sword, true);
            }
            else
            {
                //bc.MyTeam.Add(sword, true);
                bc.MyTeam.Add(skill, true, num);
				//BattleSystem.DelayInput(Wait());
			}
			Debug.Log("Added Illusion Sword to hand");
		}
		public static IEnumerator Wait()
		{
			yield return new WaitForSeconds(0.2f);
			yield break;
		}

		public BattleChar MasterChar;
	}
}

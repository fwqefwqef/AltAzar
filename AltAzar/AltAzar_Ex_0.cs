using System;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;

namespace AltAzar
{
	public class AltAzar_Ex_0 : Skill_Extended
	{
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			AltAzar_Ex_0.SwordAdd(this.MasterChar, 1);
		}

		public override void DiscardSingle(bool Click)
		{
			AltAzar_Ex_0.SwordAdd(this.MasterChar, 1);
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (this.MasterChar.IsDead)
			{
				this.SelfDestroy();
			}
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
            for (int i = 0; i < num; i++)
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

				bc.MyTeam.Add(sword, true);
            }
			Debug.Log("Added Illusion Sword to hand");
		}

        public BattleChar MasterChar;
	}
}

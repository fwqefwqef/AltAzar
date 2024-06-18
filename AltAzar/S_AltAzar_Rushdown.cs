using System;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using I2.Loc;

namespace AltAzar
{
    internal class S_AltAzar_Rushdown : Skill_Extended
	{
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			List<Skill> list = new List<Skill>();
			foreach (Skill skill in this.BChar.MyTeam.Skills_Deck)
			{
				if (skill.Master == this.BChar && skill.TargetDamage >= 1)
				{
					list.Add(skill);
				}
			}
			foreach (Skill skill2 in this.BChar.MyTeam.Skills_UsedDeck)
			{
				if (skill2.Master == this.BChar && skill2.TargetDamage >= 1)
				{
					list.Add(skill2);
				}
			}
			List<Skill> list2 = new List<Skill>();
			for (int i = 0; i < 2; i++)
			{
				if (list.Count != 0)
				{
					Skill item = list.Random(this.BChar.GetRandomClass().Main);
					list.Remove(item);
					list2.Add(item);
				}
			}
			BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list2, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.DrawSkill, false, true, true, false, true));
		}

		public void Del(SkillButton Mybutton)
		{
			Mybutton.Myskill.Master.MyTeam.ForceDraw(Mybutton.Myskill);
			Skill_Extended skill_Extended = Skill_Extended.DataToExtended("AltAzar_Rushdown_Ex");
			Mybutton.Myskill.ExtendedAdd(skill_Extended);
		}
	}
}

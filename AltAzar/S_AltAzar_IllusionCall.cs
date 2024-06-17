using GameDataEditor;
using I2.Loc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltAzar
{
    public class S_AltAzar_IllusionCall : Skill_Extended
	{
		public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
		{
			base.SkillUseSingle(SkillD, Targets);
			List<Skill> list = new List<Skill>();
			list.Add(Skill.TempSkill("S_AltAzar_IllusionCall_0", this.MySkill.Master, this.MySkill.Master.MyTeam));
			list.Add(Skill.TempSkill("S_AltAzar_IllusionCall_1", this.MySkill.Master, this.MySkill.Master.MyTeam));
			BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));

		}

		public void Del(SkillButton Mybutton)
		{
			if (Mybutton.Myskill.MySkill.KeyID == "S_AltAzar_IllusionCall_0")
			{
				AltAzar_Ex_0.SwordAdd(this.BChar, 0);
				AltAzar_Ex_0.SwordAdd(this.BChar, 0);
			}
			if (Mybutton.Myskill.MySkill.KeyID == "S_AltAzar_IllusionCall_1")
			{
				AltAzar_Ex_0.SwordAdd(this.BChar, -1);
				AltAzar_Ex_0.SwordAdd(this.BChar, -1);
			}
		}
	}
}

using GameDataEditor;
using I2.Loc;
using System;
using System.Collections.Generic;

namespace AltAzar
{
	// Token: 0x02000014 RID: 20
	public class S_AltAzar_LucyD : Skill_Extended
	{
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            
            AltAzar_Ex_0 azar_Ex_ = Skill_Extended.DataToExtended(new GDESkillExtendedData("AltAzar_Ex_0")) as AltAzar_Ex_0;
            BattleAlly b = BattleSystem.instance.AllyList.Find((BattleAlly a) => a.Info.KeyData == "AltAzar");
            azar_Ex_.MasterChar = b;
            if (b != null)
            {
                if (Targets[0].ExtendedFind("AltAzar.AltAzar_Ex_0", true) == null)
                {
                    Targets[0].ExtendedAdd(azar_Ex_);
                }
            }

            List<Skill> list = new List<Skill>();
            Skill skill = Skill.TempSkill("S_AltAzar_LucyD_0", BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam);
            Skill skill2 = Skill.TempSkill("S_AltAzar_LucyD_1", BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam);
            list.Add(skill);
            list.Add(skill2);
            BattleSystem.instance.EffectDelays.Enqueue(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del2), ScriptLocalization.System_SkillSelect.EffectSelect, false, false, true, false, false));
        } 

        public void Del2(SkillButton Mybutton)
        {
            if (Mybutton.Myskill.MySkill.KeyID == "S_AltAzar_LucyD_0")
            {
                BattleSystem.instance.AllyTeam.Draw(2);
                return;
            }
            
            if (Mybutton.Myskill.MySkill.KeyID == "S_AltAzar_LucyD_1")
            {
                BattleSystem.instance.AllyTeam.DiscardCount += 2;
                return;
            }
        }

    }
}

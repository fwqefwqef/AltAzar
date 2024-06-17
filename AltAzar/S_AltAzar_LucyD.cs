using GameDataEditor;
using I2.Loc;
using System;
using System.Collections.Generic;
using UnityEngine;

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
                if (Targets[0].ExtendedFind_DataName("AltAzar_Ex_0") == null)
                {
                    Targets[0].ExtendedAdd(azar_Ex_);
                }
            }

            BattleSystem.instance.AllyTeam.Draw(2);
        }

    }
}

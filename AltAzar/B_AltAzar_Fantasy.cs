using System;
using System.Collections.Generic;
using GameDataEditor;

namespace AltAzar
{
    internal class B_AltAzar_Fantasy : Buff, IP_SkillUse_User_After
	{
		//public override void FixedUpdate()
		//{
		//	base.FixedUpdate();
		//	foreach (Skill skill in this.BChar.MyTeam.Skills)
		//	{
		//		if (skill.ExtendedFind_DataName("AltAzar_Fantasy_Ex") == null)
		//		{
		//			if (skill.AP == 1)
  //                  {
		//				skill.ExtendedAdd(Skill_Extended.DataToExtended("AltAzar_Fantasy_Ex"));
		//			}
		//		}
		//		else
  //              {
		//			if (skill.AP != 1)
  //                  {
		//				skill.ExtendedDelete_Dataname("AltAzar_Fantasy_Ex");
  //                  }
  //              }
		//	}
		//}
  //      public void TurnEnd()
  //      {
		//	this.SelfDestroy();
  //      }

        public void SkillUseAfter(Skill SkillD)
        {
            if (SkillD.AP == 1 && SkillD.NotCount == true)
            {
				BattleSystem.instance.AllyTeam.AP += 1;
            }
			else if (SkillD.AP == 2 && SkillD.NotCount == false)
			{
				BattleSystem.instance.AllyTeam.AP += 1;
			}
		}
    }
}

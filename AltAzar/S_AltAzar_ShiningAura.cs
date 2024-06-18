using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltAzar
{
    public class S_AltAzar_ShiningAura : Skill_Extended
	{
		public override void FixedUpdate()
		{
			base.FixedUpdate();

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

			for (int i = 0; i < hand.Count; i++)
			{
				if (hand[i].MySkill.KeyID == GDEItemKeys.Skill_S_Azar_P_0)
				{
					if (i == num+1 || i == num-1)
                    {
						hand[i].APChange = -1;
                    }
					else
                    {
						hand[i].APChange = 0;
					}
				}
			}

		}
	}
}

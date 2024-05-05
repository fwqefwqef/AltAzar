using System;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;

namespace AltAzar
{
	public class P_AltAzar : Passive_Char, IP_PlayerTurn
	{
		public override void Init()
		{
			base.Init();
			this.OnePassive = true;
			Debug.Log("P AltAzar init");
		}
		public void Turn()
		{
			Debug.Log("New turn");
			AltAzar_Ex_0 azar_Ex_ = Skill_Extended.DataToExtended(new GDESkillExtendedData("AltAzar_Ex_0")) as AltAzar_Ex_0;
			azar_Ex_.MasterChar = this.BChar;

			List<Skill> skills = new List<Skill>();
			List<Skill> hand = BattleSystem.instance.AllyTeam.Skills;
			for (int i = 0; i < hand.Count; i++)
			{
				if (hand[i].ExtendedFind_DataName("AltAzar_Ex_0") == null)
				{
					skills.Add(hand[i]);
				}
			}
			skills.Random().ExtendedAdd(azar_Ex_);
		}

		//public void Turn()
		//{
		//	Debug.Log("New turn");
		//	AltAzar_Ex_0 azar_Ex_ = Skill_Extended.DataToExtended(new GDESkillExtendedData("AltAzar_Ex_0")) as AltAzar_Ex_0;
		//	azar_Ex_.MasterChar = this.BChar;
		//	for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills.Count; i++)
		//	{
		//		if (BattleSystem.instance.AllyTeam.Skills[i].ExtendedFind("AltAzar_Ex_0", true) == null)
		//		{
		//			BattleSystem.instance.AllyTeam.Skills[i].ExtendedAdd(azar_Ex_);
		//			return;
		//		}
		//	}
		//}
	}
}

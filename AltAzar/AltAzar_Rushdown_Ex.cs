using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;
using UnityEngine;

namespace AltAzar
{
	internal class AltAzar_Rushdown_Ex : Skill_Extended
	{
        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            Skill skill = Skill.TempSkill("S_AltAzar_Rushdown", this.BChar, this.BChar.MyTeam);
            this.BChar.MyTeam.Add(skill,true);
            this.BChar.Overload = 0;
        }
    }
}

﻿using GameDataEditor;
using System;
using UnityEngine;

namespace AltAzar
{
    // Token: 0x0200000E RID: 14
    public class B_AltAzar_5_T : Buff, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {

            if (DMG != 0 && Misc.PerToNum((float)DMG, 10f) >= 1f)
            {
                this.BChar.Heal(this.BChar, Misc.PerToNum((float)DMG, 10f), false, false, null);
            }
            base.StackDestroy();
        }

        public override void Init()
        {
            this.PlusStat.Penetration = 50f; // temporary value
            this.isStackDestroy = true;
            base.Init();
        }

    }

}

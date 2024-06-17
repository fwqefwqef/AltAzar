using GameDataEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltAzar
{
    public class S_AltAzar_FirstScroll : Skill_Extended, IP_SkillUseHand_Team
    {
        // Token: 0x06000DF6 RID: 3574 RVA: 0x0007E41C File Offset: 0x0007C61C
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        // Token: 0x06000DF7 RID: 3575 RVA: 0x000864BC File Offset: 0x000846BC
        public void SKillUseHand_Team(Skill skill)
        {
            if (skill != this.MySkill)
            {
                this.flag = false;
                this.MySkill.NotCount = false;

                Skill_Extended crit = new Skill_Extended();
                crit.PlusSkillStat.cri = -100;
                this.MySkill.ExtendedAdd(crit);
            }
        }

        // Token: 0x06000DF8 RID: 3576 RVA: 0x000864CE File Offset: 0x000846CE
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            AltAzar_Ex_0.SwordAdd(this.BChar, -1);

        }

        // Token: 0x06000DF9 RID: 3577 RVA: 0x00086501 File Offset: 0x00084701
        public override void HandInit()
        {
            base.HandInit();
            this.flag = true;
        }

        // Token: 0x06000DFA RID: 3578 RVA: 0x00086510 File Offset: 0x00084710
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.flag)
            {
                base.SkillParticleOn();
                return;
            }
            base.SkillParticleOff();

        }

        // Token: 0x04000D8C RID: 3468
        private bool flag;
    }
}

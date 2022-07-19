using System.Collections.Generic;
using System;

namespace MRD
{
    public class SanKantSuStatOption : TowerStatOption
    {
        public override string Name => nameof(SanKantSuStatOption);

        public override float AdditionalAttackPercent => HolderStat.TowerInfo is CompleteTowerInfo ? 0.25f : 0.5f;
    }
    public class SanKantSuOption : TowerProcessAttackInfoOption
    {
        public override string Name => nameof(SanKantSuOption);

        public override void ProcessAttackInfo(List<AttackInfo> infos)
        {
            // 공격시 +-20도 이내에 50% 느린 추가 탄환 3개
            if (infos[0] is not BulletInfo info) return;
            Random rand = new Random();
            for(int i=0; i<3; i++)
            {
                float angle = (float)(rand.NextDouble()*40d-20d); // -20f ~ 20f
                infos.Add(new BulletInfo(MathHelper.RotateVector(info.Direction, angle), info.SpeedMultiplier/2f,
                info.ShooterTowerStat, info.StartPosition, info.ImageName, info.ShootDelay));
            }
        }
    }
    public class SanKantSuImageOption : TowerImageOption
    {
        public override string Name => nameof(SanKantSuImageOption);

        protected override List<(int index, int order)> tripleTowerImages => new() { (21, 2) };
    }
}
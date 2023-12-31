using System;
using System.Collections.Generic;
using System.Linq;

namespace MRD
{
    public class SamSaekDongSoonStatOption : TowerStatOption
    {
        private float additionalAttack;

        private float additionalAttackSpeedMultiplier;
        public override string Name => nameof(SamSaekDongSoonStatOption);

        public override Stat AdditionalStat => new
    (
            attackSpeed: addition.asp,
            damageConstant: addition.dc
    );
        private (float dc, float asp) addition => (HolderStat.TowerInfo is CompleteTowerInfo, ((YakuHolderInfo)HolderStat.TowerInfo).isMenzen) switch
        {
            (false, false) => (0f, 1.2f),
            (false, true) => (15f, 1.2f),
            (true, false) => (0f, 1.3f),
            (true, true) => (50f, 1.3f),
        };
    }

    public class SamSaekDongSoonOption : TowerProcessAttackInfoOption
    {
        public override string Name => nameof(SamSaekDongSoonOption);

        public override void ProcessAttackInfo(List<AttackInfo> infos)
        {
            // 무작위 수패 2단계 효과.
            if (HolderStat.TowerInfo is not CompleteTowerInfo)
            {
                foreach (var info in infos)
                {
                    if (info is not BulletInfo bulletInfo) continue;

                    var randomList = new List<HaiType> { HaiType.Sou, HaiType.Wan, HaiType.Pin };
                    var rand = new Random();
                    int i = rand.Next(randomList.Count);

                    bulletInfo.UpdateShupaiLevel(randomList[i], 1);
                }

                return;
            }

            foreach (var info in infos)
            {
                var randomList = new List<HaiType> { HaiType.Sou, HaiType.Wan, HaiType.Pin };
                var rand = new Random();
                int i = rand.Next(randomList.Count);

                info.UpdateShupaiLevel(randomList[i], 2);
            }
        }
    }

    public class SamSaekDongSoonImageOption : TowerImageOption
    {
        public override string Name => nameof(SamSaekDongSoonImageOption);

        protected override List<(int index, int order)> tripleTowerImages
        {
            get
            {
                var ret = new List<(int index, int order)> () { (1, 3)};
                var yaku = ((YakuHolderInfo)HolderStat.TowerInfo).YakuList;
                if (yaku.Any(x => x.Name.Equals("PingHu"))) ret.Add((27, 4));
                if (yaku.Any(x => x.Name.Equals("YiPeKo"))) ret.Add((28, 5));
                return ret;
            }
        }
    }
}

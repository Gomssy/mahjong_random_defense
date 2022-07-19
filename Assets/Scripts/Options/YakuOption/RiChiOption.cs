using System.Collections.Generic;

namespace MRD
{
    public class RiChiStatOption : TowerStatOption
    {
        public override string Name => nameof(RiChiStatOption);

        public override float AdditionalAttack => 20.0f;
        public override float AdditionalAttackSpeedMultiplier => 1.2f;
        public override float AdditionalCritChance => 0.2f;
        public override float AdditionalCritMultiplier => 0.3f;

    }

}
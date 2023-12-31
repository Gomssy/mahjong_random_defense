using System.Collections.Generic;

namespace MRD
{
    public class SingleHaiInfo : TowerInfo
    {
        public SingleHaiInfo(Hai hai)
        {
            hais.Add(hai);
        }

        public override IReadOnlyList<string> DefaultOptions { get; } = new[] { nameof(SingleTowerStatOption) };
        public Hai Hai => hais[0];
    }
}

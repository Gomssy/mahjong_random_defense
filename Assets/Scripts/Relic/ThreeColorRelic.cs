using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MRD
{
    public class ThreeColorRelic : Relic
    {
        public override string Name => "ThreeColor";
        public override int MaxAmount => 3;
        public override RelicRank Rank => RelicRank.B;
    }
}
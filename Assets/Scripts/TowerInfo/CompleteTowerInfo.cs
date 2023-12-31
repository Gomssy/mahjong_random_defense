using System.Collections.Generic;
namespace MRD
{
    public class CompleteTowerInfo : YakuHolderInfo
    {
        public int RichiCount { get; }
        public CompleteTowerInfo(TripleTowerInfo m1, MentsuInfo m2, MentsuInfo m3)
        {
            mentsus.AddRange(m1.MentsuInfos);
            mentsus.Add(m2);
            mentsus.Add(m3);

            hais.AddRange(m1.Hais);
            hais.AddRange(m2.Hais);
            hais.AddRange(m3.Hais);
            
            RichiCount = (m1.RichiInfo is not null && m1.RichiInfo.State == RichiState.OnRichi) ? (m1.RichiInfo.TsumoCount>8 ? 1 : 0) + 1 : 0;
        }
    }
}

using System.Linq;

namespace MRD
{
    public class SanAnKeoChecker : IYakuConditionChecker
    {
        public string TargetYakuName => "SanAnKeo";
        public string[] OptionNames => new string[] { nameof(SanAnKeoImageOption), nameof(SanAnKouStatOption) };

        public bool CheckCondition(YakuHolderInfo holder)
        {   //조건: 안커 3개
            return holder.MentsuInfos.Count(x => x.IsMenzen && x is KoutsuInfo) == 3;
        }
    }

}

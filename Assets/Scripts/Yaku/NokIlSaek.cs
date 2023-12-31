using System.Linq;

namespace MRD
{
    public class NokIlSaekChecker : IYakuConditionChecker
    {
        public string TargetYakuName => "NokIlSaek";
        public string[] OptionNames => new[] { nameof(NokIlSaekStatOption), nameof(NokIlSaekOption), nameof(NokIlSaekImageOption) };

        public bool CheckCondition(YakuHolderInfo holder)
        {
            return holder is CompleteTowerInfo && holder.MentsuInfos.SelectMany(x => x.Hais).All(x =>
                x.Spec.HaiType == HaiType.Sou && x.Spec.Number is 2 or 3 or 4 or 6 or 8
                || x.Spec.HaiType == HaiType.Sangen && x.Spec.Number == 1
            );
        }
    }
}

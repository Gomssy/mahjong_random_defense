using System.Linq;

namespace MRD
{
    public class JunJJangChecker : IYakuConditionChecker
    {
        public string TargetYakuName => "JunJJang";
        public string[] OptionNames => new[] { nameof(JunJJangImageOption), nameof(JunJJangStatOption) };

        public bool CheckCondition(YakuHolderInfo holder)
        {
            foreach (var i in holder.MentsuInfos.Select(x => x.Hais)) //foreach head & body
                if (i.All(x => !x.Spec.IsRoutou))
                    return false; //no 1, 9
            return true;
        }
    }
}

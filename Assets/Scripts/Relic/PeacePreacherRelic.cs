
namespace MRD
{
    public class PeacePreacherRelic : Relic
    {
        public override string Name => "PeacePreacher";
        public override int MaxAmount => 5;
        public override RelicRank Rank => RelicRank.B;
        public override Stat AdditionalStat(TowerStat towerStat) 
        {
            var grid = RoundManager.Inst.Grid;
            XY coord = towerStat.AttachedTower.Coordinate;
            while((coord += (-1, 0)).X > 0)
                if(grid.GetCell(coord).TowerStat.Options.ContainsKey(nameof(PingHuStatOption)))
                    return new(attackSpeed: 1.1f);
            return new();
        }
        

    }
}
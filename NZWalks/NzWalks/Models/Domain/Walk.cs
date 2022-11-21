namespace NzWalks.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        public Guid RegionID { get; set; }

        public double WalkDifficultyID { get; set; }

        //Navigation property

        public IEnumerable<Region> Region { get; set; }

        public IEnumerable<WalkDifficulty> WalkDifficulty { get; set; }


    }
}

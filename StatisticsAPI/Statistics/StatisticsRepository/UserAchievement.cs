using System;
using System.Collections.Generic;

#nullable disable

namespace StatisticsRepository
{
    public partial class UserAchievement
    {
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public string Completion { get; set; }

        public virtual Achievement Achievement { get; set; }
        public virtual User User { get; set; }
    }
}

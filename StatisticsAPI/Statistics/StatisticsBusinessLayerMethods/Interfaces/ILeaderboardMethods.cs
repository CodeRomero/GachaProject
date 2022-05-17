using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticsRepository;

namespace StatisticsBusinessLayerMethods
{
    public interface ILeaderboardMethods
    {
        List<UserCoinBalance> TopCurrentBallance(int maxnumber);
        List<UserCoinEarned> TopEarnedCoins(int maxnumber);
        List<UserCoinSpent> TopSpentCoins(int maxnumber);

        List<TopPercentCompletedCollectionModel> TopPercentageCompletedCollection(int maxnumber);



    }
}

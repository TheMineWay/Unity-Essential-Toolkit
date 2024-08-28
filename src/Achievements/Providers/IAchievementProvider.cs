using System.Collections.Generic;
using UnityEngine;

namespace EssentialToolkit.Achievements
{
    public interface IAchievementProvider
    {
        // Returns all achievements provided in the provider
        Dictionary<Achievements, Achievement> GetAchievements();

        // Initialization state
        bool IsReady();
    }
}
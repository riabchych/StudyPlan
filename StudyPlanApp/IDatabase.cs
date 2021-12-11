using System.Collections.Generic;

namespace StudyPlan
{
    public interface IDatabase
    {
        List<string> GetTables();
    }
}
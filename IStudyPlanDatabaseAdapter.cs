using System.Collections.Generic;

namespace StudyPlan
{
    public interface IStudyPlanDatabaseAdapter
    {
        List<Item> GetCources();
        List<Discipline> GetDisciplines(int planId, int semester);
        List<EntryBase> GetEntryBases(int groupId, int entryYear);
        List<Group> GetGroups(int entryYear);
        Plan GetPlan(int id);
        List<int> GetSemesters(int entryYear, int groupId, int entryBaseId);
        void UpdateStudyPlan(int id, string link);
    }
}
using System.Collections.Generic;

namespace StudyPlan
{
    public interface IStudyPlanDatabaseAdapter
    {
        List<Item> GetCources();
        List<Discipline> GetDisciplines(int planId, int semester);
        List<EntryBase> GetEntryBases(int groupId);
        List<Group> GetGroups(int cource);
        Plan GetPlan(int id);
        List<int> GetSemesters(int groupId, int entryBaseId);
        string GetWorkProgramLink(int planId, int disciplineId, int semester, ref int workProgramId);
        void UpdateStudyPlan(int id, string link);
        void UpdateWorkProgram(int id, string link);
    }
}
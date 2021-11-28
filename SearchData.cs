﻿namespace StudyPlan
{
    /*
     * Структура яка служить для збереження даних під час вибору
     * значень у випадаючих списках (ComboBox)
     */
    public class SearchData
    {
        private int _group;
        private int _entryBase;
        private int _semester;
        private int _course;
        private int _discipline;

        public SearchData()
        {
            _group = 0;
            _entryBase = 0;
            _semester = 0;
            _course = 0;
            _discipline = 0;
        }

        public int Group { get => _group; set => _group = value; }
        public int EntryBase { get => _entryBase; set => _entryBase = value; }
        public int Semester { get => _semester; set => _semester = value; }
        public int Course { get => _course; set => _course = value; }
        public int Discipline { get => _discipline; set => _discipline = value; }
    }
}
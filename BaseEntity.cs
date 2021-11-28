﻿namespace StudyPlan
{
    public abstract class BaseEntity
    {
        private int _id;
        private string _name;
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
    }
}

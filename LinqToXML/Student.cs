﻿using System;
using System.Linq;

namespace LinqToXML
{
    public class Student : Person
    {
        public uint IDGroup { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Mark { get; set; }
        public uint ProfessorID { get; set; }
        public override string ToString()
        {
            return $"ID студента: {ID}\tПрізвище: {Surname}\tІм'я: {Name}\tПо батькові: {Patronymic}\tСередній бал: {Mark}\tДата народження: {Birthday}\tГрупа: {IDGroup}\t";
        }
    }
}

using Model.Core.Models.Entities;
using System;

namespace Model.Core.Factories
{
    public class JobFactory
    {
        public Jobs CreateJob(string jobName, string jobCode, string jobDescription, Location jobLocation, Department jobDepartment, DateTime postedDate, DateTime closingDate, bool isActive = true)
        {
            return new Jobs(jobName, jobCode, jobDescription, jobLocation, jobDepartment, postedDate, closingDate, isActive);
        }

    }
}
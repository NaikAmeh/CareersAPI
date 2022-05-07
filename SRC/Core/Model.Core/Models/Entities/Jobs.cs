using System;

namespace Model.Core.Models.Entities
{
    #region Properties
    public class Jobs
    {
        public virtual int JobID { get; protected set; }
        public virtual string JobName { get; protected set; }
        public virtual string JobCode { get; protected set; }
        public virtual string JobDescription { get; protected set; }
        public virtual Location JobLocation { get; protected set; }
        public virtual Department JobDepartment { get; protected set; }
        public virtual DateTime PostedDate { get; protected set; }
        public virtual DateTime ClosingDate { get; protected set; }
        public virtual bool IsActive { get; protected set; }

        #endregion

        #region Constructors
        protected Jobs()
        {
        }

        internal Jobs(string jobName, string jobCode, string jobDescription, Location jobLocation, Department jobDepartment, DateTime postedDate, DateTime closingDate, bool isActive = true)
        {
            JobName = jobName;
            JobCode = jobCode;
            JobDescription = jobDescription;
            JobDepartment = jobDepartment;
            PostedDate = postedDate;
            ClosingDate = closingDate;
            JobLocation = jobLocation;
            IsActive = isActive;
        }

        #endregion

        #region Public Methods
        public virtual void Update(string jobName, string jobDescription, Location jobLocation, Department jobDepartment, DateTime closingDate)
        {
            JobName = jobName;
            JobDescription = jobDescription;
            JobDepartment = jobDepartment;
            ClosingDate = closingDate;
            JobLocation = jobLocation;
        }
        #endregion

    }
}
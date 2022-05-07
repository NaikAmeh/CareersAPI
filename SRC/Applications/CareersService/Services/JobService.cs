using CareersService.Models.RequestModels;
using CareersService.Models.ResponseModels;
using Model.Core.Factories;
using Model.Core.Models.Entities;
using Models.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;

namespace CareerService.Services
{
    public class JobService
    {
        public HttpResponseMessage SaveJobDetails(JobRequest model)
        {
            Department department = NHibernateHelper.GetRepository<Department>().FindBy(model.DepartmentId);
            Location location = NHibernateHelper.GetRepository<Location>().FindBy(model.LocationId);
            int totalJobs = NHibernateHelper.GetRepository<Jobs>().All().Count();
            using (var transaction = NHibernateHelper.GetCurrentSession().BeginTransaction())
            {
                Jobs job = NHibernateHelper.GetFactory<JobFactory>().CreateJob(model.Title, $"Job-{totalJobs + 1:D2}", model.Description, location, department, DateTime.Now, Convert.ToDateTime(model.ClosingDate));
                NHibernateHelper.GetRepository<Jobs>().Save(job);
                transaction.Commit();
            }
            return new HttpResponseMessage(HttpStatusCode.OK);

        }

        public ListJobsResponse ListJobs(ListJobsRequest model)
        {
            List<Jobs> lstJobs = new List<Jobs>();
            if (model.PageNo > 0 && model.PageSize > 0)
            {
                Expression<Func<Jobs, bool>> expr = x => x.IsActive;
                if (!string.IsNullOrWhiteSpace(model.JobName))
                    expr = expr.AndAlso(x => x.JobName.Contains(model.JobName));

                if (model.LocationId > 0)
                    expr = expr.AndAlso(x => x.JobLocation.LocationID == model.LocationId);

                if (model.DepartmentId > 0)
                    expr = expr.AndAlso(x => x.JobDepartment.DepartmentID == model.DepartmentId);

                lstJobs = NHibernateHelper.GetRepository<Jobs>().FilterBy(expr).Skip((Convert.ToInt32(model.PageNo) - 1) * Convert.ToInt32(model.PageSize)).Take(Convert.ToInt32(model.PageSize)).ToList();

            }
            else
            {
                lstJobs = NHibernateHelper.GetRepository<Jobs>().All().ToList();
            }

            ListJobsResponse response = new ListJobsResponse();
            response.Total = lstJobs.Count;
            response.JobDetails = lstJobs.Select(x => new JobResponse()
            {
                JobId = x.JobID,
                JobCode = x.JobCode,
                JobName = x.JobName,
                JobLocation = x.JobLocation.LocationName,
                JobDepartment = x.JobDepartment.DepartmentName,
                PostedDate = x.PostedDate.ToString(),
                ClosingDate = x.ClosingDate.ToString()
            }).ToList();

            return response;
        }

        public bool UpdateJobDetails(int id, JobRequest model)
        {
            Department department = NHibernateHelper.GetRepository<Department>().FindBy(model.DepartmentId);
            Location location = NHibernateHelper.GetRepository<Location>().FindBy(model.LocationId);
            Jobs job = NHibernateHelper.GetRepository<Jobs>().FindBy(id);
            if (job != null)
            {
                using (var transaction = NHibernateHelper.GetCurrentSession().BeginTransaction())
                {
                    job.Update(model.Title, model.Description, location, department, Convert.ToDateTime(model.ClosingDate));
                    transaction.Commit();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public JobDetailsRespnse GetJobDetails(int id)
        {
            JobDetailsRespnse response = null;
            Jobs job = NHibernateHelper.GetRepository<Jobs>().FindBy(id);

            if (job != null)
            {
                LocationResponse location = new LocationResponse()
                {
                    LocationId = job.JobLocation.LocationID,
                    LocationName = job.JobLocation.LocationName,
                    City = job.JobLocation.LocationCity,
                    State = job.JobLocation.LocationState,
                    Country = job.JobLocation.LocationCountry,
                    zip = job.JobLocation.LocationZip
                };

                DepartmentResponse department = new DepartmentResponse()
                {
                    DepartmentId = job.JobDepartment.DepartmentID,
                    DepartmentName = job.JobDepartment.DepartmentName
                };

                response = new JobDetailsRespnse()
                {
                    JobId = job.JobID,
                    JobName = job.JobName,
                    Description = job.JobDescription,
                    JobCode = job.JobCode,
                    Location = location,
                    Department = department,
                    PostedDate = job.PostedDate.ToString(),
                    ClosingDate = job.ClosingDate.ToString()

                };
            }
            return response;
        }

    }
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, expr2.Body), expr1.Parameters[0]);
        }
    }
}
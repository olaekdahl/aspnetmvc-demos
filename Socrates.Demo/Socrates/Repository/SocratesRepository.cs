using Socrates.DataAccess;
using Socrates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Socrates.Repository
{
    public interface ICourseRepository : IDisposable
    {
        IQueryable<Course> All { get; }
        Course Find(int? id);
        void InsertOrUpdate(Course course);
        void Delete(int id);
        void Save();
    }


    public class CourseRepository : ICourseRepository
    {

        SocratesContext context;

        public CourseRepository(SocratesContext context)
        {
            context.Database.Connection.ConnectionString = WebConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            this.context = context;
        }

        public IQueryable<Course> All
        {
            get { return context.Courses; }
        }

        public Course Find(int? id)
        {
            Course objCourse = new Course();
            objCourse = context.Courses.Where(p => p.Id == id).FirstOrDefault();
            return objCourse;
        }

        public void InsertOrUpdate(Course course)
        {
            if (course.Id == default(int))
            {
                // New entity
                context.Courses.Add(course);
            }
            else
            {
                // Existing entity
                context.Entry(course).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var employee = context.Courses.Find(id);
            context.Courses.Remove(employee);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
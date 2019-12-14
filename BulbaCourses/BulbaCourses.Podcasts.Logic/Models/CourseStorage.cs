using BulbaCourses.Podcasts.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Podcasts.Logic.Services
{
    internal static class CourseStorage
    {
        private static List<Course> Courses = new List<Course>();
        internal static SearchResultList Search(string _string, SearchMode searchtype, ref SearchResultList resultList) //add caching
        {
            switch (searchtype)
            {
                case SearchMode.ByTitle:
                    foreach (Course course in Courses)
                    {
                        if (_string.Length > course.Title.Length)
                            continue;
                        else
                        {
                            if (course.Title.ToLower().Contains(_string.ToLower()))
                            {
                                resultList.Add(GetCourseInfo(course));
                            }
                        }
                        if (resultList.Length() >= SearchService.SearchCount)
                            return resultList;
                    }
                    break;

                case SearchMode.ByAuthor:
                    foreach (Course course in Courses)
                    {
                        if (_string.Length > course.Author.Length)
                            continue;
                        else
                        {
                            if (course.Author.ToLower().Contains(_string.ToLower()))
                            {
                                resultList.Add((GetCourseInfo(course));
                            }
                        }
                        if (resultList.Length() >= SearchService.SearchCount)
                            return resultList;
                    }
                    break;

                case SearchMode.ByTheme:
                    foreach (Course course in Courses)
                    {
                        if (_string.Length > course.Theme.Length)
                            continue;
                        else
                        {
                            if (course.Theme.ToLower().Contains(_string.ToLower()))
                            {
                                resultList.Add((GetCourseInfo(course));
                            }
                        }
                        if (resultList.Length() >= SearchService.SearchCount)
                            return resultList;
                    }
                    break;
            }
            if (resultList.Length() == 0)
                throw new KeyNotFoundException();
            return resultList;
        }
        internal static CourseInfo GetCourseInfo(Course course)
        {
            return new CourseInfo
            {
                Title = course.Title,
                Price = course.Price,
                Author = course.Author,
                Theme = course.Theme,
                Id = course.Id
            };
        }
        internal static Course GetCourse(string id)
        {
            int _id = 0;
            foreach (Course _course in Courses)
            {
                if (_course.Id == id)
                {
                    break;
                }
                _id++;
            }
            return Courses[_id];
        }
        internal static Course Edit(Course course)
        {
            int id = Courses.IndexOf(course);
            Courses.RemoveAt(id);
            course.Modified = System.DateTime.Now;
            Courses.Insert(id, course);
            return course;
        }
        internal static void Delete(Course course)
        {
            int id = Courses.IndexOf(course);
            
            Courses.RemoveAt(id);
        }
        internal static Course Add(Course course)
        {
            course.Id = Guid.NewGuid().ToString();

            course.Created = System.DateTime.Now;
            Courses.Add(course);
            return course;
        }
    }
}
//to dblayer
using System;
using System.Collections.Generic;
using System.Linq;

namespace _207.CourseSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanFinish(3, new int[][] { new int[2] { 0, 1 }, new int[2] { 0, 2 }, new int[2] { 1, 2 } }));
        }

        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var courses = new List<Course>();
            var courseDict = new Dictionary<int, Course>();
            for (int i = 0; i < numCourses; i++)
            {
                var course = new Course(i);
                courses.Add(course);
                courseDict[i] = course;
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                courseDict[prerequisites[i][0]].AddPrerequisite(courseDict[prerequisites[i][1]]);
            }

            var visitedCourses = new HashSet<int>();
            foreach (var course in courses.Where(x => x.HasPrerequisites()))
            {
                if (course.State != Course.StateEnum.BLANK)
                {
                    continue;
                }

                if (!DFS(course))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool DFS(Course course)
        {
            if (course.State == Course.StateEnum.VISITTING)
            {
                return false;
            }

            if (course.State == Course.StateEnum.BLANK)
            {
                course.State = Course.StateEnum.VISITTING;
                foreach (var c in course.Prerequisites)
                {
                    if (!DFS(c))
                    {
                        return false;
                    }
                }

                course.State = Course.StateEnum.VISITTED;
            }

            return true;
        }
    }

    public class Course
    {
        public Course(int code)
        {
            this.Code = code;
            this.Prerequisites = new List<Course>();
        }

        public int Code { get; set; }
        public IList<Course> Prerequisites { get; set; }
        public StateEnum State { get; set; }
        public void AddPrerequisite(Course c)
        {
            this.Prerequisites.Add(c);
        }

        public bool HasPrerequisites()
        {
            return this.Prerequisites.Count > 0;
        }

        public enum StateEnum {
            BLANK,
            VISITTING,
            VISITTED
        }
    }
}

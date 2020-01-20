using BulbaCourses.Podcasts.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Podcasts.Logic.Models
{
    internal class Account
    {
        internal string Id { get; set; } = Guid.NewGuid().ToString();
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        public bool IsAdmin { get; set; }
        private List<string> BoughtCourses = new List<string>();
        private List<string> UploadedCourses = new List<string>();
        internal void AddBought(string id)
        {
            BoughtCourses.Add(id);
        }
        internal int LengthBought()
        {
            return BoughtCourses.Count();
        }
        internal void AddUploaded(string id)
        {
            BoughtCourses.Add(id);
        }
        internal void DeleteUploaded(string id)
        {
            BoughtCourses.RemoveAt(BoughtCourses.IndexOf(id));
        }
        internal int LengthUploaded()
        {
            return UploadedCourses.Count();
        }
        internal OwnershipType CheckOwnership(string courseId)
        {
            if (IsAdmin == true)
            {
                return OwnershipType.Admin;
            }
            if (BoughtCourses.IndexOf(courseId) != -1)
                return OwnershipType.Bought;
            if (UploadedCourses.IndexOf(courseId) != -1)
                return OwnershipType.Uploaded;
            return OwnershipType.None;
        }
    }
}
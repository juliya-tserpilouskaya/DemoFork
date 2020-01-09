using System;
using System.Collections.Generic;
using System.Linq;

namespace BulbaCourses.Youtube.DataAccess.Models
{
    public class MentorDb : UserDb
    {
        public ICollection<ChannelDb> Channels { get; set; } //reference        
    }
}
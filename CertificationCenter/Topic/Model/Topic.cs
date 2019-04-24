using System;
using System.Collections.Generic;
using System.Text;

namespace Topic.Model
{
    public class Topic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountOfQuestions { get; set; }

        public int CourseId { get; set; }
    }
}

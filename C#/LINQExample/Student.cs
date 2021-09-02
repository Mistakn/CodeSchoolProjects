using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample {
    class Student {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int ID { get; private set; }
        public List<int> Scores { get; private set; }


        public Student(string firstName, string lastName, int id, List<int> scores) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = id;
            this.Scores = scores;
        }
    }
}

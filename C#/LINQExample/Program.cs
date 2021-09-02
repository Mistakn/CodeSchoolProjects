using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQExample {
    class Program {
        static void Main(string[] args) {

            Student[] students = {
                new Student("Cuit", "Rodriguez", 0, new List<int>{94, 46, 86, 90}),
                new Student("Mario", "Mario", 1, new List<int>{64, 45, 26, 80}),
                new Student("Luigi", "Mario", 2, new List<int>{64, 76, 76, 70}),
            };


            IEnumerable<Student> studentQuery =
                from student in students
                where student.Scores.Average() > 60
                orderby student.LastName
                select student;


            var studentQuery2 =
                from student in students
                group student by student.LastName[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;

            foreach (var student in studentQuery) {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }

            foreach (var studentGroup in studentQuery2) {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup) {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");
                }
            }

            //int[] scores = { 24, 69, 256, 58, 25, 25 };

            //IEnumerable<int> scoreQuery =
            //    from score in scores
            //    where score > 40
            //    select score;

            //foreach (var score in scoreQuery) {
            //    Console.WriteLine($"{score}");
            //}
        }
    }
}

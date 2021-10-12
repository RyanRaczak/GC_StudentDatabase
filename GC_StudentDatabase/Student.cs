using System;
using System.Collections.Generic;
using System.Text;

namespace GC_StudentDatabase
{
    class Student
    {
        private int studentNum;
        private string firstName;
        private string lastName;
        private string homeTown;
        private string favFood;
        private string favHobby;

        public Student(int snum, string fName, string lName, string home, string food, string hobby)
        {
            this.studentNum = snum;
            this.firstName = fName.ToLower();
            this.lastName = lName.ToLower();
            this.homeTown = home.ToLower();
            this.favFood = food.ToLower();
            this.favHobby = hobby.ToLower();
        }

        public int StudentNum
        {
            get => studentNum;
            set => studentNum = value;
        }

        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public string HomeTown
        {
            get => homeTown;
            set => homeTown = value;
        }

        public string FavFood
        {
            get => favFood;
            set => favFood = value;
        }

        public string FavHobby
        {
            get => favHobby;
            set => favHobby = value;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Number: {studentNum}\nName: {firstName} {lastName}\nHometown: {homeTown}" +
                $"\nFavorite Food: {favFood}\nFavorite Hobby: {favHobby}");
        }
    }
}

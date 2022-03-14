using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Child person
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Minimum age
        /// </summary>
        private const int _minAge = 0;

        /// <summary>
        /// Maximum age
        /// </summary>
        private const int _maxAge = 17;

        /// <summary>
        /// Maximum age
        /// </summary>
        protected override int MaxAge { get; } = _maxAge;

        /// <summary>
        /// Minimum age
        /// </summary>
        protected override int MinAge { get; } = _minAge;

        /// <summary>
        /// Father
        /// </summary>
        public Adult Father { get; set; }

        /// <summary>
        /// Mother
        /// </summary>
        public Adult Mother { get; set; }

        /// <summary>
        /// Name of school or kindergarten
        /// </summary>
        public string School { get; set; }

        /// <summary>
        /// Constructor for child without parrents
        /// </summary>
        /// <param name="school">school</param>
        /// <param name="name">name</param>
        /// <param name="surname">surname</param>
        /// <param name="age">age</param>
        /// <param name="gender">gender</param>
        public Child(string school, string name, string surname, int age, Gender gender)
            : base(name, surname, age, gender)
        {
            School = school;
        }

        /// <summary>
        /// Constructor for child with mother
        /// </summary>
        /// <param name="mother">mother</param>
        /// <param name="school">school</param>
        /// <param name="name">name</param>
        /// <param name="surname">surname</param>
        /// <param name="age">age</param>
        /// <param name="gender">gender</param>
        public Child(Adult mother, string school, string name, string surname,
            int age, Gender gender) : this(school, name, surname, age, gender)
        {
            Mother = mother;
        }

        /// <summary>
        /// Constructor for child with both parrents
        /// </summary>
        /// <param name="father">father</param>
        /// <param name="mother">mother</param>
        /// <param name="school">school</param>
        /// <param name="name">name</param>
        /// <param name="surname">surname</param>
        /// <param name="age">age</param>
        /// <param name="gender">gender</param>
        public Child(Adult father,Adult mother, string school, string name,
            string surname, int age, Gender gender)
            : this(mother,school, name, surname, age, gender)
        {
            Father = father;
        }

        /// <summary>
        /// Info about child
        /// </summary>
        /// <returns>Info</returns>
        public override string Info()
        {
            string personInfo = base.InfoPerson();
            if (Father != null)
            {
                personInfo+=$", Father: {Father.Name} {Father.Surname}";
            }
            if (Mother != null)
            {
                personInfo += $", Mother: {Mother.Name} {Mother.Surname}";
            }
            if (Father==null && Mother==null)
            {
                personInfo += $", Orphan";
            }
            if (School!=null)
            {
                personInfo += $", School: {School}";
            }
            return personInfo;
        }
        
        /// <summary>
        /// Get random child
        /// </summary>
        /// <returns>Random child</returns>
        public static Child GetRandomChild()
        {
            string[] maleNames = new string[]
            {
                "John", "Carl", "Rick", "Mattew",
                "Nicholas", "Robert", "Samuel",
                "Stan", "Kenny", "Severus", "Jake"
            };
            string[] femaleNames = new string[]
            {
                "Lyla", "Samanta", "Kate", "Kira",
                "Amelia", "Julia", "Anastasia",
                "Sindy", "Luna", "Violet", "Anna"
            };
            string[] allSurnames = new string[]
            {
                "Green", "Gray", "Black", "Orange",
                "Aaf", "Bahk", "Riddle",
                "Krum", "White", "Pria", "Red"
            };
            string[] schools = new string[]
            {
                "School №1","School №2","School №3",
                "School №4","School №5","School №6",
                "School №7","School №8"
            };
            Random random = new Random();
            string name = "";
            Gender gender = (Gender)random.Next(0, 2);
            switch (gender)
            {
                case Gender.Male:
                    name = maleNames[random.Next(maleNames.Length)];
                    break;
                case Gender.Female:
                    name = femaleNames[random.Next(femaleNames.Length)];
                    break;
            }
            string surname = allSurnames[random.Next(allSurnames.Length)];
            int age = random.Next(_minAge, _maxAge);
            string school = schools[random.Next(schools.Length)];
            return new Child(school,name, surname, age, gender);
        }

        /// <summary>
        /// Action for child
        /// </summary>
        /// <returns>String</returns>
        public override string SpecialAction()
        {
            return "Doing special action for child...";
        }
    }
}

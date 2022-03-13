using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    public class Adult : PersonBase
    {
        /// <summary>
        /// Minimum age
        /// </summary>
        private const int _minAge = 18;

        /// <summary>
        /// Maximum age
        /// </summary>
        private const int _maxAge = 120;

        /// <summary>
        /// Maximum age
        /// </summary>
        protected override int MaxAge { get; } = _maxAge;

        /// <summary>
        /// Minimum age
        /// </summary>
        protected override int MinAge { get; } = _minAge;
        /// <summary>
        /// Passport data
        /// </summary>
        private string _passport;

        /// <summary>
        /// Spouse
        /// </summary>
        private Adult _spouse;

        /// <summary>
        /// Information about job
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// Marital status
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// Passport data
        /// </summary>
        public string Passport
        {
            get
            {
                return _passport;
            }
            set
            {
                _passport = value;
            }
        }

        public Adult Spouse
        {
            get
            {
                return _spouse;
            }
            set
            {
                _spouse = value;
            }
        }

        /// <summary>
        /// Constructor for adult without spouse
        /// </summary>
        /// <param name="passport">Passport data</param>
        /// <param name="job">Place of work</param>
        /// <param name="maritalStatus">Marital status</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="age">Age</param>
        /// <param name="gender">Gender of adult</param>
        public Adult(string passport, string job, MaritalStatus maritalStatus,
            string name, string surname, int age, Gender gender)
            : base(name, surname, age, gender)
        {
            Passport = passport;
            Job = job;
            MaritalStatus = maritalStatus;
        }

        /// <summary>
        /// Constructor for adult with spouse
        /// </summary>
        /// <param name="spouse">Spouse of adult</param>
        /// <param name="passport">Passport data</param>
        /// <param name="job">Place of work</param>
        /// <param name="maritalStatus">Marital status</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="age">Age</param>
        /// <param name="gender">Gender of adult</param>
        public Adult(Adult spouse, string passport, string job,
            MaritalStatus maritalStatus, string name, string surname, int age, Gender gender)
            : this(passport, job, maritalStatus, name, surname, age, gender)
        {
            Spouse = spouse;
        }

        /// <summary>
        /// Info about adult
        /// </summary>
        /// <returns>Info</returns>
        public override string Info()
        {
            string personInfo = $"{base.InfoPerson()}, Passport: {Passport}, " +
                $"Marital status: {MaritalStatus}";
            if (MaritalStatus == MaritalStatus.Married)
            {
                personInfo += $", Spouse: {Spouse.Name} {Spouse.Surname}";
            }
            if (Job == null || Job==String.Empty)
            {
                personInfo += ", Unemployed";
            }
            else
            {
                personInfo += $", Place of work: {Job}";
            }
            return personInfo;
        }

        /// <summary>
        /// Get random adult
        /// </summary>
        /// <returns></returns>
        public static Adult GetRandomAdult()
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
            string[] workPlaces = new string[]
            {
                "Data center","Shop","Warehouse",
                "School","Hospital","Home",
                "Office","Sport club"
            };
            Random random = new Random();
            string name="";
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
            MaritalStatus maritalStatus = MaritalStatus.Single;
            string passport=random.Next(1000, 9999).ToString();
            string job= workPlaces[random.Next(workPlaces.Length)];
            return new Adult(passport, job, maritalStatus, name, surname, age, gender);
        }
    }
}

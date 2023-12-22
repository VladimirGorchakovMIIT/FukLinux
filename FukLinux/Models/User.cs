using System.ComponentModel;

namespace FukLinux.Models
{
    public class User
    {
        private static int CountId = 0;
        public User()
        {
            Id = CountId;
            CountId++;
        }
        public int Id { get; private set; }

        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        public enum StageDescription { ТолькоНачал, Любитель, Профессионал}

        [DisplayName("Стаж")]
        public StageDescription Stage {  get; set; }
    }
}

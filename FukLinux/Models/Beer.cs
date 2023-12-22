using System.ComponentModel;

namespace FukLinux.Models
{
    public class Beer
    {
        private static int CountId = 0;
        public Beer()
        {
            Id = CountId;
            CountId++;
        }
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
    }
}

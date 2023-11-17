using System.Text.RegularExpressions;

namespace _1.Models
{
    public class Prepod
    {
        public int PrepodId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Phone { get; set; }

        public bool IsValidPhone()
        {
            return Regex.Match(Phone, @"\+? ?3?[ -]?8?[ -]?\(?(\d[ -]?){3}\)?[ -]?(\d[ -]?){7}").Success;
        }
        public int KafedraId { get; set; }
        public Kafedra? Kafedra { get; set; }
        public int StepenId { get; set; }
        public Stepen? Stepen { get; set; }

    }
}

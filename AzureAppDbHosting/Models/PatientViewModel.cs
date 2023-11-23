using System.ComponentModel;

namespace AzureAppDbHosting.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        [DisplayName ("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Gender")]
        public string? Gender { get; set; }

        [DisplayName("Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [DisplayName("Phone")]
        public string? Phone { get; set; }

		[DisplayName("Notification")]
		public string? Notification { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignExplorer.DataAccess.Model
{
    public class Configuration
    {

    }

    public class DaysConfiguration
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public int? Day { get; set; }

        public string Value { get; set; }

        public DateTime CreatedDate { get; set; }
    }
    public class ListConfiguration
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public string ListType { get; set; }

        public string ListFrequency { get; set; }

        public string FrequencyDetail { get; set; }

        public DateTime CreatedDate { get; set; }
    }
    public class OtherConfiguration
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public string CommunicationEmail { get; set; }

        public DateTime CreatedDate { get; set; }
    }
    public class ConfigurationVieWModel
    {
        public ConfigurationVieWModel()
        {
            EmailList = false;
            CallList = false;
            MailList = false;
        }
        public List<DaysConfiguration> lstDaysConfiguration { get; set; }
        public List<ListConfiguration> lstListConfiguration { get; set; }
        public bool EmailList { get; set; }
        public bool CallList { get; set; }
        public bool MailList { get; set; }

        public string EmailListType { get; set; }
        public string EmailListFrequency { get; set; }

        public string EmailListFrequencyDetail { get; set; }

        public string MailListType { get; set; }
        public string MailListFrequency { get; set; }

        public string MailListFrequencyDetail { get; set; }

        public string CallListType { get; set; }
        public string CallListFrequency { get; set; }

        public string CallListFrequencyDetail { get; set; }

        public string CommunicationEmail { get; set; }
    }
}

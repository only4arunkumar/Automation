using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdder_Automation.Helpers
{
    public static class DataHelper
    {
        public static string GetRandomText(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetRandomPhone(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetRandomEMail(string value)
        {
            // Can be changed later to read  a config value
            // return string.Format("{0}+{1}@jobadder.com", ConfigurationManager.AppSettings["dataEmail"].ToString(),
            return string.Format("automationtesting+{0}@jobadder.com", value);

        }

    }
}

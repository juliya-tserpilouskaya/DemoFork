using System.Collections.Generic;

namespace BulbaCourses.Podcasts.Logic.Models
{
    internal static class AccountStorage
    {
        private static List<Account> Accounts = new List<Account>();

        internal static Account GetAccount(string userId)
        {
            int _id = 0;
            foreach (Account _account in Accounts)
            {
                if (_account.Id == userId)
                {
                    break;
                }
                _id++;
            }
            return Accounts[_id];
        }
    }
}
//to dblayer
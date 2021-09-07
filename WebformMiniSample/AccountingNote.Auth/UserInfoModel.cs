using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.Auth
{
    public class UserInfoModel
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public int UserLevel { get; set; }

        #region Custom Property
        public UserLevelEnum Level
        {
            get
            {
                return (UserLevelEnum)UserLevel;
            }
        }
        #endregion
    }
}

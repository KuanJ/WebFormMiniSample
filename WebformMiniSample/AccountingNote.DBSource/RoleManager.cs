using AccountingNote.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.DBSource
{
    class RoleManager
    {
        /// <summary> 取得所有角色清單 </summary>
        /// <returns></returns>
        public static List<Roles> GetRoleList()
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query = context.Roles;
                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary> 用名稱取得角色 </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public static Roles GetRoleByName(string roleName)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Roles
                         where item.RoleName == roleName
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        /// <summary> 用 id 取得角色 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Roles GetRole(Guid id)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Roles
                         where item.ID == id
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
    }
}

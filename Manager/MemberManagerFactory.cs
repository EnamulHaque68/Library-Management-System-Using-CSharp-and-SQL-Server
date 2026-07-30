using  LibraryManagementSystem.Entities;
using  LibraryManagementSystem.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LibraryManagementSystem.Manager
{
  public class MemberManagerFactory
    {
        public BaseMemberFactory CreateFactory(Member mems)
        {
            BaseMemberFactory returnValue = null;
             if (mems.MembType == Enums.MemberType.RegularMember)
            {
                returnValue = new Factory.RegularMemberFactory(mems);
            }
            else if (mems.MembType == Enums.MemberType.PremiumMember)
            {
                returnValue = new Factory.PremiumMemberFactory(mems);
            }
            return returnValue;
        }
    }
}

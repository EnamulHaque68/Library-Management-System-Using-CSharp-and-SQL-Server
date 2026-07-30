using  LibraryManagementSystem.Entities;
using  LibraryManagementSystem.Interfaces;
using  LibraryManagementSystem.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LibraryManagementSystem.Factory
{
    public class RegularMemberFactory : BaseMemberFactory
    {
        public RegularMemberFactory(Member memb) : base(memb)
        {
        }

        public override IMemberManager Create()
        {
            RegularMemberManagerFactory manager = new RegularMemberManagerFactory();
            return manager;
        }
    }
}

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
    public class PremiumMemberFactory : BaseMemberFactory
    {
        public PremiumMemberFactory(Member memb) : base(memb)
        {
        }

        public override IMemberManager Create()
        {
            PremiumMemberManagerFactory manager = new PremiumMemberManagerFactory();
            return manager;
        }
    }
}

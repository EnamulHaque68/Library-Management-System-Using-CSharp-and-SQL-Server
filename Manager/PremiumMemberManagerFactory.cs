using  LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LibraryManagementSystem.Manager
{
    public class PremiumMemberManagerFactory : IMemberManager
    {
        public double GetDiscount()
        {
            return 30.00;
        }
    }
}

using  LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LibraryManagementSystem.Manager
{
    public class RegularMemberManagerFactory : IMemberManager
    {
        public double GetDiscount()
        {
            return 10.00;
        }
    }
}

using  LibraryManagementSystem.Entities;
using  LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LibraryManagementSystem.Factory
{
 public abstract class BaseMemberFactory
    {
        public abstract IMemberManager Create();
        protected Member memb;
      
        public BaseMemberFactory(Member mems)
        {
            this.memb = mems;
        }

        public Member ApplyDisCount()
        {
            IMemberManager manager = this.Create();
            memb.DiscountPercentage = manager.GetDiscount();
            memb.PayAmount = memb.TotalAmount - (memb.TotalAmount * memb.DiscountPercentage/ 100);
            return memb;
        }
    }
}

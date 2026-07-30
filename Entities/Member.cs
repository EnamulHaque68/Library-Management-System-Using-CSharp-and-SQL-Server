using  LibraryManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LibraryManagementSystem.Entities
{
    public class Member
    {
        int memberId;
        string memberName;
        string memberEmail;
        MemberType membType;
        bool registerMember;
        double totalAmount;
        double discountPercentage;
        double payAmount;
        public Member()
        {
            
        }

        public Member(int memberId, string memberName, string memberEmail, MemberType membType, bool registerMember, double totalAmount, double discountPercentage, double payAmount)
        {
            this.memberId = memberId;
            this.memberName = memberName;
            this.memberEmail = memberEmail;
            this.membType = membType;
            this.registerMember = registerMember;
            this.totalAmount = totalAmount;
            this.discountPercentage = discountPercentage;
            this.payAmount = payAmount;
        }

        public int MemberId { get => memberId; set => memberId = value; }
        public string MemberName { get => memberName; set => memberName = value; }
        public string MemberEmail { get => memberEmail; set => memberEmail = value; }
        public MemberType MembType { get => membType; set => membType = value; }
        public bool RegisterMember { get => registerMember; set => registerMember = value; }
        public double TotalAmount { get => totalAmount; set => totalAmount = value; }
        public double DiscountPercentage { get => discountPercentage; set => discountPercentage = value; }
        public double PayAmount { get => payAmount; set => payAmount = value; }
    }
}

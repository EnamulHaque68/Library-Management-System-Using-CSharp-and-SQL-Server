using  LibraryManagementSystem.Entities;
using  LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LibraryManagementSystem.Repository
{
    public class MemberRepo : IMemberRepo
    {
        private List<Member> memberlist;
        public MemberRepo()
        {
            memberlist = new List<Member>()
            {
new Member (){MemberId=1,MemberName="Md.Enamul Haque",MemberEmail="enamul@gamil.com",MembType=Enums.MemberType.PremiumMember,RegisterMember=true,TotalAmount=1000.00,DiscountPercentage=30.00,PayAmount=700.00},
new Member (){MemberId=2,MemberName="Md.Pavel Haque",MemberEmail="pavel@gamil.com",MembType=Enums.MemberType.RegularMember,RegisterMember=false,TotalAmount=1000.00,DiscountPercentage=10,PayAmount=900.00},
new Member (){MemberId=3,MemberName="Md.Imtiaz Haque",MemberEmail="imtiaz@gamil.com",MembType=Enums.MemberType.PremiumMember,RegisterMember=true,TotalAmount=1000.00,DiscountPercentage=30,PayAmount=700.00}
            };
        }
        public Member DeleteMember(int id)
        {
            var deleteMemb = GetMemberById(id);
            if (deleteMemb != null)
            {
                memberlist.Remove(deleteMemb);
            }
            return deleteMemb;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return from mems in memberlist select mems;
        }

        public Member GetMemberById(int id)
        {
            var mems = (from m in memberlist where m.MemberId == id select m).FirstOrDefault();
            return mems;
        }

        public Member CreateMember(Member member)
        {
            Member mems = (from m in memberlist orderby m.MemberId descending select m).FirstOrDefault();
            member .MemberId = mems.MemberId + 1;
            memberlist.Add(member);
            return member;
        }

        public Member UpdateMember(Member upMember)
        {
            Member mems = GetMemberById(upMember.MemberId);
            mems.MemberName = upMember.MemberName;
            mems.MemberEmail = upMember.MemberEmail;
            mems.MembType= upMember.MembType;
            mems.TotalAmount = upMember.TotalAmount;
            mems.DiscountPercentage = upMember.DiscountPercentage;
            mems.PayAmount = upMember.PayAmount;
            mems.MemberId = upMember.MemberId;
            
            return upMember;
        }
    }
}

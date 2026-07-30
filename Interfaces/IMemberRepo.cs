using  LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LibraryManagementSystem.Interfaces
{
 public interface IMemberRepo
    {
        IEnumerable<Member> GetAllMembers();
        Member GetMemberById(int id);
        Member CreateMember(Member member);
        Member UpdateMember(Member upMember);
        Member DeleteMember(int id);
    }
}

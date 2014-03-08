using Ja222qmApp.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ja222qmApp.Model
{
    public class Service
    {
        private MemberDAL _memberDAL;

        private MemberDAL MemberDAL
        {
            get { return _memberDAL ?? (_memberDAL = new MemberDAL()); }
        }

        public Member GetMember(int memberId) 
        {
            return MemberDAL.GetMember(memberId);
        }


        public IEnumerable<Member> GetMembers() {
            return MemberDAL.GetMembers();
        }

        public void SaveMember(Member member) {
            if (member.MemberId == 0)
            {                
                MemberDAL.InsertMember(member);
            }
            else 
            {
                MemberDAL.UpdateMember(member);
            }
        }

        public void DeleteMember(int memberId)
        {
            MemberDAL.DeleteMember(memberId);
        }

    }
}
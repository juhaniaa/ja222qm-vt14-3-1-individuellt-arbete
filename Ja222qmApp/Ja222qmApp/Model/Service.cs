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

        private AreaDAL _areaDAL;

        private AreaDAL AreaDAL
        {
            get { return _areaDAL ?? (_areaDAL = new AreaDAL()); }
        }

        private HelperDAL _helperDAL;

        private HelperDAL HelperDAL
        {
            get { return _helperDAL ?? (_helperDAL = new HelperDAL()); }
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

        public IEnumerable<Area> GetAreas()
        {
            return AreaDAL.GetAreas();
        }

        public Area GetArea(int areaId)
        {
            return AreaDAL.GetArea(areaId);
        }

        public void SaveArea(Area area)
        {
            if (area.AreaId == 0)
            {
                AreaDAL.InsertArea(area);
            }
            else
            {
                AreaDAL.UpdateArea(area);
            }
        }

        public void DeleteArea(int areaId)
        {
            AreaDAL.DeleteArea(areaId);
        }

        public IEnumerable<Helper> GetHelperAreas(int helperId) 
        {
            return HelperDAL.GetHelperAreas(helperId);
        }

        public int DeleteHelperArea(int helperId)
        {
            return HelperDAL.DeleteHelperArea(helperId);
        }
    }
}
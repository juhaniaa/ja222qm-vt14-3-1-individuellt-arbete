using Ja222qmApp.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ja222qmApp.Model
{
    public class Service
    {
        // medlems objekt skapas då det behövs
        private MemberDAL _memberDAL;
        private MemberDAL MemberDAL
        {
            get { return _memberDAL ?? (_memberDAL = new MemberDAL()); }
        }

        // ansvars objekt skapas då det behövs
        private AreaDAL _areaDAL;
        private AreaDAL AreaDAL
        {
            get { return _areaDAL ?? (_areaDAL = new AreaDAL()); }
        }

        // medhjälpar objekt skapas då det behövs
        private HelperDAL _helperDAL;
        private HelperDAL HelperDAL
        {
            get { return _helperDAL ?? (_helperDAL = new HelperDAL()); }
        }

        #region Validation

        // metod för att validera ett medlemsobjekt
        private bool ValidateMember(Member member) 
        {
            var validationContext = new ValidationContext(member);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(member, validationContext, validationResults, true))
            {
                return false;
            }
            return true;
        }

        // metod för att validera ett ansvarsobjekt
        private bool ValidateArea(Area area)
        {
            var validationContext = new ValidationContext(area);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(area, validationContext, validationResults, true))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region MemberDAL

        // hämta ut specifik medlem
        public Member GetMember(int memberId) 
        {
            return MemberDAL.GetMember(memberId);
        }

        // hämta ut alla medlemmar
        public IEnumerable<Member> GetMembers() {
            return MemberDAL.GetMembers();
        }

        // spara medlem
        public void SaveMember(Member member) {

            if(!ValidateMember(member))
            {
                throw new ValidationException("Medlemmen klarade inte valideringen");
            }

            // om ny medlem
            if (member.MemberId == 0)
            {                
                // lägg till
                MemberDAL.InsertMember(member);
            }
            else 
            {
                // annars uppdatera befintlig
                MemberDAL.UpdateMember(member);
            }
        }

        // radera specifik medlem
        public void DeleteMember(int memberId)
        {
            MemberDAL.DeleteMember(memberId);
        }

        #endregion

        #region AreaDAL

        // hämta ut alla ansvarsområden
        public IEnumerable<Area> GetAreas()
        {
            return AreaDAL.GetAreas();
        }

        // hämta ut specifikt ansvarsområde
        public Area GetArea(int areaId)
        {
            return AreaDAL.GetArea(areaId);
        }

        // spara ansvarsområde
        public void SaveArea(Area area)
        {
            if (!ValidateArea(area))
            {
                throw new ValidationException("Ansvarsområdet klarade inte valideringen");
            }

            // om nytt
            if (area.AreaId == 0)
            {   
                // lägg till
                AreaDAL.InsertArea(area);
            }
            else
            {
                // annars uppdatera befintlig
                AreaDAL.UpdateArea(area);
            }
        }

        // radera specifikt ansvarsområde
        public void DeleteArea(int areaId)
        {
            AreaDAL.DeleteArea(areaId);
        }

        #endregion

        #region HelperDAL

        // hämta ut en medlems ansvarsområden
        public IEnumerable<Helper> GetHelperAreas(int helperId) 
        {
            return HelperDAL.GetHelperAreas(helperId);
        }

        // radera en medlems ansvarsområde
        public int DeleteHelperArea(int helperId)
        {
            return HelperDAL.DeleteHelperArea(helperId);
        }

        // lägg till nytt ansvar till medlem
        public void AddAreaToMember(int memberId, int areaId)
        {
            HelperDAL.AddAreaToMember(memberId, areaId);
        }

        // hämta ut alla medlemmar med specifikt ansvar
        public IEnumerable<Member> GetMembersByArea(int areaId)
        {
            return HelperDAL.GetMembersByArea(areaId);
        }

        #endregion
    }
}
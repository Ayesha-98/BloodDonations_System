using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccessLayer;

    namespace BusinessLogicLayer
    {
        public class StaffService
        {
            private readonly Staffs _repo;

            public StaffService()
            {
                _repo = new Staffs();
            }

            public List<StaffModel> GetAllStaff()
            {
                return _repo.GetAllStaff();
            }

            public void AddStaff(StaffModel staff)
            {
                _repo.AddStaff(staff);
            }

            public void UpdateStaff(StaffModel staff)
            {
                _repo.UpdateStaff(staff);
            }

            public void DeleteStaff(int id)
            {
                _repo.DeleteStaff(id);
            }
        }
    }



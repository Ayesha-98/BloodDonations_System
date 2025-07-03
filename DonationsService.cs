using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DonationService
    {
        private readonly Donations _donationRepo;

        public DonationService()
        {
            _donationRepo = new Donations();
        }

        public List<DonationModel> GetAllDonations()
        {
            return _donationRepo.GetAllDonations();
        }

        public void AddDonation(DonationModel donation)
        {
            _donationRepo.AddDonation(donation);
        }

        public void UpdateDonation(DonationModel donation)
        {
            _donationRepo.UpdateDonation(donation);
        }

        public void DeleteDonation(int id)
        {
            _donationRepo.DeleteDonation(id);
        }
    }
}

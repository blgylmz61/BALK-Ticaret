﻿using DAL.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BALK_Ticaret.Models
{
    public class UserDetailViewModel : BaseEntityViewModel
    {
        public DateTime Birthday { get; set; }
        public int GenderId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string TcNo { get; set; }
        public string Photo { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public CountryViewModel? Country{ get; set; }
        public CityViewModel? City { get; set; }
        public DistrictViewModel? District { get; set; }
        public IFormFile? PhotoUrl { get; set; }
        public UserViewModel? User { get; set; }
        public GenderViewModel? Gender { get; set; }
    }
}

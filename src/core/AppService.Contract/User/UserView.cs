using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimeLogger.AppService.Contract.User
{
    public class UserView
    {
        public int Id { get; set; }
        public UserView()
        {
            IsActive = true;
        }
        public string UserName { get; set; }

        public string FullName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        
    }
    public enum GenderType
    {
        [Display(Name = "Man")]
        Male = 1,

        [Display(Name = "Woman")]
        Female = 2
    }
}
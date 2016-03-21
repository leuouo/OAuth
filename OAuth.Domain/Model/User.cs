using System;
using System.Collections.Generic;


namespace OAuth.Domain.Model
{
    public class User : AggregateRoot
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string DigitalCertificate { get; set; }

        public DateTime? LastLogonDate { get; set; }

        public byte Status { get; set; }

        public DateTime AddDate { get; set; }

        public UserFlag UserFlag { get; set; }

        public string Email { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }
    }

    /// <summary>
    /// 用户模型
    /// </summary>
    public enum UserFlag : byte
    {
        /// <summary>
        /// 采购商
        /// </summary>
        Buyer,

        /// <summary>
        /// 供应商
        /// </summary>
        Supplier
    }
}

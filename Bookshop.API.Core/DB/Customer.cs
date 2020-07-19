namespace Bookshop.API.Core.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Address1 { get; set; }

        [StringLength(255)]
        public string Address2 { get; set; }

        public int TownCityID { get; set; }

        public int CountryID { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerAccountNumber { get; set; }

        public int? GiftCardNumber { get; set; }
    }
}

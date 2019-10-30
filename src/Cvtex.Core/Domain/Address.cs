using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cvtex.Core.Domain
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public Guid Id { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string Postcode { get; protected set; }
        public int FlatNumber { get; protected set; }
        public int StreetNumber { get; protected set; }
        public virtual ICollection<User> Users { get; protected set; }
    }
}
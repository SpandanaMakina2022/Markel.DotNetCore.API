using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Claims.Abstractions.Models
{
    [DataContract]
    public class Company
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string Address2 { get; set; }
        [DataMember]
        public string Address3 { get; set; }
        [DataMember]
        public string Postcode { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [IgnoreDataMember]
        public bool IsPolicyActive { get; set; }
        [DataMember]
        public DateTime InsuranceEndDate { get; set; }
    }
}

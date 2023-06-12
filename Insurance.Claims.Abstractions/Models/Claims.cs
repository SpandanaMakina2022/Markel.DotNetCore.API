using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Claims.Abstractions.Models
{
    [DataContract]
    public class InsuranceClaim
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public string UCR { get; set; }
        [DataMember]
        public DateTime ClaimDate { get; set; }
        [DataMember]
        public DateTime LossDate { get; set; }
        [DataMember]
        public string AssuredName { get; set; }
        [DataMember]
        public decimal IncurredLoss { get; set; }
        [DataMember]
        public bool Closed { get; set; }
        [IgnoreDataMember]
        public int ClaimedDays { get; set; }
    }
}

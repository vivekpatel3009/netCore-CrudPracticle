using System;
using System.Collections.Generic;

namespace CoreTestApi.DBModels
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Bithday { get; set; }
        public int? StateId { get; set; }
        public int? ContryId { get; set; }
        public int? CityId { get; set; }
        public bool? IsActive { get; set; }
        public string AreaOfInterest { get; set; }
    }
}

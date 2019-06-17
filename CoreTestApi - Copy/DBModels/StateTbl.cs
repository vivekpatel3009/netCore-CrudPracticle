using System;
using System.Collections.Generic;

namespace CoreTestApi.DBModels
{
    public partial class StateTbl
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int? StateId { get; set; }
        public int? ContryId { get; set; }
    }
}

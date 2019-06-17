using System;
using System.Collections.Generic;

namespace CoreTestApi.DBModels
{
    public partial class ContryTbl
    {
        public int Id { get; set; }
        public int? ContryId { get; set; }
        public string ContryName { get; set; }
    }
}

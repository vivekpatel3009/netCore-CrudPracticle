using System;
using System.Collections.Generic;

namespace CoreTestApi.DBModels
{
    public partial class CityTbl
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }
    }
}

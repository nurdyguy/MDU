using System.Collections.Generic;
using MDU.Models.Appraisal;

namespace MDU.Models.AppraisalViewModels
{
    public class PropertyListRequestModel
    {
        public List<PropertyFilterRange> Filters { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
    }
}

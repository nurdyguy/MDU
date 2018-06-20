using MDU.Models.AppraisalModels;

namespace MDU.Models.Appraisal
{
    public class PropertyFilterRange
    {
        public PropertyFilter Filter { get; set; }
        public PropertyFilterValue FromValue { get; set; }
        public PropertyFilterValue ToValue { get; set; }
    }
}

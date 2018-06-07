using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDU.Models.AppraisalModels
{
    public class PropertyFilter : EnumClass
    {
        private int _id;
        private string _description;
        private string _name;
        public static readonly PropertyFilter Beds = new PropertyFilter(0, "", "Beds");
        public static readonly PropertyFilter Baths = new PropertyFilter(1, "", "Baths");
        public static readonly PropertyFilter SquareFeet = new PropertyFilter(2, "", "Square Feet");
        public static readonly PropertyFilter Garage = new PropertyFilter(3, "", "Garage");
        public static readonly PropertyFilter Pool = new PropertyFilter(4, "", "Pool");
        public static readonly PropertyFilter LotSize = new PropertyFilter(4, "", "Lot Size (Acres)");
        public static readonly PropertyFilter YearBuilt = new PropertyFilter(4, "", "Year Built");

        private PropertyFilter(int Id, string Description, string Name)
        {
            _id = Id;
            _description = Description;
            _name = Name;
        }
        public int Id { get { return _id; } }
        public string Description { get { return _description; } }
        public string Name { get { return _name; } }

        public static List<PropertyFilter> PropertyFilters
        {
            get {
                return new List<PropertyFilter>()
                {
                    PropertyFilter.Beds,
                    PropertyFilter.Baths,
                    PropertyFilter.SquareFeet,
                    PropertyFilter.Garage,
                    PropertyFilter.Pool,
                    PropertyFilter.LotSize,
                    PropertyFilter.YearBuilt,
                };
            }
        }
    }
}

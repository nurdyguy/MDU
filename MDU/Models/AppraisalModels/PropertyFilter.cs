using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDU.Models.AppraisalModels
{
    public class PropertyFilter : EnumClass
    {
        private string _description;        
        private IEnumerable<PropertyFilterValue> _values;
        private string _shortName;

        public static readonly PropertyFilter Beds = new PropertyFilter(0, "Beds", "Beds", "beds", PropertyFilterValue.PropertyFilterValues(0));
        public static readonly PropertyFilter Baths = new PropertyFilter(1, "Baths", "Baths", "baths", PropertyFilterValue.PropertyFilterValues(1));        
        public static readonly PropertyFilter Garage = new PropertyFilter(2, "Garage", "Garage", "garage", PropertyFilterValue.PropertyFilterValues(2));
        public static readonly PropertyFilter Pool = new PropertyFilter(3, "Pool", "Pool", "pool", PropertyFilterValue.PropertyFilterValues(3));
        public static readonly PropertyFilter SquareFeet = new PropertyFilter(4, "SquareFeet", "Square Feet", "sqft", PropertyFilterValue.PropertyFilterValues(4));
        public static readonly PropertyFilter LotSize = new PropertyFilter(5, "LotSizeAcreage", "Lot Size (Acres)", "lotSize", PropertyFilterValue.PropertyFilterValues(5));
        public static readonly PropertyFilter YearBuilt = new PropertyFilter(6, "YearBuilt", "Year Built", "yearBuilt", PropertyFilterValue.PropertyFilterValues(6));
        public static readonly PropertyFilter CloseDate = new PropertyFilter(7, "CloseDate", "Close Date", "closeDate", PropertyFilterValue.PropertyFilterValues(7));

        
        private PropertyFilter(int Id, string Description, string Name, string ShortName, IEnumerable<PropertyFilterValue> Values)
        {
            _id = Id;
            _description = Description;
            _name = Name;
            _values = Values;
            _shortName = ShortName;
        }

        [JsonConstructor]
        private PropertyFilter(int Id)
        {
            var prop = GetPropertyFilter(Id);
            _id = prop.Id;
            _name = prop.Name;
            _description = prop.Description;
            _values = prop.Values;
            _shortName = prop._shortName;
        }

        public string Description { get { return _description; } }        
        public string ShortName { get { return _shortName; } }
        public IEnumerable<PropertyFilterValue> Values { get { return _values; } }
        
        public static PropertyFilter GetPropertyFilter(int id)
        {
            return PropertyFilters().FirstOrDefault(x => x.Id == id);
        }

        public static List<PropertyFilter> PropertyFilters()
        {
            return new List<PropertyFilter>()
            {
                PropertyFilter.Beds,
                PropertyFilter.Baths,
                PropertyFilter.SquareFeet,
                PropertyFilter.Garage,
                PropertyFilter.Pool,
                PropertyFilter.LotSize,
                PropertyFilter.YearBuilt,
                PropertyFilter.CloseDate
            };
        }
    }

    public class PropertyFilterValue : EnumClass
    {
        private string _description;
        private string _value;
        private int _filterId;

        public string Description { get { return _description; } }
        public string Value { get { return _value; } }
        public int FilterId { get { return _filterId; } }

        private PropertyFilterValue(int Id, string Name, string Description, string Value, int FilterId)
        {
            _id = Id;
            _name = Name;
            _description = Description;
            _value = Value;
            _filterId = FilterId;
        }

        [JsonConstructor]
        private PropertyFilterValue(int Id)
        {
            var pfv = GetPropertyFilterValue(Id);
            _id = pfv.Id;
            _name = pfv.Name;
            _description = pfv.Description;
            _value = pfv.Value;
            _filterId = pfv.FilterId;
        }

        public static PropertyFilterValue GetPropertyFilterValue(int propertyFilterId)
        {
            return PropertyFilterValues().FirstOrDefault(v => v.Id == propertyFilterId);
        }

        public static List<PropertyFilterValue> PropertyFilterValues()
        {
            return new List<PropertyFilterValue>()
            {
                PropertyFilterValue.Beds1,
                PropertyFilterValue.Beds2,
                PropertyFilterValue.Beds3,
                PropertyFilterValue.Beds4,
                PropertyFilterValue.Beds5,
                PropertyFilterValue.Beds6,
                PropertyFilterValue.Beds7,
                PropertyFilterValue.Beds8,
                PropertyFilterValue.Beds9,
                PropertyFilterValue.Beds10,

                PropertyFilterValue.Baths1,
                PropertyFilterValue.Baths1_1,
                PropertyFilterValue.Baths2,
                PropertyFilterValue.Baths2_1,
                PropertyFilterValue.Baths3,
                PropertyFilterValue.Baths3_1,
                PropertyFilterValue.Baths4,
                PropertyFilterValue.Baths4_1,
                PropertyFilterValue.Baths5,
                PropertyFilterValue.Baths5_1,

                PropertyFilterValue.Garage1,
                PropertyFilterValue.Garage2,
                PropertyFilterValue.Garage3,
                PropertyFilterValue.Garage4,
                PropertyFilterValue.Garage5,

                PropertyFilterValue.HasPool,
                PropertyFilterValue.NoPool,

                PropertyFilterValue.SquareFeet1000,
                PropertyFilterValue.SquareFeet1250,
                PropertyFilterValue.SquareFeet1500,
                PropertyFilterValue.SquareFeet1750,
                PropertyFilterValue.SquareFeet2000,
                PropertyFilterValue.SquareFeet2250,
                PropertyFilterValue.SquareFeet2500,
                PropertyFilterValue.SquareFeet2750,
                PropertyFilterValue.SquareFeet3000,
                PropertyFilterValue.SquareFeet3250,
                PropertyFilterValue.SquareFeet3500,
                PropertyFilterValue.SquareFeet3750,
                PropertyFilterValue.SquareFeet4000,
                PropertyFilterValue.SquareFeet4250,
                PropertyFilterValue.SquareFeet4500,
                PropertyFilterValue.SquareFeet4750,
                PropertyFilterValue.SquareFeet5000,
                PropertyFilterValue.SquareFeet5250,
                PropertyFilterValue.SquareFeet5500,
                PropertyFilterValue.SquareFeet5750,
                PropertyFilterValue.SquareFeet6000,
                PropertyFilterValue.SquareFeet6250,
                PropertyFilterValue.SquareFeet6500,
                PropertyFilterValue.SquareFeet6750,
                PropertyFilterValue.SquareFeet7000,
                PropertyFilterValue.SquareFeet7250,
                PropertyFilterValue.SquareFeet7500,
                PropertyFilterValue.SquareFeet7750,
                PropertyFilterValue.SquareFeet8000,

                PropertyFilterValue.LotSize0_10,
                PropertyFilterValue.LotSize0_20,
                PropertyFilterValue.LotSize0_30,
                PropertyFilterValue.LotSize0_40,
                PropertyFilterValue.LotSize0_50,
                PropertyFilterValue.LotSize0_60,
                PropertyFilterValue.LotSize0_70,
                PropertyFilterValue.LotSize0_80,
                PropertyFilterValue.LotSize0_90,
                PropertyFilterValue.LotSize1_00,
                PropertyFilterValue.LotSize1_10,
                PropertyFilterValue.LotSize1_20,
                PropertyFilterValue.LotSize1_30,
                PropertyFilterValue.LotSize1_40,
                PropertyFilterValue.LotSize1_50,
                PropertyFilterValue.LotSize1_60,
                PropertyFilterValue.LotSize1_70,
                PropertyFilterValue.LotSize1_80,
                PropertyFilterValue.LotSize1_90,
                PropertyFilterValue.LotSize2_00,

                PropertyFilterValue.YearBuilt1970,
                PropertyFilterValue.YearBuilt1971,
                PropertyFilterValue.YearBuilt1972,
                PropertyFilterValue.YearBuilt1973,
                PropertyFilterValue.YearBuilt1974,
                PropertyFilterValue.YearBuilt1975,
                PropertyFilterValue.YearBuilt1976,
                PropertyFilterValue.YearBuilt1977,
                PropertyFilterValue.YearBuilt1978,
                PropertyFilterValue.YearBuilt1979,
                PropertyFilterValue.YearBuilt1980,
                PropertyFilterValue.YearBuilt1981,
                PropertyFilterValue.YearBuilt1982,
                PropertyFilterValue.YearBuilt1983,
                PropertyFilterValue.YearBuilt1984,
                PropertyFilterValue.YearBuilt1985,
                PropertyFilterValue.YearBuilt1986,
                PropertyFilterValue.YearBuilt1987,
                PropertyFilterValue.YearBuilt1988,
                PropertyFilterValue.YearBuilt1989,
                PropertyFilterValue.YearBuilt1990,
                PropertyFilterValue.YearBuilt1991,
                PropertyFilterValue.YearBuilt1992,
                PropertyFilterValue.YearBuilt1993,
                PropertyFilterValue.YearBuilt1994,
                PropertyFilterValue.YearBuilt1995,
                PropertyFilterValue.YearBuilt1996,
                PropertyFilterValue.YearBuilt1997,
                PropertyFilterValue.YearBuilt1998,
                PropertyFilterValue.YearBuilt1999,
                PropertyFilterValue.YearBuilt2000,
                PropertyFilterValue.YearBuilt2001,
                PropertyFilterValue.YearBuilt2002,
                PropertyFilterValue.YearBuilt2003,
                PropertyFilterValue.YearBuilt2004,
                PropertyFilterValue.YearBuilt2005,
                PropertyFilterValue.YearBuilt2006,
                PropertyFilterValue.YearBuilt2007,
                PropertyFilterValue.YearBuilt2008,
                PropertyFilterValue.YearBuilt2009,
                PropertyFilterValue.YearBuilt2010,
                PropertyFilterValue.YearBuilt2011,
                PropertyFilterValue.YearBuilt2012,
                PropertyFilterValue.YearBuilt2013,
                PropertyFilterValue.YearBuilt2014,
                PropertyFilterValue.YearBuilt2015,
                PropertyFilterValue.YearBuilt2016,
                PropertyFilterValue.YearBuilt2017,
                PropertyFilterValue.YearBuilt2018,
                PropertyFilterValue.YearBuilt2019,

                PropertyFilterValue.CloseDate2015_1,
                PropertyFilterValue.CloseDate2015_2,
                PropertyFilterValue.CloseDate2015_3,
                PropertyFilterValue.CloseDate2015_4,
                PropertyFilterValue.CloseDate2015_5,
                PropertyFilterValue.CloseDate2015_6,
                PropertyFilterValue.CloseDate2015_7,
                PropertyFilterValue.CloseDate2015_8,
                PropertyFilterValue.CloseDate2015_9,
                PropertyFilterValue.CloseDate2015_10,
                PropertyFilterValue.CloseDate2015_11,
                PropertyFilterValue.CloseDate2015_12,
                PropertyFilterValue.CloseDate2016_1,
                PropertyFilterValue.CloseDate2016_2,
                PropertyFilterValue.CloseDate2016_3,
                PropertyFilterValue.CloseDate2016_4,
                PropertyFilterValue.CloseDate2016_5,
                PropertyFilterValue.CloseDate2016_6,
                PropertyFilterValue.CloseDate2016_7,
                PropertyFilterValue.CloseDate2016_8,
                PropertyFilterValue.CloseDate2016_9,
                PropertyFilterValue.CloseDate2016_10,
                PropertyFilterValue.CloseDate2016_11,
                PropertyFilterValue.CloseDate2016_12,
                PropertyFilterValue.CloseDate2017_1,
                PropertyFilterValue.CloseDate2017_2,
                PropertyFilterValue.CloseDate2017_3,
                PropertyFilterValue.CloseDate2017_4,
                PropertyFilterValue.CloseDate2017_5,
                PropertyFilterValue.CloseDate2017_6,
                PropertyFilterValue.CloseDate2017_7,
                PropertyFilterValue.CloseDate2017_8,
                PropertyFilterValue.CloseDate2017_9,
                PropertyFilterValue.CloseDate2017_10,
                PropertyFilterValue.CloseDate2017_11,
                PropertyFilterValue.CloseDate2017_12,
                PropertyFilterValue.CloseDate2018_1,
                PropertyFilterValue.CloseDate2018_2,
                PropertyFilterValue.CloseDate2018_3,
                PropertyFilterValue.CloseDate2018_4,
                PropertyFilterValue.CloseDate2018_5,
                PropertyFilterValue.CloseDate2018_6,
                PropertyFilterValue.CloseDate2018_7,
                PropertyFilterValue.CloseDate2018_8,
                PropertyFilterValue.CloseDate2018_9,
                PropertyFilterValue.CloseDate2018_10,
                PropertyFilterValue.CloseDate2018_11,
                PropertyFilterValue.CloseDate2018_12
            };            
        }

        public static List<PropertyFilterValue> PropertyFilterValues(int filterId)
        {
            return PropertyFilterValues().Where(v => v.FilterId == filterId).ToList();
        }

        public static List<PropertyFilterValue> PropertyFilterValues(PropertyFilter filter)
        {
            return PropertyFilterValues(filter.Id);
        }

        public static readonly PropertyFilterValue Beds1 = new PropertyFilterValue(0, "Beds1", "1 Bedroom", "1", 0);
        public static readonly PropertyFilterValue Beds2 = new PropertyFilterValue(1, "Beds2", "2 Bedrooms", "2", 0);
        public static readonly PropertyFilterValue Beds3 = new PropertyFilterValue(2, "Beds3", "3 Bedrooms", "3", 0);
        public static readonly PropertyFilterValue Beds4 = new PropertyFilterValue(3, "Beds4", "4 Bedrooms", "4", 0);
        public static readonly PropertyFilterValue Beds5 = new PropertyFilterValue(4, "Beds5", "5 Bedrooms", "5", 0);
        public static readonly PropertyFilterValue Beds6 = new PropertyFilterValue(5, "Beds6", "6 Bedrooms", "6", 0);
        public static readonly PropertyFilterValue Beds7 = new PropertyFilterValue(6, "Beds7", "7 Bedrooms", "7", 0);
        public static readonly PropertyFilterValue Beds8 = new PropertyFilterValue(7, "Beds8", "8 Bedrooms", "8", 0);
        public static readonly PropertyFilterValue Beds9 = new PropertyFilterValue(8, "Beds9", "9 Bedrooms", "9", 0);
        public static readonly PropertyFilterValue Beds10 = new PropertyFilterValue(9, "Beds10", "10 Bedrooms", "10", 0);

        public static readonly PropertyFilterValue Baths1 = new PropertyFilterValue(10, "Baths1", "1 Bathroom", "1", 1);
        public static readonly PropertyFilterValue Baths1_1 = new PropertyFilterValue(11, "Baths1.1", "1.1 Bathrooms", "1.1", 1);
        public static readonly PropertyFilterValue Baths2 = new PropertyFilterValue(12, "Baths2", "2 Bathrooms", "2", 1);
        public static readonly PropertyFilterValue Baths2_1 = new PropertyFilterValue(13, "Baths2.1", "2.1 Bathrooms", "2.1", 1);
        public static readonly PropertyFilterValue Baths3 = new PropertyFilterValue(14, "Baths3", "3 Bathrooms", "3", 1);
        public static readonly PropertyFilterValue Baths3_1 = new PropertyFilterValue(15, "Baths3.1", "3.1 Bathrooms", "3.1", 1);
        public static readonly PropertyFilterValue Baths4 = new PropertyFilterValue(16, "Baths4", "4 Bathrooms", "4", 1);
        public static readonly PropertyFilterValue Baths4_1 = new PropertyFilterValue(17, "Baths4.1", "4.1 Bathrooms", "4.1", 1);
        public static readonly PropertyFilterValue Baths5 = new PropertyFilterValue(18, "Baths5", "5 Bathrooms", "5", 1);
        public static readonly PropertyFilterValue Baths5_1 = new PropertyFilterValue(19, "Baths5.1", "5.1 Bathrooms", "5.1", 1);

        public static readonly PropertyFilterValue Garage1 = new PropertyFilterValue(20, "Garage1", "1 Car Garage", "1", 2);
        public static readonly PropertyFilterValue Garage2 = new PropertyFilterValue(21, "Garage2", "2 Car Garage", "2", 2);
        public static readonly PropertyFilterValue Garage3 = new PropertyFilterValue(22, "Garage3", "3 Car Garage", "3", 2);
        public static readonly PropertyFilterValue Garage4 = new PropertyFilterValue(23, "Garage4", "4 Car Garage", "4", 2);
        public static readonly PropertyFilterValue Garage5 = new PropertyFilterValue(24, "Garage5", "5 Car Garage", "5", 2);

        public static readonly PropertyFilterValue HasPool = new PropertyFilterValue(25, "HasPool", "Has Pool", "True", 3);
        public static readonly PropertyFilterValue NoPool = new PropertyFilterValue(26, "NoPool", "No Pool", "False", 3);

        public static readonly PropertyFilterValue SquareFeet1000 = new PropertyFilterValue(27, "SquareFeet1000", "1000 Square Feet", "1000", 4);
        public static readonly PropertyFilterValue SquareFeet1250 = new PropertyFilterValue(28, "SquareFeet1250", "1250 Square Feet", "1250", 4);
        public static readonly PropertyFilterValue SquareFeet1500 = new PropertyFilterValue(29, "SquareFeet1500", "1500 Square Feet", "1500", 4);
        public static readonly PropertyFilterValue SquareFeet1750 = new PropertyFilterValue(30, "SquareFeet1750", "1750 Square Feet", "1750", 4);
        public static readonly PropertyFilterValue SquareFeet2000 = new PropertyFilterValue(31, "SquareFeet2000", "2000 Square Feet", "2000", 4);
        public static readonly PropertyFilterValue SquareFeet2250 = new PropertyFilterValue(32, "SquareFeet2250", "2250 Square Feet", "2250", 4);
        public static readonly PropertyFilterValue SquareFeet2500 = new PropertyFilterValue(33, "SquareFeet2500", "2500 Square Feet", "2500", 4);
        public static readonly PropertyFilterValue SquareFeet2750 = new PropertyFilterValue(34, "SquareFeet2750", "2750 Square Feet", "2750", 4);
        public static readonly PropertyFilterValue SquareFeet3000 = new PropertyFilterValue(35, "SquareFeet3000", "3000 Square Feet", "3000", 4);
        public static readonly PropertyFilterValue SquareFeet3250 = new PropertyFilterValue(36, "SquareFeet3250", "3250 Square Feet", "3250", 4);
        public static readonly PropertyFilterValue SquareFeet3500 = new PropertyFilterValue(37, "SquareFeet3500", "3500 Square Feet", "3500", 4);
        public static readonly PropertyFilterValue SquareFeet3750 = new PropertyFilterValue(38, "SquareFeet3750", "3750 Square Feet", "3750", 4);
        public static readonly PropertyFilterValue SquareFeet4000 = new PropertyFilterValue(39, "SquareFeet4000", "4000 Square Feet", "4000", 4);
        public static readonly PropertyFilterValue SquareFeet4250 = new PropertyFilterValue(40, "SquareFeet4250", "4250 Square Feet", "4250", 4);
        public static readonly PropertyFilterValue SquareFeet4500 = new PropertyFilterValue(41, "SquareFeet4500", "4500 Square Feet", "4500", 4);
        public static readonly PropertyFilterValue SquareFeet4750 = new PropertyFilterValue(42, "SquareFeet4750", "4750 Square Feet", "4750", 4);
        public static readonly PropertyFilterValue SquareFeet5000 = new PropertyFilterValue(43, "SquareFeet5000", "5000 Square Feet", "5000", 4);
        public static readonly PropertyFilterValue SquareFeet5250 = new PropertyFilterValue(44, "SquareFeet5250", "5250 Square Feet", "5250", 4);
        public static readonly PropertyFilterValue SquareFeet5500 = new PropertyFilterValue(45, "SquareFeet5500", "5500 Square Feet", "5500", 4);
        public static readonly PropertyFilterValue SquareFeet5750 = new PropertyFilterValue(46, "SquareFeet5750", "5750 Square Feet", "5750", 4);
        public static readonly PropertyFilterValue SquareFeet6000 = new PropertyFilterValue(47, "SquareFeet6000", "6000 Square Feet", "6000", 4);
        public static readonly PropertyFilterValue SquareFeet6250 = new PropertyFilterValue(48, "SquareFeet6250", "6250 Square Feet", "6250", 4);
        public static readonly PropertyFilterValue SquareFeet6500 = new PropertyFilterValue(49, "SquareFeet6500", "6500 Square Feet", "6500", 4);
        public static readonly PropertyFilterValue SquareFeet6750 = new PropertyFilterValue(50, "SquareFeet6750", "6750 Square Feet", "6750", 4);
        public static readonly PropertyFilterValue SquareFeet7000 = new PropertyFilterValue(51, "SquareFeet7000", "7000 Square Feet", "7000", 4);
        public static readonly PropertyFilterValue SquareFeet7250 = new PropertyFilterValue(52, "SquareFeet7250", "7250 Square Feet", "7250", 4);
        public static readonly PropertyFilterValue SquareFeet7500 = new PropertyFilterValue(53, "SquareFeet7500", "7500 Square Feet", "7500", 4);
        public static readonly PropertyFilterValue SquareFeet7750 = new PropertyFilterValue(54, "SquareFeet7750", "7750 Square Feet", "7750", 4);
        public static readonly PropertyFilterValue SquareFeet8000 = new PropertyFilterValue(55, "SquareFeet8000", "8000 Square Feet", "8000", 4);

        public static readonly PropertyFilterValue LotSize0_10 = new PropertyFilterValue(56, "Acres0.1", "0.1 Acres", "0.1", 5);
        public static readonly PropertyFilterValue LotSize0_20 = new PropertyFilterValue(57, "Acres0.2", "0.2 Acres", "0.2", 5);
        public static readonly PropertyFilterValue LotSize0_30 = new PropertyFilterValue(58, "Acres0.3", "0.3 Acres", "0.3", 5);
        public static readonly PropertyFilterValue LotSize0_40 = new PropertyFilterValue(59, "Acres0.4", "0.4 Acres", "0.4", 5);
        public static readonly PropertyFilterValue LotSize0_50 = new PropertyFilterValue(60, "Acres0.5", "0.5 Acres", "0.5", 5);
        public static readonly PropertyFilterValue LotSize0_60 = new PropertyFilterValue(61, "Acres0.6", "0.6 Acres", "0.6", 5);
        public static readonly PropertyFilterValue LotSize0_70 = new PropertyFilterValue(62, "Acres0.7", "0.7 Acres", "0.7", 5);
        public static readonly PropertyFilterValue LotSize0_80 = new PropertyFilterValue(63, "Acres0.8", "0.8 Acres", "0.8", 5);
        public static readonly PropertyFilterValue LotSize0_90 = new PropertyFilterValue(64, "Acres0.9", "0.9 Acres", "0.9", 5);
        public static readonly PropertyFilterValue LotSize1_00 = new PropertyFilterValue(65, "Acres1.0", "1.0 Acres", "1.0", 5);
        public static readonly PropertyFilterValue LotSize1_10 = new PropertyFilterValue(66, "Acres1.1", "1.1 Acres", "1.1", 5);
        public static readonly PropertyFilterValue LotSize1_20 = new PropertyFilterValue(67, "Acres1.2", "1.2 Acres", "1.2", 5);
        public static readonly PropertyFilterValue LotSize1_30 = new PropertyFilterValue(68, "Acres1.3", "1.3 Acres", "1.3", 5);
        public static readonly PropertyFilterValue LotSize1_40 = new PropertyFilterValue(69, "Acres1.4", "1.4 Acres", "1.4", 5);
        public static readonly PropertyFilterValue LotSize1_50 = new PropertyFilterValue(70, "Acres1.5", "1.5 Acres", "1.5", 5);
        public static readonly PropertyFilterValue LotSize1_60 = new PropertyFilterValue(71, "Acres1.6", "1.6 Acres", "1.6", 5);
        public static readonly PropertyFilterValue LotSize1_70 = new PropertyFilterValue(72, "Acres1.7", "1.7 Acres", "1.7", 5);
        public static readonly PropertyFilterValue LotSize1_80 = new PropertyFilterValue(73, "Acres1.8", "1.8 Acres", "1.8", 5);
        public static readonly PropertyFilterValue LotSize1_90 = new PropertyFilterValue(74, "Acres1.9", "1.9 Acres", "1.9", 5);
        public static readonly PropertyFilterValue LotSize2_00 = new PropertyFilterValue(75, "Acres2.0", "2.0 Acres", "2.0", 5);

        public static readonly PropertyFilterValue YearBuilt1970 = new PropertyFilterValue(76, "1970", "1970", "1970", 6);
        public static readonly PropertyFilterValue YearBuilt1971 = new PropertyFilterValue(77, "1971", "1971", "1971", 6);
        public static readonly PropertyFilterValue YearBuilt1972 = new PropertyFilterValue(78, "1972", "1972", "1972", 6);
        public static readonly PropertyFilterValue YearBuilt1973 = new PropertyFilterValue(79, "1973", "1973", "1973", 6);
        public static readonly PropertyFilterValue YearBuilt1974 = new PropertyFilterValue(80, "1974", "1974", "1974", 6);
        public static readonly PropertyFilterValue YearBuilt1975 = new PropertyFilterValue(81, "1975", "1975", "1975", 6);
        public static readonly PropertyFilterValue YearBuilt1976 = new PropertyFilterValue(82, "1976", "1976", "1976", 6);
        public static readonly PropertyFilterValue YearBuilt1977 = new PropertyFilterValue(83, "1977", "1977", "1977", 6);
        public static readonly PropertyFilterValue YearBuilt1978 = new PropertyFilterValue(84, "1978", "1978", "1978", 6);
        public static readonly PropertyFilterValue YearBuilt1979 = new PropertyFilterValue(85, "1979", "1979", "1979", 6);
        public static readonly PropertyFilterValue YearBuilt1980 = new PropertyFilterValue(86, "1980", "1980", "1980", 6);
        public static readonly PropertyFilterValue YearBuilt1981 = new PropertyFilterValue(87, "1981", "1981", "1981", 6);
        public static readonly PropertyFilterValue YearBuilt1982 = new PropertyFilterValue(88, "1982", "1982", "1982", 6);
        public static readonly PropertyFilterValue YearBuilt1983 = new PropertyFilterValue(89, "1983", "1983", "1983", 6);
        public static readonly PropertyFilterValue YearBuilt1984 = new PropertyFilterValue(90, "1984", "1984", "1984", 6);
        public static readonly PropertyFilterValue YearBuilt1985 = new PropertyFilterValue(91, "1985", "1985", "1985", 6);
        public static readonly PropertyFilterValue YearBuilt1986 = new PropertyFilterValue(92, "1986", "1986", "1986", 6);
        public static readonly PropertyFilterValue YearBuilt1987 = new PropertyFilterValue(93, "1987", "1987", "1987", 6);
        public static readonly PropertyFilterValue YearBuilt1988 = new PropertyFilterValue(94, "1988", "1988", "1988", 6);
        public static readonly PropertyFilterValue YearBuilt1989 = new PropertyFilterValue(95, "1989", "1989", "1989", 6);
        public static readonly PropertyFilterValue YearBuilt1990 = new PropertyFilterValue(96, "1990", "1990", "1990", 6);
        public static readonly PropertyFilterValue YearBuilt1991 = new PropertyFilterValue(97, "1991", "1991", "1991", 6);
        public static readonly PropertyFilterValue YearBuilt1992 = new PropertyFilterValue(98, "1992", "1992", "1992", 6);
        public static readonly PropertyFilterValue YearBuilt1993 = new PropertyFilterValue(99, "1993", "1993", "1993", 6);
        public static readonly PropertyFilterValue YearBuilt1994 = new PropertyFilterValue(100, "1994", "1994", "1994", 6);
        public static readonly PropertyFilterValue YearBuilt1995 = new PropertyFilterValue(101, "1995", "1995", "1995", 6);
        public static readonly PropertyFilterValue YearBuilt1996 = new PropertyFilterValue(102, "1996", "1996", "1996", 6);
        public static readonly PropertyFilterValue YearBuilt1997 = new PropertyFilterValue(103, "1997", "1997", "1997", 6);
        public static readonly PropertyFilterValue YearBuilt1998 = new PropertyFilterValue(104, "1998", "1998", "1998", 6);
        public static readonly PropertyFilterValue YearBuilt1999 = new PropertyFilterValue(105, "1999", "1999", "1999", 6);
        public static readonly PropertyFilterValue YearBuilt2000 = new PropertyFilterValue(106, "2000", "2000", "2000", 6);
        public static readonly PropertyFilterValue YearBuilt2001 = new PropertyFilterValue(107, "2001", "2001", "2001", 6);
        public static readonly PropertyFilterValue YearBuilt2002 = new PropertyFilterValue(108, "2002", "2002", "2002", 6);
        public static readonly PropertyFilterValue YearBuilt2003 = new PropertyFilterValue(109, "2003", "2003", "2003", 6);
        public static readonly PropertyFilterValue YearBuilt2004 = new PropertyFilterValue(110, "2004", "2004", "2004", 6);
        public static readonly PropertyFilterValue YearBuilt2005 = new PropertyFilterValue(111, "2005", "2005", "2005", 6);
        public static readonly PropertyFilterValue YearBuilt2006 = new PropertyFilterValue(112, "2006", "2006", "2006", 6);
        public static readonly PropertyFilterValue YearBuilt2007 = new PropertyFilterValue(113, "2007", "2007", "2007", 6);
        public static readonly PropertyFilterValue YearBuilt2008 = new PropertyFilterValue(114, "2008", "2008", "2008", 6);
        public static readonly PropertyFilterValue YearBuilt2009 = new PropertyFilterValue(115, "2009", "2009", "2009", 6);
        public static readonly PropertyFilterValue YearBuilt2010 = new PropertyFilterValue(116, "2010", "2010", "2010", 6);
        public static readonly PropertyFilterValue YearBuilt2011 = new PropertyFilterValue(117, "2011", "2011", "2011", 6);
        public static readonly PropertyFilterValue YearBuilt2012 = new PropertyFilterValue(118, "2012", "2012", "2012", 6);
        public static readonly PropertyFilterValue YearBuilt2013 = new PropertyFilterValue(119, "2013", "2013", "2013", 6);
        public static readonly PropertyFilterValue YearBuilt2014 = new PropertyFilterValue(120, "2014", "2014", "2014", 6);
        public static readonly PropertyFilterValue YearBuilt2015 = new PropertyFilterValue(121, "2015", "2015", "2015", 6);
        public static readonly PropertyFilterValue YearBuilt2016 = new PropertyFilterValue(122, "2016", "2016", "2016", 6);
        public static readonly PropertyFilterValue YearBuilt2017 = new PropertyFilterValue(123, "2017", "2017", "2017", 6);
        public static readonly PropertyFilterValue YearBuilt2018 = new PropertyFilterValue(124, "2018", "2018", "2018", 6);
        public static readonly PropertyFilterValue YearBuilt2019 = new PropertyFilterValue(125, "2019", "2019", "2019", 6);

        public static readonly PropertyFilterValue CloseDate2015_1 = new PropertyFilterValue(126, "CloseDate2015_1", "1/2015", "1/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_2 = new PropertyFilterValue(127, "CloseDate2015_2", "2/2015", "2/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_3 = new PropertyFilterValue(128, "CloseDate2015_3", "3/2015", "3/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_4 = new PropertyFilterValue(129, "CloseDate2015_4", "4/2015", "4/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_5 = new PropertyFilterValue(130, "CloseDate2015_5", "5/2015", "5/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_6 = new PropertyFilterValue(131, "CloseDate2015_6", "6/2015", "6/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_7 = new PropertyFilterValue(132, "CloseDate2015_7", "7/2015", "7/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_8 = new PropertyFilterValue(133, "CloseDate2015_8", "8/2015", "8/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_9 = new PropertyFilterValue(134, "CloseDate2015_9", "9/2015", "9/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_10 = new PropertyFilterValue(135, "CloseDate2015_10", "10/2015", "10/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_11 = new PropertyFilterValue(136, "CloseDate2015_11", "11/2015", "11/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2015_12 = new PropertyFilterValue(137, "CloseDate2015_12", "12/2015", "12/1/2015", 7);
        public static readonly PropertyFilterValue CloseDate2016_1 = new PropertyFilterValue(138, "CloseDate2016_1", "1/2016", "1/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_2 = new PropertyFilterValue(139, "CloseDate2016_2", "2/2016", "2/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_3 = new PropertyFilterValue(140, "CloseDate2016_3", "3/2016", "3/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_4 = new PropertyFilterValue(141, "CloseDate2016_4", "4/2016", "4/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_5 = new PropertyFilterValue(142, "CloseDate2016_5", "5/2016", "5/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_6 = new PropertyFilterValue(143, "CloseDate2016_6", "6/2016", "6/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_7 = new PropertyFilterValue(144, "CloseDate2016_7", "7/2016", "7/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_8 = new PropertyFilterValue(145, "CloseDate2016_8", "8/2016", "8/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_9 = new PropertyFilterValue(146, "CloseDate2016_9", "9/2016", "9/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_10 = new PropertyFilterValue(147, "CloseDate2016_10", "10/2016", "10/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_11 = new PropertyFilterValue(148, "CloseDate2016_11", "11/2016", "11/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2016_12 = new PropertyFilterValue(149, "CloseDate2016_12", "12/2016", "12/1/2016", 7);
        public static readonly PropertyFilterValue CloseDate2017_1 = new PropertyFilterValue(150, "CloseDate2017_1", "1/2017", "1/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_2 = new PropertyFilterValue(151, "CloseDate2017_2", "2/2017", "2/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_3 = new PropertyFilterValue(152, "CloseDate2017_3", "3/2017", "3/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_4 = new PropertyFilterValue(153, "CloseDate2017_4", "4/2017", "4/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_5 = new PropertyFilterValue(154, "CloseDate2017_5", "5/2017", "5/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_6 = new PropertyFilterValue(155, "CloseDate2017_6", "6/2017", "6/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_7 = new PropertyFilterValue(156, "CloseDate2017_7", "7/2017", "7/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_8 = new PropertyFilterValue(157, "CloseDate2017_8", "8/2017", "8/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_9 = new PropertyFilterValue(158, "CloseDate2017_9", "9/2017", "9/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_10 = new PropertyFilterValue(159, "CloseDate2017_10", "10/2017", "10/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_11 = new PropertyFilterValue(160, "CloseDate2017_11", "11/2017", "11/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2017_12 = new PropertyFilterValue(161, "CloseDate2017_12", "12/2017", "12/1/2017", 7);
        public static readonly PropertyFilterValue CloseDate2018_1 = new PropertyFilterValue(162, "CloseDate2018_1", "1/2018", "1/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_2 = new PropertyFilterValue(163, "CloseDate2018_2", "2/2018", "2/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_3 = new PropertyFilterValue(164, "CloseDate2018_3", "3/2018", "3/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_4 = new PropertyFilterValue(165, "CloseDate2018_4", "4/2018", "4/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_5 = new PropertyFilterValue(166, "CloseDate2018_5", "5/2018", "5/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_6 = new PropertyFilterValue(167, "CloseDate2018_6", "6/2018", "6/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_7 = new PropertyFilterValue(168, "CloseDate2018_7", "7/2018", "7/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_8 = new PropertyFilterValue(169, "CloseDate2018_8", "8/2018", "8/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_9 = new PropertyFilterValue(170, "CloseDate2018_9", "9/2018", "9/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_10 = new PropertyFilterValue(171, "CloseDate2018_10", "10/2018", "10/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_11 = new PropertyFilterValue(172, "CloseDate2018_11", "11/2018", "11/1/2018", 7);
        public static readonly PropertyFilterValue CloseDate2018_12 = new PropertyFilterValue(173, "CloseDate2018_12", "12/2018", "12/1/2018", 7);
    }
}

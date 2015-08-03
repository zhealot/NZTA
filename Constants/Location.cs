using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZTA_Contract_Generator.Util;

namespace NZTA_Contract_Generator.Constants
{
    static class Location
    {

         public static Dictionary<String, Address> data = new Dictionary<String, Address>
         {
             {"National Office", new Address {building = "Victoria Arcade", streetAddress = "50 Victoria Street", boxNumber = "Private Bag 6995", 
                 city = "Wellington", postcode = "6141", telephone = "64 4 894 5400", fax="64 4 894 6100"}},

             {"Whangarei", new Address {building = "Walton Plaza, 1st Floor", streetAddress = "4 Albert St Whangarei", boxNumber = "Private Bag 106602", 
                 city = "Auckland", postcode = "1143", telephone = "64 9 430 4355", fax="64 9 459 6944"}},
            
             {"Auckland", new Address {building = "Level 11, HSBC House", streetAddress = "1 Queen Street", boxNumber = "Private Bag 106602", 
                 city = "Auckland", postcode = "1143", telephone = "64 9 969 9800", fax="64 9 969 9813"}},
            
             {"Hamilton", new Address {building = "Level 1, Deloitte Building", streetAddress = "24 Bridge Street", boxNumber = "PO Box 973, Waikato Mail Centre", 
                 city = "Hamilton", postcode = "3240", telephone = "64 7 958 7220", fax="64 7 957 1437"}},
            
             {"Tauranga", new Address {building = "3rd Floor Harrington House", streetAddress = "32 Harington Street", boxNumber = "PO Box 13-055 Tauranga Central", 
                 city = "Tauranga", postcode = "3141", telephone = "07 927 6009", fax="07 578 2909"}},
            
             {"Napier", new Address {building = "Level 2, Dunvegan House", streetAddress = "215 Hastings Street", boxNumber = "PO Box 740", 
                 city = "Napier", postcode = "4140", telephone = "64 6 974 5520", fax="64 6 974 5529"}},
            
             {"Palmerston North", new Address {building = "Level 3", streetAddress = "43 Ashley Street", boxNumber = "Private Bag 11777", 
                 city = "Palmerston North", postcode = "4442", telephone = "64 6 953 6396", fax="64 6 953 6203"}},
            
             {"Wellington", new Address {building = "Level 9, PSIS House", streetAddress = "20 Ballance Street", boxNumber = "PO Box 5084, Lambton Quay", 
                 city = "Wellington", postcode = "6145", telephone = "64 4 894 5200 ", fax="64 4 894 3305"}},
            
             {"Blenheim", new Address {building = "Marlborough Roads, Level 1, The Forum", streetAddress = "Unit 2.4, Market Street", boxNumber = "PO Box 1031", 
                 city = "Blenheim", postcode = "7240", telephone = "64 3 520 8330", fax="64 3 577 5309 "}},
            
             {"Christchurch", new Address {building = "Airport Business Park, Unit C", streetAddress = "92 Russley Road", boxNumber = "PO Box 1479, Russley", 
                 city = "Christchurch", postcode = "8140", telephone = "64 3 964 2800", fax="64 3 964 2793"}},
            
             {"Dunedin", new Address {building = "Level 2, AA Centre", streetAddress = "450 Moray Place", boxNumber = "PO Box 5245, Moray Place", 
                 city = "Dunedin", postcode = "9058", telephone = "64 3 951 3009", fax="64 3 951 3013"}}
      
         };  



        /*public static Dictionary<String, String> data = new Dictionary<String, String>
         {
             {"National Office", "Victoria Arcade"
                + Environment.NewLine + "50 Victoria Street"
                + Environment.NewLine + "Private Bag 6995"
                + Environment.NewLine + "Wellington 6141"
                + Environment.NewLine + "New Zealand"
                + Environment.NewLine + "Telephone: 64 4 894 5400"
                + Environment.NewLine + "Fax: 64 4 894 6100"},

             {"Whangarei", "Walton Plaza, 1st Floor"
                + Environment.NewLine + "4 Albert St,"
                + Environment.NewLine + "Whangarei"
                + Environment.NewLine
                + Environment.NewLine + "Private Bag 106602," 
                + Environment.NewLine + "Auckland 1143"
                + Environment.NewLine + "New Zealand"
                + Environment.NewLine + "Telephone: 64 9 430 4355"
                + Environment.NewLine + "Fax: 64 9 459 6944"
             },
            
             {"Auckland", "Level 11, HSBC House"
                + Environment.NewLine + "1 Queen Street"
                + Environment.NewLine + "Private Bag 106602"
                + Environment.NewLine + "Auckland 1143"
                + Environment.NewLine + "New Zealand"
                + Environment.NewLine + "Telephone: 64 9 969 9800"
                + Environment.NewLine + "Fax: 64 9 969 9813"},
            
             {"Hamilton", "Level 1, Deloitte Building"
                + Environment.NewLine + "24 Bridge Street"
                + Environment.NewLine + "PO Box 973, Waikato Mail Centre"
                + Environment.NewLine + "Hamilton 3240"
                + Environment.NewLine + "New Zealand"
                + Environment.NewLine + "Telephone: 64 7 958 7220"
                + Environment.NewLine + "Fax: 64 7 957 1437"},
            
             {"Tauranga", "3rd Floor"
                + Environment.NewLine + "Harrington House"
                + Environment.NewLine + "32 Harington Street"
                + Environment.NewLine + "Tauranga 3110"
                + Environment.NewLine 
                + Environment.NewLine + "PO Box 13-055"
                + Environment.NewLine + "Tauranga Central"
                + Environment.NewLine + "Tauranga 3141"
                + Environment.NewLine + "Telephone: 07 927 6009"
                + Environment.NewLine + "Fax: 07 578 2909"},
            
             {"Napier", "Level 2, Dunvegan House"
                + Environment.NewLine + "215 Hastings Street"
                + Environment.NewLine + "PO Box 740"
                + Environment.NewLine + "Napier 4140"
                + Environment.NewLine + "New Zealand"
                + Environment.NewLine + "Telephone: 64 6 974 5520"
                + Environment.NewLine + "Fax: 64 6 974 5529"},
            
             {"Palmerston North", "Level 3, 43 Ashley Street"
                + Environment.NewLine + "Private Bag 11777"
                + Environment.NewLine + "Palmerston North 4442"
                + Environment.NewLine +"New Zealand"
                + Environment.NewLine + "Telephone: 64 6 953 6396"
                + Environment.NewLine + "Fax: 64 6 953 6203"},
            
             {"Wellington", "Level 9, PSIS House"
                + Environment.NewLine + "20 Ballance Street"
                + Environment.NewLine + "PO Box 5084, Lambton Quay"
                + Environment.NewLine + "Wellington 6145"
                + Environment.NewLine + "New Zealand"
                + Environment.NewLine + "Telephone: 64 4 894 5200 "
                + Environment.NewLine + "Fax: 64 4 894 3305"},
            
             {"Blenheim", "Marlborough Roads"
                + Environment.NewLine + "Level 1, The Forum"
                + Environment.NewLine + "Unit 2.4, Market Street"
                + Environment.NewLine + "PO Box 1031"
                + Environment.NewLine + "Blenheim 7240"
                + Environment.NewLine + "New Zealand"
                + Environment.NewLine + "Telephone: 64 3 520 8330"
                + Environment.NewLine + "Fax: 64 3 577 5309 "},
            
             {"Christchurch", "Airport Business Park, Unit C"
                + Environment.NewLine +"92 Russley Road"
                + Environment.NewLine + "PO Box 1479"
                + Environment.NewLine + "Russley"
                + Environment.NewLine + "Christchurch 8140"
                + Environment.NewLine + "New Zealand"
                + Environment.NewLine + "Telephone: 64 3 964 2800"
                + Environment.NewLine + "Fax: 64 3 964 2793"},
            
             {"Dunedin", "Level 2, AA Centre"
                + Environment.NewLine + "450 Moray Place"
                + Environment.NewLine + "PO Box 5245, Moray Place"
                + Environment.NewLine + "Dunedin 9058"
                + Environment.NewLine + "New Zealand"
                + Environment.NewLine + "Telephone: 64 3 951 3009"
                + Environment.NewLine + "Fax: 64 3 951 3013"}
      
         };*/

    
    }
}

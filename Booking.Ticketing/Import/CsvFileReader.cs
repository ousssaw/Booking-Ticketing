using Booking.Ticketing.Dto;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Booking.Ticketing.Import
{
    public class CsvFileReader
    {
        private readonly IOptions<CsvFileReaderConfiguration> _csvFileReaderConfiguration;

        public CsvFileReader(IOptions<CsvFileReaderConfiguration> csvFileReaderConfiguration)
        {
            _csvFileReaderConfiguration = csvFileReaderConfiguration;
        }

        public IEnumerable<TicketLine> ReadDocument(string fileName)
        {
            //git
            var ticketingLines = new List<TicketLine>();
            try
            {
                foreach (var csvLine in File.ReadAllLines(fileName).Skip(1))
                {
                    try
                    {
                        var line = this.GetFromCsvLine(csvLine);
                        ticketingLines.Add(line);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return ticketingLines;
        }

        decimal GetDecimalValue(string value)
        {
            return Convert.ToDecimal(string.IsNullOrEmpty(value) ? "0" : value.Replace(".", ","));
        }
        int GetIntValue(string value)
        {
            return Int32.Parse(string.IsNullOrEmpty(value) ? "0" : value);
        }

        bool GetBoolValue(string value)
        {
            return value == "1" ? true : false;
        }
        DateTime? GetDateValue(string value)
        {
            try
            {
                return DateTime.Parse(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private TicketLine GetFromCsvLine(string csvLine)
        {
            string[] values = csvLine.Split(new char[] { ';' });
            return new TicketLine
            {
                Aw_deep_link = values[0],
                Product_name = values[1],
                Aw_product_id = values[2],
                Merchant_product_id = values[3],
                Merchant_image_url = values[4],
                Description = values[5],
                Merchant_category = values[6],
                Search_price = values[7],
                Merchant_name = values[8],
                Merchant_id = values[9],
                Category_name = values[10],
                Category_id = values[11],
                Aw_image_url = values[12],
                Currency = values[13],
                Store_price = values[14],
                Delivery_cost = values[15],
                Merchant_deep_link = values[16],
                Language = values[17],
                Last_updated = values[18],
                Display_price = values[19],
                Data_feed_id = values[20],
                Brand_name = values[21],
                Brand_id = values[22],
                Colour = values[23],
                Product_short_description = values[24],
                Specifications = values[25],
                Condition = values[26],
                Product_model = values[27],
                Model_number = values[28],
                Dimensions = values[29],
                Keywords = values[30],
                Promotional_text = values[31],
                Product_type = values[32],
                Commission_group = values[33],
                Merchant_product_category_path = values[34],
                Merchant_product_second_category = values[35],
                Merchant_product_third_category = values[36],
                Rrp_price = values[37],
                Saving = values[38],
                Savings_percent = values[39],
                Base_price = values[40],
                Base_price_amount = values[41],
                Base_price_text = values[42],
                Product_price_old = values[43],
                Delivery_restrictions = values[44],
                Delivery_weight = values[45],
                Warranty = values[46],
                Terms_of_contract = values[47],
                Delivery_time = values[48],
                In_stock = values[49],
                Stock_quantity = values[50],
                Valid_from = values[51],
                Valid_to = values[52],
                Is_for_sale = values[53],
                Web_offer = values[54],
                Pre_order = values[55],
                Stock_status = values[56],
                Size_stock_status = values[57],
                Size_stock_amount = values[58],
                Merchant_thumb_url = values[59],
                Large_image = values[60],
                Alternate_image = values[61],
                Aw_thumb_url = values[62],
                Alternate_image_two = values[63],
                Alternate_image_three = values[64],
                Alternate_image_four = values[65],
                Reviews = values[66],
                Average_rating = values[67],
                Rating = values[68],
                Number_available = values[69],
                Custom_1 = values[70],
                Custom_2 = values[71],
                Custom_3 = values[72],
                Custom_4 = values[73],
                Custom_5 = values[74],
                Custom_6 = values[75],
                Custom_7 = values[76],
                Custom_8 = values[77],
                Custom_9 = values[78],
                Ean = values[79],
                Isbn = values[80],
                Upc = values[81],
                Mpn = values[82],
                Parent_product_id = values[83],
                Product_GTIN = values[84],
                Basket_link = values[85],
                Tickets_primary_artist = values[86],
                Tickets_second_artist = values[87],
                Tickets_event_date = values[88],
                Tickets_event_name = values[89],
                Tickets_venue_name = values[90],
                Tickets_venue_address = values[91],
                Tickets_available_from = values[92],
                Tickets_genre = values[93],
                Tickets_min_price = values[94],
                Tickets_max_price = values[95],
                Tickets_longitude = values[96],
                Tickets_latitude = values[97],
                Tickets_event_location_address = values[98],
                Tickets_event_location_zipcode = values[99],
                Tickets_event_location_city = values[100],
                Tickets_event_location_region = values[101],
                Tickets_event_location_country = values[102],
                Tickets_event_location_coordinates = values[103],
                Tickets_event_duration = values[104]
            };
        }
    }
}

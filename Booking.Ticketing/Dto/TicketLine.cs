﻿using Nest;

namespace Booking.Ticketing.Dto
{
    [ElasticsearchType(IdProperty = nameof(Aw_product_id))]
    public class TicketLine : IIndexingRequest
    {
        [Keyword(Name = "aw_deep_link")]
        public string Aw_deep_link { get; set; }

        [Keyword(Name = "product_name")]
        public string Product_name { get; set; }

        [Keyword(Name = "aw_product_id")]
        public string Aw_product_id { get; set; }

        [Keyword(Name = "merchant_product_id")]
        public string Merchant_product_id { get; set; }

        [Keyword(Name = "merchant_image_url")]
        public string Merchant_image_url { get; set; }

        [Keyword(Name = "description")]
        public string Description { get; set; }

        [Keyword(Name = "merchant_category")]
        public string Merchant_category { get; set; }

        [Keyword(Name = "search_price")]
        public string Search_price { get; set; }

        [Keyword(Name = "merchant_name")]
        public string Merchant_name { get; set; }

        [Keyword(Name = "merchant_id")]
        public string Merchant_id { get; set; }

        [Keyword(Name = "category_name")]
        public string Category_name { get; set; }

        [Keyword(Name = "category_id")]
        public string Category_id { get; set; }

        [Keyword(Name = "ww_image_url")]
        public string Aw_image_url { get; set; }

        [Keyword(Name = "currency")]
        public string Currency { get; set; }

        [Keyword(Name = "store_price")]
        public string Store_price { get; set; }

        [Keyword(Name = "delivery_cost")]
        public string Delivery_cost { get; set; }

        [Keyword(Name = "merchant_deep_link")]
        public string Merchant_deep_link { get; set; }

        [Keyword(Name = "language")]
        public string Language { get; set; }

        [Keyword(Name = "last_updated")]
        public string Last_updated { get; set; }

        [Keyword(Name = "display_price")]
        public string Display_price { get; set; }

        [Keyword(Name = "data_feed_id")]
        public string Data_feed_id { get; set; }

        [Keyword(Name = "brand_name")]
        public string Brand_name { get; set; }

        [Keyword(Name = "brand_id")]
        public string Brand_id { get; set; }

        [Keyword(Name = "colour")]
        public string Colour { get; set; }

        [Keyword(Name = "product_short_description")]
        public string Product_short_description { get; set; }

        [Keyword(Name = "specifications")]
        public string Specifications { get; set; }

        [Keyword(Name = "condition")]
        public string Condition { get; set; }

        [Keyword(Name = "product_model")]
        public string Product_model { get; set; }

        [Keyword(Name = "model_number")]
        public string Model_number { get; set; }

        [Keyword(Name = "dimensions")]
        public string Dimensions { get; set; }

        [Keyword(Name = "keywords")]
        public string Keywords { get; set; }

        [Keyword(Name = "promotional_text")]
        public string Promotional_text { get; set; }

        [Keyword(Name = "product_type")]
        public string Product_type { get; set; }

        [Keyword(Name = "commission_group")]
        public string Commission_group { get; set; }

        [Keyword(Name = "merchant_product_category_path")]
        public string Merchant_product_category_path { get; set; }

        [Keyword(Name = "merchant_product_second_category")]
        public string Merchant_product_second_category { get; set; }

        [Keyword(Name = "merchant_product_third_category")]
        public string Merchant_product_third_category { get; set; }

        [Keyword(Name = "rrp_price")]
        public string Rrp_price { get; set; }

        [Keyword(Name = "saving")]
        public string Saving { get; set; }

        [Keyword(Name = "savings_percent")]
        public string Savings_percent { get; set; }

        [Keyword(Name = "base_price")]
        public string Base_price { get; set; }

        [Keyword(Name = "base_price_amount")]
        public string Base_price_amount { get; set; }

        [Keyword(Name = "base_price_text")]
        public string Base_price_text { get; set; }

        [Keyword(Name = "product_price_old")]
        public string Product_price_old { get; set; }

        [Keyword(Name = "delivery_restrictions")]
        public string Delivery_restrictions { get; set; }

        [Keyword(Name = "delivery_weight")]
        public string Delivery_weight { get; set; }

        [Keyword(Name = "warranty")]
        public string Warranty { get; set; }

        [Keyword(Name = "terms_of_contract")]
        public string Terms_of_contract { get; set; }

        [Keyword(Name = "delivery_time")]
        public string Delivery_time { get; set; }

        [Keyword(Name = "in_stock")]
        public string In_stock { get; set; }

        [Keyword(Name = "stock_quantity")]
        public string Stock_quantity { get; set; }

        [Keyword(Name = "valid_from")]
        public string Valid_from { get; set; }

        [Keyword(Name = "valid_to")]
        public string Valid_to { get; set; }

        [Keyword(Name = "ss_for_sale")]
        public string Is_for_sale { get; set; }

        [Keyword(Name = "web_offer")]
        public string Web_offer { get; set; }

        [Keyword(Name = "pre_order")]
        public string Pre_order { get; set; }

        [Keyword(Name = "stock_status")]
        public string Stock_status { get; set; }

        [Keyword(Name = "size_stock_status")]
        public string Size_stock_status { get; set; }

        [Keyword(Name = "size_stock_amount")]
        public string Size_stock_amount { get; set; }

        [Keyword(Name = "merchant_thumb_url")]
        public string Merchant_thumb_url { get; set; }

        [Keyword(Name = "large_image")]
        public string Large_image { get; set; }

        [Keyword(Name = "alternate_image")]
        public string Alternate_image { get; set; }

        [Keyword(Name = "aw_thumb_url")]
        public string Aw_thumb_url { get; set; }

        [Keyword(Name = "alternate_image_two")]
        public string Alternate_image_two { get; set; }

        [Keyword(Name = "alternate_image_three")]
        public string Alternate_image_three { get; set; }

        [Keyword(Name = "alternate_image_four")]
        public string Alternate_image_four { get; set; }

        [Keyword(Name = "reviews")]
        public string Reviews { get; set; }

        [Keyword(Name = "average_rating")]
        public string Average_rating { get; set; }

        [Keyword(Name = "rating")]
        public string Rating { get; set; }

        [Keyword(Name = "number_available")]
        public string Number_available { get; set; }

        [Keyword(Name = "custom_1")]
        public string Custom_1 { get; set; }

        [Keyword(Name = "custom_2")]
        public string Custom_2 { get; set; }

        [Keyword(Name = "custom_3")]
        public string Custom_3 { get; set; }

        [Keyword(Name = "custom_4")]
        public string Custom_4 { get; set; }

        [Keyword(Name = "custom_5")]
        public string Custom_5 { get; set; }

        [Keyword(Name = "custom_6")]
        public string Custom_6 { get; set; }

        [Keyword(Name = "custom_7")]
        public string Custom_7 { get; set; }

        [Keyword(Name = "custom_8")]
        public string Custom_8 { get; set; }

        [Keyword(Name = "custom_9")]
        public string Custom_9 { get; set; }

        [Keyword(Name = "ean")]
        public string Ean { get; set; }

        [Keyword(Name = "isbn")]
        public string Isbn { get; set; }

        [Keyword(Name = "upc")]
        public string Upc { get; set; }

        [Keyword(Name = "mpn")]
        public string Mpn { get; set; }

        [Keyword(Name = "parent_product_id")]
        public string Parent_product_id { get; set; }

        [Keyword(Name = "product_GTIN")]
        public string Product_GTIN { get; set; }

        [Keyword(Name = "basket_link")]
        public string Basket_link { get; set; }

        [Keyword(Name = "tickets_primary_artist")]
        public string Tickets_primary_artist { get; set; }

        [Keyword(Name = "tickets_second_artist")]
        public string Tickets_second_artist { get; set; }

        [Keyword(Name = "tickets_event_date")]
        public string Tickets_event_date { get; set; }

        [Keyword(Name = "tickets_event_name")]
        public string Tickets_event_name { get; set; }

        [Keyword(Name = "tickets_venue_name")]
        public string Tickets_venue_name { get; set; }

        [Keyword(Name = "tickets_venue_address")]
        public string Tickets_venue_address { get; set; }

        [Keyword(Name = "tickets_available_from")]
        public string Tickets_available_from { get; set; }

        [Keyword(Name = "tickets_genre")]
        public string Tickets_genre { get; set; }

        [Keyword(Name = "tickets_min_price")]
        public string Tickets_min_price { get; set; }

        [Keyword(Name = "tickets_max_price")]
        public string Tickets_max_price { get; set; }

        [Keyword(Name = "tickets_longitude")]
        public string Tickets_longitude { get; set; }

        [Keyword(Name = "tickets_latitude")]
        public string Tickets_latitude { get; set; }

        [Keyword(Name = "tickets_event_location_address")]
        public string Tickets_event_location_address { get; set; }

        [Keyword(Name = "tickets_event_location_zipcode")]
        public string Tickets_event_location_zipcode { get; set; }

        [Keyword(Name = "tickets_event_location_city")]
        public string Tickets_event_location_city { get; set; }

        [Keyword(Name = "tickets_event_location_region")]
        public string Tickets_event_location_region { get; set; }

        [Keyword(Name = "tickets_event_location_country")]
        public string Tickets_event_location_country { get; set; }

        [Keyword(Name = "tickets_event_location_coordinates")]
        public string Tickets_event_location_coordinates { get; set; }

        [Keyword(Name = "tickets_event_duration")]
        public string Tickets_event_duration { get; set; }


        public string IndexKey => $"{Product_name}_{Brand_name}";
    }
}

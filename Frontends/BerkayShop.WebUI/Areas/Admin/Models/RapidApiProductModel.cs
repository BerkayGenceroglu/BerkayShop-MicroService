namespace BerkayShop.WebUI.Areas.Admin.Models
{
    public class RapidApiProductModel
    {

        public class Rootobject
        {
            public string status { get; set; }
            public string request_id { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public Product[] products { get; set; }
            public object[] sponsored_products { get; set; }
            public Filter[] filters { get; set; }
        }

        public class Product
        {
            public string product_id { get; set; }
            public string product_title { get; set; }
            public string product_description { get; set; }
            public string[] product_photos { get; set; }
            public Product_Videos[] product_videos { get; set; }
            public Product_Attributes product_attributes { get; set; }
            public float? product_rating { get; set; }
            public string product_page_url { get; set; }
            public int? product_num_reviews { get; set; }
            public int product_num_offers { get; set; }
            public object typical_price_range { get; set; }
            public Current_Product_Variant_Properties current_product_variant_properties { get; set; }
            public Product_Variants product_variants { get; set; }
            public Reviews_Insights reviews_insights { get; set; }
            public Offer offer { get; set; }
        }

        public class Product_Attributes
        {
        }

        public class Current_Product_Variant_Properties
        {
            public string Size { get; set; }
            public string Color { get; set; }
        }

        public class Product_Variants
        {
            public Size[] Size { get; set; }
            public Color[] Color { get; set; }
        }

        public class Size
        {
            public string name { get; set; }
            public string product_id { get; set; }
        }

        public class Color
        {
            public string name { get; set; }
            public string thumbnail { get; set; }
            public string product_id { get; set; }
        }

        public class Reviews_Insights
        {
        }

        public class Offer
        {
            public string offer_id { get; set; }
            public object offer_title { get; set; }
            public string offer_page_url { get; set; }
            public string price { get; set; }
            public string original_price { get; set; }
            public bool on_sale { get; set; }
            public string shipping { get; set; }
            public string product_condition { get; set; }
            public string store_name { get; set; }
            public string store_rating { get; set; }
            public int store_review_count { get; set; }
            public string store_reviews_page_url { get; set; }
            public string store_favicon { get; set; }
            public object payment_methods { get; set; }
            public string percent_off { get; set; }
        }

        public class Product_Videos
        {
            public string title { get; set; }
            public string url { get; set; }
            public string source { get; set; }
            public string publisher { get; set; }
            public string thumbnail { get; set; }
            public string preview_url { get; set; }
            public int duration_ms { get; set; }
        }

        public class Filter
        {
            public string title { get; set; }
            public bool multivalue { get; set; }
            public Value[] values { get; set; }
        }

        public class Value
        {
            public string title { get; set; }
            public string q { get; set; }
            public string shoprs { get; set; }
        }

    }
}

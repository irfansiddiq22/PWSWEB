using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Account
{
    public class QuoteRequestSQL
    {
        public DataTable Supplier { get; set; }
        public DataTable QuoteItems { get; set; }
        public DataTable PastQuotes { get; set; }
        public DataTable PastQuoteItems { get; set; }
        public bool Status { get; set; }
        public int IPOID { get; set; }
        public QuoteRequestSQL()
        {
            Supplier = new DataTable();
            QuoteItems = new DataTable();
            PastQuotes = new DataTable();
            PastQuoteItems = new DataTable();
        }
    }
    public class QuoteRequest: NewQuote
    {
        public bool Status { get; set; }
        public int IPO { get; set; }
        public List<Quote> PastQuotes { get; set; }
        public List<QuoteItem> PastQuoteItems { get; set; }
    }
    public class NewQuote
    {
        public Supplier Supplier { get; set; }
        public List<QuoteItem> QuoteItems { get; set; }
    }
    public class Quote
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        public string FileName { get; set; }
        public int InternalPurchaseID { get; set; }
        public string Remarks { get; set; }
        public DateTime RecordDate { get; set; }
        public List<QuoteItem> Items { get; set; }
    }
  public  class QuoteItem
    {public int QuoteID { get; set; }
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string PartNumber { get; set; }
        public string Notes { get; set; }
        public float Price { get; set; }
    }
}

using PipewellserviceDB.Equipment;
using PipewellserviceModels.Equipment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Equipment
{
   public class EquipmentQuoteJson
    {
        private EquipmentQuoteService service = new EquipmentQuoteService();
        public async Task<int> SaveQuote(EquipmentQuote quote)
        {
            return await service.SaveQuote(quote);
        }
        public async Task<EquipmentQuoteListView> List(EquipmentQuoteParam item)
        {
            var Data = await service.List(item);
            EquipmentQuoteListView model = new EquipmentQuoteListView();
            model.List=await JsonHelper.Convert<List<EquipmentQuoteList>, DataTable>(Data.List);
            model.ID = Data.ID;
            return model;
        }
        public async Task<EquipmentQuoteList> QuoteDetail(int ID)
        {
            var Data = await service.QuoteDetail(ID);
            EquipmentQuoteList equipmentQuote = new EquipmentQuoteList();
            equipmentQuote = (await JsonHelper.Convert<List<EquipmentQuoteList>, DataTable>(Data.Detail)).FirstOrDefault();
            equipmentQuote.Items = await JsonHelper.Convert<List<EquipmentQuoteItem>, DataTable>(Data.Items);
            return equipmentQuote;
        }
    }
}

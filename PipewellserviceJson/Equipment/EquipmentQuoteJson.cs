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
        public async Task<EquipmentQuoteList> QuoteDetailByID(int QuoteID)
        {
            var Data = await service.QuoteDetailByID(QuoteID);
            EquipmentQuoteList equipmentQuote = new EquipmentQuoteList();
            equipmentQuote = (await JsonHelper.Convert<List<EquipmentQuoteList>, DataTable>(Data.Detail)).FirstOrDefault();
            equipmentQuote.Items = await JsonHelper.Convert<List<EquipmentQuoteItem>, DataTable>(Data.Items);
            return equipmentQuote;
        }
        public async Task<List<string>> QuoteIDList(string QuoteID)
        {
            var Data = await service.QuoteIDList(QuoteID);
            var ID= await JsonHelper.Convert<List<QuoteIDList>, DataTable>(Data);
        return    ID.Select(x => x.QuoteID).ToList();
        }

        public async Task<int> SaveCollectQuote(EquipmentQuoteCollection quote)
        {
            return await service.SaveCollectQuote(quote);
        }

        public async Task<List<EquipmentQuoteCollectionList>> QuoteCollectionList(EquipmentQuoteParam param)
        {
           var data= await service.QuoteCollectionList(param);
           return await JsonHelper.Convert<List<EquipmentQuoteCollectionList>, DataTable>(data);
        }

        public async Task<EquipmentQuoteCollectionList> QuoteCollectionDetail(int ID)
        {
            var Data = await service.QuoteCollectionDetail(ID);
            EquipmentQuoteCollectionList equipmentQuote = new EquipmentQuoteCollectionList();
            equipmentQuote = (await JsonHelper.Convert<List<EquipmentQuoteCollectionList>, DataTable>(Data.Detail)).FirstOrDefault();
            equipmentQuote.Items = await JsonHelper.Convert<List<EquipQuoteCollectionItems>, DataTable>(Data.Items);
            return equipmentQuote;
        }

    }
}

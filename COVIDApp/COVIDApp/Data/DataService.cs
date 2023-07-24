using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CovidApp.Data
{
    public class DataService
    {
        public IList<CovidData> Data { get; set; } = new List<CovidData>();

        public async Task<IList<CovidData>> GetCovidData()
        {
            if(Data.Count != 0) return Data;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.covidtracking.com/v1/states/daily.json");

            string result = "";
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            var jArray = JArray.Parse(result);

            foreach (var item in jArray)
            {
                CovidData dataItem = new CovidData();
                dataItem.date = DateTime.ParseExact(item["date"].ToString(), "yyyyMMdd", null);
                dataItem.state = (string)item["state"];
                dataItem.total = item["total"].Type != JTokenType.Null ? (int)item["total"] : null;
                dataItem.positive = item["positive"].Type != JTokenType.Null ? (int)item["positive"] : null;
                dataItem.negative = item["negative"].Type != JTokenType.Null ? (int)item["negative"] : null;
                dataItem.hospitalized = item["hospitalized"].Type != JTokenType.Null ? (int)item["hospitalized"] : null;
                Data.Add(dataItem);
            }

            return Data;
        }
    }
}

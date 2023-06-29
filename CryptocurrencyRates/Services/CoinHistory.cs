using LiveChartsCore.Defaults;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyRates.Services
{
    public class CoinHistory
    {
        //public ObservableCollection<decimal> priceUSDList;
        //public ObservableCollection<DateTime> timeList;
        public ObservableCollection<DateTimePoint> dateTimePoint;
        public class CoinDataHistory
        {
            public string priceUsd { get; set; }
            public object time { get; set; }
            public DateTime date { get; set; }
        }

        public class CoinHistoryRoot
        {
            public List<CoinDataHistory> data { get; set; }
            public long timestamp { get; set; }
        }


        public CoinHistory(string coin, string interval, string start, string end)
        {
            CoinHistoryRoot coinHistoryRoot = new CoinHistoryRoot();
            using (var webClient = new WebClient())
            {
                string link = "https://api.coincap.io/v2/assets/" + coin + "/history?interval=" + interval+ "&start="+start+"&end="+end;
                var jsonString = webClient.DownloadString(link);
                var valueSet = JsonConvert.DeserializeObject<CoinHistoryRoot>(jsonString);
                coinHistoryRoot = valueSet;
            }

            //priceUSDList = new ObservableCollection<decimal>();
            //timeList = new ObservableCollection<DateTime>();
            dateTimePoint = new ObservableCollection<DateTimePoint>();
            foreach (CoinDataHistory x in coinHistoryRoot.data)
            {
                int ToRemove = 11;
                if (coin == "shiba-inu")
                {
                    ToRemove = 6;
                }
                //priceUSDList.Add(Convert.ToDecimal(x.priceUsd, CultureInfo.InvariantCulture));
                //timeList.Add(x.date);
                dateTimePoint.Add(new DateTimePoint() { DateTime = x.date, Value = Convert.ToDouble(x.priceUsd.Remove(x.priceUsd.Length- ToRemove), CultureInfo.InvariantCulture) });
            }
        }
    }
}

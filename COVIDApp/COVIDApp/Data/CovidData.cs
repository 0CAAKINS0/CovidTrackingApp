namespace CovidApp.Data
{
    public class CovidData
    {
        public DateTime? date { get; set; }
        public string? state { get; set; }
        public int? total { get; set; }
        public int? positive { get; set; }
        public int? negative { get; set; }
        public int? hospitalized { get; set; }

        public CovidData(DateTime date, string state, int total, int positive, int negative, int hospitalized) {
            this.date = date;
            this.state = state;
            this.total = total;
            this.positive = positive;
            this.negative = negative;
            this.hospitalized = hospitalized;
        }
        public CovidData() { }

    }
}

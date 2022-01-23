
namespace @Chronometer
{
    using System.Diagnostics;


    public class Chronometer : IChronometer
    {
        private Stopwatch stopWatch;
        private List<string> laps;

        public Chronometer()
        {
            this.stopWatch = new Stopwatch();
            this.laps = new List<string>();
        }



        public string GetTime => this.stopWatch.Elapsed.ToString(@"mm\:ss\.ffff");


        public List<string> Laps => this.laps;


        public string Lap()
        {
            var result = GetTime;
            this.laps.Add(result);

            return result;
        }

        public void Reset()
        {
            this.stopWatch.Reset();
            this.laps.Clear();
        }

        public void Start() => this.stopWatch.Start();

        public void Stop() => this.stopWatch.Stop();

    }
}

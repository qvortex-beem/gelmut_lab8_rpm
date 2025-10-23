using System.Drawing;

namespace gelmut_lab8_rpm
{
    class Program
    {
        static void Main(string[] args)
        {
            AirBalloon obj = new AirBalloon();
            obj.molar = 0.032;
            obj.volume = 50;
            obj.mass = 34;
            ITarget target = new Adapter(obj);
            Console.WriteLine(target.GetData()); 
            target.ModifMass(6); 
            Console.WriteLine(target.GetData());
            Console.WriteLine($"Изменение давления при заданной T0 и изменнении температуры dT: {target.CalculateDp(15, 10)}");


        }
    }

    class AirBalloon
    {
        public double volume { get; set; }
        public double mass  {get; set; }
        public double molar  {get; set; }

        public double GetPressure(int t) { return (AmountOfMatter() * 8.314 * t) / volume; }
        public double AmountOfMatter() { return mass / molar; }
        public string ToString() { return $"{volume} {mass} {molar}"; }
    }

    interface ITarget
    {
        double CalculateDp(int t0, int dt);
        void ModifMass(double dm);
        string GetData();
    }

    class Adapter : AirBalloon, ITarget
    {
        private AirBalloon obj { get; set; }
        public Adapter(AirBalloon obj)
        {
            this.obj = obj;
        }
        public double CalculateDp(int T0, int dT)
        {
            return ((obj.AmountOfMatter() * 8.314 * (T0 + dT) / obj.volume) - obj.GetPressure(T0));
        }
        public void ModifMass(double dm)
        {
            obj.mass += dm;
        }
        public string GetData()
        {
            return obj.ToString();
        }
    }
}
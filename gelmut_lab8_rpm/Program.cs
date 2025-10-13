namespace gelmut_lab8_rpm
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class AirBalloon
    {
        double volume;
        double mass;
        double molar;

        double GetPressure(int t) { return 0.0; }
        double AmountOfMatter() { return 0.0; }
        string ToString() { return ""; }
    }

    interface ITarget
    {
        void CalculateDp(int t0, int dt);
        void ModifMass(double dm);
        void GetData();
    }

    class Adapter : AirBalloon, ITarget 
    {     

    }
}
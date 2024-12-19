using Microsoft.CodeAnalysis;
using System.Reflection.Metadata;
using System.Transactions;

namespace SajatOldalProba.Models
{
    public class Motorok
    {
        public double Pn_max { get; set; }
        public double n_pn_max { get; set; }
        public double M_max { get; set; }
        public double n_M_max { get; set; }
        public int Weight { get; set; }
        public int Max_Weight { get; set; }
        public List<double> Transmissions { get; set; }       
        public double Gear_ratio { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Hight { get; set; }
        public int Wheelbase { get; set; }
        public int[]? Gauge { get; set; }
        public string? Tire { get; set; }
        public double Drag_coefficient { get; set; }
        public double Rolling_Resistance_Factor { get; set; }
        public double Transmission_efficiency { get; set; }
        public double Reduction_constant_of_rotating_masses { get; set; }
        public double Slope_of_rise { get; set; }
        public double Adhesion_factor { get; set; }
        public double Creep_factor { get; set; }
        public Motorok()
        {
            Transmissions = new List<double>();
            Speed_of_the_Wheels = new List<double>();
            Force_of_the_Wheels = new List<double>();
            AirResistances = new List<double>();    
        }
        public double Wheel_radius { get; set; }

        public void Calculate_Wheel_radius()
        {
            
            string[] tire = Tire.Split(' '); 
            string[] per = tire[0].Split('/');

            double[] tire_data = new double[]
            {
                float.Parse(per[0]), 
                float.Parse(per[1]), 
                float.Parse(tire[2]) 
            };
            Wheel_radius = (((tire_data[2]* 25.4)/2) + tire_data[0] * tire_data[1] / 100) * Creep_factor;
        }
        public double M_P_Max { get; set; }
        public void Calculate_M_P_Max()
        {
            M_P_Max = (Pn_max*1000 * 60) / (2 * Math.PI * n_pn_max);
        }
        public double P_M_Max { get; set; }
        public double Calculate_ford_to_Radsec(double ford)
        {
            return (ford  *2* Math.PI) / 60;
        }
        public void Calculate_P_M_Max()
        {
            P_M_Max = M_max * Calculate_ford_to_Radsec(n_pn_max)/1000;
        }
        public List<double> Speed_of_the_Wheels { get; set; }
        public double MeterminuteToKmhour(double metersec)
        {
            return metersec / 1000 / 1000 * 60;
        }
        public double Calculate_Speed_of_the_wheel(double ford, double transmission)
        {
            return (Wheel_radius*2*Math.PI*ford)/(transmission*Gear_ratio);
        }
        public void Calculate_Speed_of_the_wheels(double ford)
        {
            for (int i = 0; i < Transmissions.Count; i++) 
            {
                var n = Calculate_Speed_of_the_wheel(ford, Transmissions[i]);
                Speed_of_the_Wheels.Add(n);
            }
        }
        public List<double> Force_of_the_Wheels { get; set; }
        public double Calculate_Force_of_the_wheel(double torque, double transmission)
        {
            return (torque*1000*Gear_ratio*transmission*Transmission_efficiency) / (Wheel_radius);
        }
        public void Calculate_Force_of_the_wheels(double torque)
        {
            for (int i = 0; i < Transmissions.Count; i++)
            {
                var n = Calculate_Force_of_the_wheel(torque, Transmissions[i]);
                Force_of_the_Wheels.Add(n);
            }
        }
        public double Rolling_resistance { get; set; }
        static double G = 9.81;
        public void Calculate_Rolling_resistance()
        {
            Rolling_resistance =  Max_Weight*G*Rolling_Resistance_Factor;
        }
        public double The_hill_on_degree { get; set; }
        public double Rolling_resistance_on_a_hill { get; set; }
        public void Calculate_the_hill()
        {
            The_hill_on_degree = Math.Atan(Slope_of_rise/100)*180/Math.PI;
        }
        public void Calculate_Rolling_resistance_on_a_hill()
        {
            Calculate_the_hill(); 
            Rolling_resistance_on_a_hill = Max_Weight * G * Rolling_Resistance_Factor*Math.Cos(The_hill_on_degree*Math.PI/180);
        }
        public double Ascent_resistance { get; set; }
        public void Calculate_Ascent_resistance()
        {
            Calculate_the_hill();
            Ascent_resistance = Max_Weight * G  * Math.Sin(The_hill_on_degree * Math.PI / 180);
        }
        public List<double> AirResistances { get; set; }
        public double AirDensity { get; set; }
        public double Cross_Section { get; set; }
        public void Calculate_Cross_Section()
        {
            Cross_Section = 0.78 * Hight * Width/1000/1000;
        }
        public double Calculate_AirResistance(double speed_of_the_wheels)
        {
            return 0.5 * Cross_Section * Drag_coefficient * AirDensity * (speed_of_the_wheels*speed_of_the_wheels);
        }
        public void Calculate_AirResistanceses()
        {
            for (int i = 0; i < Speed_of_the_Wheels.Count; i++)
            {
                var Ar = Calculate_AirResistance(Speed_of_the_Wheels[i]);
                AirResistances.Add(Ar);
            }
        }

    }
}

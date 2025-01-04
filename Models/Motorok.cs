using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public int Gauge { get; set; }
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
            Speed_of_the_Wheels_P = new List<double>();
            Speed_of_the_Wheels_M = new List<double>();
            Force_of_the_Wheels_P = new List<double>();
            Force_of_the_Wheels_M = new List<double>();
            AirResistances_P = new List<double>();
            AirResistances_M = new List<double>();
            ForcesRequiredForAccelaration_P = new List<double>();
            ForcesRequiredForAccelaration_M = new List<double>();
            Accelarations_On_The_Hill_P = new List<double>();
            Accelarations_On_The_Hill_M = new List<double>();   
            Dynamic_Factors = new List<double>(); 
            ForceAgistTheCar_M = new List<double>();
            ForceAgistTheCar_P = new List<double>();
            Speed_In_Kmperh_M = new List<double>();
            Speed_In_Kmperh_P = new List<double>();

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
            P_M_Max = M_max * Calculate_ford_to_Radsec(n_M_max)/1000;
        }
        public List<double> Speed_of_the_Wheels_P { get; set; }
        public List<double> Speed_of_the_Wheels_M { get; set; }

        public double MeterminuteToKmhour(double metersec)
        {
            return metersec / 1000 / 1000 * 60;
        }
        public double Calculate_Speed_of_the_wheel(double ford, double transmission)
        {
            return (Wheel_radius*2*Math.PI*ford)/(transmission*Gear_ratio);
        }
        public void Calculate_Speed_of_the_wheels_P()
        {
            for (int i = 0; i < Transmissions.Count; i++) 
            {
                var n = Calculate_Speed_of_the_wheel(n_pn_max, Transmissions[i]);
                Speed_of_the_Wheels_P.Add(n);
            }
        }
        public void Calculate_Speed_of_the_wheels_M()
        {
            for (int i = 0; i < Transmissions.Count; i++)
            {
                var n = Calculate_Speed_of_the_wheel(n_M_max, Transmissions[i]);
                Speed_of_the_Wheels_M.Add(n);
            }
        }
        public List<double> Force_of_the_Wheels_P { get; set; }
        public List<double> Force_of_the_Wheels_M { get; set; }
        public double Calculate_Force_of_the_wheel(double torque, double transmission)
        {
            return (torque*1000*Gear_ratio*transmission*Transmission_efficiency) / (Wheel_radius);
        }
        public void Calculate_Force_of_the_wheels_P()
        {
            for (int i = 0; i < Transmissions.Count; i++)
            {
                var n = Calculate_Force_of_the_wheel(M_P_Max, Transmissions[i]);
                Force_of_the_Wheels_P.Add(n);
            }
        }
        public void Calculate_Force_of_the_wheels_M()
        {
            for (int i = 0; i < Transmissions.Count; i++)
            {
                var n = Calculate_Force_of_the_wheel(M_max, Transmissions[i]);
                Force_of_the_Wheels_M.Add(n);
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
        public List<double> AirResistances_P { get; set; }
        public List<double> AirResistances_M { get; set; }
        public double AirDensity { get; set; }
        public double Cross_Section { get; set; }
        public void Calculate_Cross_Section()
        {
            Cross_Section = 0.78 * Hight * Width/1000/1000;
        }
        public double Calculate_AirResistance(double speed_of_the_wheels)
        {
            var velocity = (speed_of_the_wheels / 60)/1000; // converting to m/s
            return (0.5 * Cross_Section * Drag_coefficient * AirDensity * ((velocity)*(velocity)));
        }
        public void Calculate_AirResistanceses_P()
        {
            for (int i = 0; i < Speed_of_the_Wheels_P.Count; i++)
            {
                var Ar = Calculate_AirResistance(Speed_of_the_Wheels_P[i]);
                AirResistances_P.Add(Ar);
            }
        }
        public void Calculate_AirResistanceses_M()
        {
            for (int i = 0; i < Speed_of_the_Wheels_M.Count; i++)
            {
                var Ar = Calculate_AirResistance(Speed_of_the_Wheels_M[i]);
                AirResistances_M.Add(Ar);
            }
        }
        public List<double> ForcesRequiredForAccelaration_P { get; set; }
        public List<double> ForcesRequiredForAccelaration_M { get; set; }
        public double Force_Required_For_Accelaration_P(int gear)
        {
            double air_res=AirResistances_P[gear];
            double a_ress = Ascent_resistance;
            double roll_ress_hill = Rolling_resistance;
            double force_of_whill = Force_of_the_Wheels_P[gear];
            return force_of_whill-(air_res+a_ress+roll_ress_hill);
        }
        public double Force_Required_For_Accelaration_M(int gear)
        {
            double air_res = AirResistances_M[gear];
            double a_ress = Ascent_resistance;
            double roll_ress_hill = Rolling_resistance;
            double force_of_whill = Force_of_the_Wheels_M[gear];
            return force_of_whill - (air_res + a_ress + roll_ress_hill);
        }
        public void Calculate_Forces_Required_For_Accelaration_P()
        {
            for (int i = 0; i < AirResistances_P.Count; i++)
            {
                var force = Force_Required_For_Accelaration_P(i);
                ForcesRequiredForAccelaration_P.Add(force);
            }
        }
        public void Calculate_Forces_Required_For_Accelaration_M()
        {
            for (int i = 0; i < AirResistances_M.Count; i++)
            {
                var force = Force_Required_For_Accelaration_M(i);
                ForcesRequiredForAccelaration_M.Add(force);
            }
        }
        public List<double> Accelarations_On_The_Hill_P { get; set; }
        public List<double> Accelarations_On_The_Hill_M { get; set; }
        public double Acceleration_On_The_Hill(double ForcesRequiredForAccelaration)
        {
            return ForcesRequiredForAccelaration/(Max_Weight*Reduction_constant_of_rotating_masses);
        }
        public void Calculate_Acceleration_On_The_Hill_M()
        {
            for (int i = 0; i < ForcesRequiredForAccelaration_M.Count; i++)
            {
                var acc = Acceleration_On_The_Hill(ForcesRequiredForAccelaration_M[i]);
                Accelarations_On_The_Hill_M.Add(acc);
            }
        }
        public void Calculate_Acceleration_On_The_Hill_P()
        {
            for (int i = 0; i < ForcesRequiredForAccelaration_P.Count; i++)
            {
                var acc = Acceleration_On_The_Hill(ForcesRequiredForAccelaration_P[i]);
                Accelarations_On_The_Hill_P.Add(acc);
            }
        }
        public List<double> Dynamic_Factors { get; set; }
        public double Dynamic_Factor(double ForcesRequiredForAccelaration, double AirResistances)
        {
            return (ForcesRequiredForAccelaration-AirResistances) / (Max_Weight * G); ;
        }
        public void Calculate_Dynamic_Factors()
        {
            for (int i = 0; i < Force_of_the_Wheels_P.Count; i++)
            {
                var dyna = Dynamic_Factor(Force_of_the_Wheels_P[i], AirResistances_P[i]);
                Dynamic_Factors.Add(dyna);
            }
        }
        public List<double> ForceAgistTheCar_P { get; set; }
        public List<double> ForceAgistTheCar_M { get; set; }
        public List<double> Speed_In_Kmperh_P { get; set; }
        public List<double> Speed_In_Kmperh_M { get; set; }

        public void ConertTheLists()
        {
            Speed_In_Kmperh_M = ConvertThelistToKmperh(Speed_of_the_Wheels_M);
            Speed_In_Kmperh_P = ConvertThelistToKmperh(Speed_of_the_Wheels_P);
        }
        public List<double> ConvertThelistToKmperh(List<double> speedlist)
        {
            var list = new List<double>();
            for (int i = 0; i < speedlist.Count; i++)
            {
                list.Add(MeterminuteToKmhour(speedlist[i]));
            } 
            return list;
        }
        public void CalculateTheForecAgistTheCar()
        {
            ForceAgistTheCar_P = SummTheForces(AirResistances_P);
            ForceAgistTheCar_M = SummTheForces(AirResistances_M);
        }
        public List <double> SummTheForces(List<double> forceList)
        {
            var list = new List<double>();
            for (int i = 0; i < forceList.Count; i++)
            {
                list.Add(forceList[i] + Ascent_resistance+Rolling_resistance);
            }
            return list;
        }
        
        public void Calculate()
        {
            Calculate_Wheel_radius();
            Calculate_M_P_Max();
            Calculate_P_M_Max();
            Calculate_Speed_of_the_wheels_P();
            Calculate_Speed_of_the_wheels_M();
            Calculate_Force_of_the_wheels_P();
            Calculate_Force_of_the_wheels_M();
            Calculate_Rolling_resistance();
            Calculate_Rolling_resistance_on_a_hill();
            Calculate_Ascent_resistance();
            Calculate_Cross_Section();
            Calculate_AirResistanceses_P();
            Calculate_AirResistanceses_M();
            Calculate_Forces_Required_For_Accelaration_P();
            Calculate_Forces_Required_For_Accelaration_M();
            Calculate_Acceleration_On_The_Hill_P();
            Calculate_Acceleration_On_The_Hill_M();
            Calculate_Dynamic_Factors();
            ConertTheLists();
            CalculateTheForecAgistTheCar();
        }
    }
}

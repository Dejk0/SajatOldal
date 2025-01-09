namespace SajatOldal.Models.Motorok
{
    public class MotorokMethods : MotorokPropertes
    {
        

        public void SetupUpTheTransmissionsList()
        {
            if (double.TryParse(Transmisson_1, out double value1) && value1!= 0)
            {
                Transmissions.Add(value1);
            }
            if (double.TryParse(Transmisson_2, out double value2) && value2 != 0)
            {
                Transmissions.Add(value2);
            }
            if (double.TryParse(Transmisson_3, out double value3) && value3 != 0)
            {
                Transmissions.Add(value3);
            }
            if (double.TryParse(Transmisson_4, out double value4) && value4 != 0)
            {
                Transmissions.Add(value4);
            }
            if (double.TryParse(Transmisson_5, out double value5) && value5 != 0)
            {
                Transmissions.Add(value5);
            }
            if (double.TryParse(Transmisson_6, out double value6) && value6 != 0)
            {
                Transmissions.Add(value6);
            }
        }

      
        public void Calculate_Wheel_radius()
        {

            string[] tire = Tire.Split(' ');
            string[] per = tire[0].Split('/');

            double[] tire_data = new double[]
            {
                double.Parse(per[0]),
                double.Parse(per[1]),
                double.Parse(tire[2])
            };
            Wheel_radius = (tire_data[2] * 25.4 / 2 + tire_data[0] * tire_data[1] / 100) * Creep_factor;
            while (Wheel_radius > 1000)
            {
                Wheel_radius = Wheel_radius / 10;
            }
        }

        public void Calculate_M_P_Max()
        {
            M_P_Max = Pn_max * 1000 * 60 / (2 * Math.PI * n_pn_max);
        }
        public double P_M_Max { get; set; }
        public double Calculate_ford_to_Radsec(double ford)
        {
            return ford * 2 * Math.PI / 60;
        }
        public void Calculate_P_M_Max()
        {
            P_M_Max = M_max * Calculate_ford_to_Radsec(n_M_max) / 1000;
        }


        public double MeterminuteToKmhour(double metersec)
        {
            return metersec / 1000 / 1000 * 60;
        }
        public double Calculate_Speed_of_the_wheel(double ford, double transmission)
        {
            return Wheel_radius * 2 * Math.PI * ford / (transmission * Gear_ratio);
        }
        public void Calculate_Speed_of_the_wheels_P()
        {
            for (int i = 0; i < Transmissions.Count; i++)
            {
                var n = Calculate_Speed_of_the_wheel(n_pn_max, ( Transmissions[i]));
                Speed_of_the_Wheels_P.Add(n);
            }
        }
        public void Calculate_Speed_of_the_wheels_M()
        {
            for (int i = 0; i < Transmissions.Count; i++)
            {
                var n = Calculate_Speed_of_the_wheel(n_M_max, (Transmissions[i]));
                Speed_of_the_Wheels_M.Add(n);
            }
        }

        public double Calculate_Force_of_the_wheel(double torque, double transmission)
        {
            return torque * 1000 * Gear_ratio * transmission * Transmission_efficiency / Wheel_radius;
        }
        public void Calculate_Force_of_the_wheels_P()
        {
            for (int i = 0; i < Transmissions.Count; i++)
            {
                var n = Calculate_Force_of_the_wheel(M_P_Max, (Transmissions[i]));
                Force_of_the_Wheels_P.Add(n);
            }
        }
        public void Calculate_Force_of_the_wheels_M()
        {
            for (int i = 0; i < Transmissions.Count; i++)
            {
                var n = Calculate_Force_of_the_wheel(M_max, (Transmissions[i]));
                Force_of_the_Wheels_M.Add(n);
            }
        }

        public void Calculate_Rolling_resistance()
        {
            Rolling_resistance = Max_Weight * G * Rolling_Resistance_Factor;
        }

        public void Calculate_the_hill()
        {
            The_hill_on_degree = Math.Atan(Slope_of_rise / 100) * 180 / Math.PI;
        }
        public void Calculate_Rolling_resistance_on_a_hill()
        {
            Calculate_the_hill();
            Rolling_resistance_on_a_hill = Max_Weight * G * Rolling_Resistance_Factor * Math.Cos(The_hill_on_degree * Math.PI / 180);
        }

        public void Calculate_Ascent_resistance()
        {
            Calculate_the_hill();
            Ascent_resistance = Max_Weight * G * Math.Sin(The_hill_on_degree * Math.PI / 180);
        }

        public void Calculate_Cross_Section()
        {
            Cross_Section = 0.78 * Hight * Width / 1000 / 1000;
        }
        public double Calculate_AirResistance(double speed_of_the_wheels)
        {
            var velocity = speed_of_the_wheels / 60 / 1000; // converting to m/s
            return 0.5 * Cross_Section * Drag_coefficient * AirDensity * (velocity * velocity);
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

        public double Force_Required_For_Accelaration_P(int gear)
        {
            double air_res = AirResistances_P[gear];
            double a_ress = Ascent_resistance;
            double roll_ress_hill = Rolling_resistance;
            double force_of_whill = Force_of_the_Wheels_P[gear];
            return force_of_whill - (air_res + a_ress + roll_ress_hill);
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

        public double Acceleration_On_The_Hill(double ForcesRequiredForAccelaration)
        {
            return ForcesRequiredForAccelaration / (Max_Weight * Reduction_constant_of_rotating_masses);
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
        public double Dynamic_Factor(double ForcesRequiredForAccelaration, double AirResistances)
        {
            return (ForcesRequiredForAccelaration - AirResistances) / (Max_Weight * G); ;
        }
        public void Calculate_Dynamic_Factors()
        {
            for (int i = 0; i < Force_of_the_Wheels_P.Count; i++)
            {
                var dyna = Dynamic_Factor(Force_of_the_Wheels_P[i], AirResistances_P[i]);
                Dynamic_Factors.Add(dyna);
            }
        }

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
        public List<double> SummTheForces(List<double> forceList)
        {
            var list = new List<double>();
            for (int i = 0; i < forceList.Count; i++)
            {
                list.Add(forceList[i] + Ascent_resistance + Rolling_resistance);
            }
            return list;
        }
    }
}

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Transactions;
using System.ComponentModel.DataAnnotations;

namespace SajatOldal.Models.Motorok
{
    public class Motorok : MotorokMethods
    {
        public void Calculate()
        {
            //gyakorlatilag ennél lentebb azért nem lehet bontani mert ez a feladat menete.
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
    }
}

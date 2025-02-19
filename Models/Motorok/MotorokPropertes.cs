﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using SajatOldal.Models.Motorok;

namespace SajatOldal.Models.Motorok
{
    public class MotorokPropertes 
    {
        [Key]
        public Guid Id { get; set; }
        public double Pn_max { get; set; }
        public double n_pn_max { get; set; }
        public double M_max { get; set; }
        public double n_M_max { get; set; }
        [Range(0, 100000, ErrorMessage = "Szám kell")]
        public double Weight { get; set; }
        
        public int Max_Weight { get; set; }
        
        public List<double> Transmissions { get; set; }
        [RegularExpression(@"^(10|[0-9](,\d{1,100})?)$", ErrorMessage = "A számnak 0 és 10 között kell lennie, és a tizedesjegyeket ',' karakterrel kell elválasztani.")]
        public string? Transmisson_1 { get; set; }
        [RegularExpression(@"^(10|[0-9](,\d{1,100})?)$", ErrorMessage = "A számnak 0 és 10 között kell lennie, és a tizedesjegyeket ',' karakterrel kell elválasztani.")]

        public string? Transmisson_2 { get; set; }
        [RegularExpression(@"^(10|[0-9](,\d{1,100})?)$", ErrorMessage = "A számnak 0 és 10 között kell lennie, és a tizedesjegyeket ',' karakterrel kell elválasztani.")]

        public string? Transmisson_3 { get; set; }
        [RegularExpression(@"^(10|[0-9](,\d{1,100})?)$", ErrorMessage = "A számnak 0 és 10 között kell lennie, és a tizedesjegyeket ',' karakterrel kell elválasztani.")]

        public string? Transmisson_4 { get; set; }
        [RegularExpression(@"^(10|[0-9](,\d{1,100})?)$", ErrorMessage = "A számnak 0 és 10 között kell lennie, és a tizedesjegyeket ',' karakterrel kell elválasztani.")]

        public string? Transmisson_5 { get; set; }
        [RegularExpression(@"^(10|[0-9](,\d{1,100})?)$", ErrorMessage = "A számnak 0 és 10 között kell lennie, és a tizedesjegyeket ',' karakterrel kell elválasztani.")]

        public string? Transmisson_6 { get; set; }
        public string CarName { get; set; }

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
        public double Wheel_radius { get; set; }
        public double M_P_Max { get; set; }
        public List<double> Speed_of_the_Wheels_P { get; set; }
        public List<double> Speed_of_the_Wheels_M { get; set; }
        public List<double> Force_of_the_Wheels_P { get; set; }
        public List<double> Force_of_the_Wheels_M { get; set; }
        public double Rolling_resistance { get; set; }
        public static double G = 9.81;
        public double The_hill_on_degree { get; set; }
        public double Rolling_resistance_on_a_hill { get; set; }
        public double Ascent_resistance { get; set; }
        public List<double> AirResistances_P { get; set; }
        public List<double> AirResistances_M { get; set; }
        public double AirDensity { get; set; }
        public double Cross_Section { get; set; }
        public List<double> ForcesRequiredForAccelaration_P { get; set; }
        public List<double> ForcesRequiredForAccelaration_M { get; set; }
        public List<double> Accelarations_On_The_Hill_P { get; set; }
        public List<double> Accelarations_On_The_Hill_M { get; set; }
        public List<double> Dynamic_Factors { get; set; }
        public List<double> ForceAgistTheCar_P { get; set; }
        public List<double> ForceAgistTheCar_M { get; set; }
        public List<double> Speed_In_Kmperh_P { get; set; }
        public List<double> Speed_In_Kmperh_M { get; set; }

       
    }
}

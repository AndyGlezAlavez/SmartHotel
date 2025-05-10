using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.VisualBasic.FileIO;
using SmartHotel.Domain.Common;
using SmartHotel.Domain.Entities;
using SmartHotel.Domain.Types;
using SmartHotel.Domain.ValueObjects;

// Interfaz para sensores
public interface ISensor
{
    string NombreVariable { get; }
    string UnidadMedida { get; }
    double ValorMedido { get; set; }
    string TipoSeñalSalida { get; } // "4-20mA" o "0-10V"
}

// Implementación de un sensor de temperatura
public class SensorTemperatura : ISensor
{
    public string NombreVariable => "Temperatura";
    public string UnidadMedida => "ºC";
    public double ValorMedido { get; set; }
    public string TipoSeñalSalida => "4-20mA";
}

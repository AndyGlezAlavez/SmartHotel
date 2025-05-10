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


// Interfaz para actuadores
public interface IActuador
{
    string TipoSeñalEntrada { get; } // "4-20mA" o "0-10V"
    bool Estado { get; set; } // ON/OFF
}


// Implementación de un actuador ON/OFF
public class ActuadorIluminacion : IActuador
{
    public string TipoSeñalEntrada => "0-10V";
    public bool Estado { get; set; }
}

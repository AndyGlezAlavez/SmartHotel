using SmartHotel.Domain.Common;
using SmartHotel.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.Domain.ValueObjects
{
    public class MesurementUnit : ValueObject
    {
            #region Properties
            /// <summary>
            /// Unidad de medida
            /// </summary>
            Variable var;
           /// <summary>
           /// nombre de la variable 
           /// </summary>
            string name;
            
            #endregion
            /// <summary>
            /// Inicializa un precio
            /// </summary>
            /// <param name="var"></param>
            /// <param name="value"></param>
            public MesurementUnit(Variable var)
            {
                this.var = var;
                string stringvar = var.ToString ();
                switch  (stringvar) {
                case "ºC": this.name = "temperatura"; break;
                case "ppm": this.name = "Concentración de humo"; break;
                case "LUX": this.name = "iluminación"; break;
                default :
                Console.WriteLine("Opción no válida.");
                break;
            }
        }
        protected override IEnumerable<object> GetEqualityComponents()
            {
                return new object[] { var, name };
            }
        }

    }

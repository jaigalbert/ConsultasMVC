using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasMVC.Models.Dto
{
    class Producto
    {
        //ATRIBUTOS 
        int _ID;
        string _Nombre;
        string _Precio;
        string _Descripcion;
        
        //PROPIEDADES GETTERS AND SETTERS
        public int ID
        {
            get {                 return _ID;            }
            set {                _ID = value;            }
        }

        public string Nombre
        {
            get {                return _Nombre;            }
            set {                _Nombre = value;            }
        }

        public string Precio
        {
            get {                return _Precio;            }
            set {                _Precio = value;            }
        }

        public string Descripcion
        {
            get {                return _Descripcion;            }
            set {                 _Descripcion = value;            }
        }


    }
}

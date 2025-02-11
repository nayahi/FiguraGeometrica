using System;

namespace FiguraGeometrica
{
    /// <summary>
    /// Esta clase define los atributos y comportamiento base de todas las demas figuras
    /// </summary>
    public class Figura
    {
        #region Atributos
        /// <summary>
        /// Atributos encapsulado para el nombre de la figura
        /// </summary>
        protected string _nombre;
        /// <summary>
        /// Atributos encapsulado para el color de la figura
        /// </summary>
        protected string _color;

        /// <summary>
        /// Atributos encapsulado para tener siempre la cantidad de figuras creadas o instanciadas
        /// </summary>
        private static int _cantidadFiguras = 0;
        #endregion Atributes

        #region Propiedades
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        #endregion Propiedades

        #region Constructores
        /// <summary>
        /// 
        public Figura()
        {
            _nombre = "desconocida";
            _color = "Blanco";
            _cantidadFiguras++;
        }

        public Figura(string nombre, string color)
        {
            _nombre = nombre;
            _color = color;
            _cantidadFiguras++;
        }
        #endregion Constructores

        #region Metodos estaticos
        public static int ObtenerCantidadFiguras()
        {
            return _cantidadFiguras;
        }
        #endregion Metodos estaticos

        #region Metodos virtuales
        /// <summary>
        /// Metodo virtual para calcular el area de la figura
        /// </summary>
        /// <returns>Un valor doble</returns>
        public virtual double CalcularArea()
        {
            return 0.0;
        }
        /// <summary>
        /// Metodo virtual para calcular el perimetro de la figura
        /// </summary>
        /// <returns>Un valor doble</returns>
        public virtual double CalcularPerimetro()
        {
            return 0.0;
        }
        /// <summary>
        /// Metodo virtual para Obtener la informacion basica de la figura
        /// </summary>
        /// <returns>Un valor doble</returns>
        public virtual string ObtenerInformacion()
        {
            return string.Format("Nombre: {0}, Color: {1}", _nombre, _color);
        }
        public virtual string ObtenerInformacion(bool incluirArea)
        {
            return $"{ObtenerInformacion()}, Area: {CalcularArea()}";
        }
        #endregion Metodos virtuales
    }

    public class Rectangulo : Figura
    {
        #region Atributos
        private double _lado1;
        private double _lado2;
        #endregion Atributos
        #region Propiedades
        public double Lado1
        {
            get { return _lado1; }
            set { _lado1 = value; }
        }
        public double Lado2
        {
            get { return _lado2; }
            set { _lado2 = value; }
        }
        #endregion Propiedades
        #region Constructores
        public Rectangulo() : base()
        {
            _lado1 = 0.0;
            _lado2 = 0.0;
        }
        public Rectangulo(string nombre, string color, double lado1, double lado2) : base(nombre, color)
        {
            _lado1 = lado1;
            _lado2 = lado2;
        }
        #endregion Constructores
        #region Metodos
        public override double CalcularArea()
        {
            return _lado1 * _lado2;
        }
        public override double CalcularPerimetro()
        {
            return 2 * (_lado1 + _lado2);
        }
        public override string ObtenerInformacion()
        {
            return $"{base.ObtenerInformacion()}, Lado1: {_lado1}, Lado2: {_lado2}";
        }
        public override string ObtenerInformacion(bool incluirArea)
        {
            return $"{ObtenerInformacion()}, Area: {CalcularArea()}";
        }
        #endregion Metodos
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Figura Geometrica");
            Console.WriteLine("1. Figura");
            Console.WriteLine("2. Rectangulo");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opcion: ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Figura figura = new Figura();
                    Console.WriteLine(figura.CalcularArea());
                    Console.WriteLine(figura.CalcularPerimetro());
                    Console.WriteLine(figura.ObtenerInformacion());
                    Console.WriteLine(figura.ObtenerInformacion(true));
                    break;
                case 2:
                    Rectangulo rectangulo = new Rectangulo("rectangulo", "Azul", 10, 10);
                    Console.WriteLine(rectangulo.CalcularArea());
                    Console.WriteLine(rectangulo.CalcularPerimetro());
                    Console.WriteLine(rectangulo.ObtenerInformacion());
                    Console.WriteLine(rectangulo.ObtenerInformacion(true));
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        }
    }
}
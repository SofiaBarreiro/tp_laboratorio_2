using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Excepciones;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UniversidadInvalida()
        {

            Universidad nueva = new Universidad();

            try
            {

                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
                nueva += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        [TestMethod]
        public void AlumnoInvalido()
        {

            Universidad uni = new Universidad();
            try
            {
                Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
                uni += a3;

            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void NumeroInvalido()
        {

            float nro = 15;
            if (nro != 15)
            {
                Console.WriteLine("El numero es invalido");
            }

        }


        public void ProfesorInvalido()
        {
            Profesor i1 = new Profesor(1, "Juan", "78787", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            if (i1.Apellido == null)
            {
                Console.WriteLine("el dato es invalido");
            }
           

        }



    }
}

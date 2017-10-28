using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;


namespace TestEntidadesInstanciables
{
    [TestClass]
    public class TestEntidadesInstanciables
    {
        //Pruebo que pueda insertar un alumno correcto 
        [TestMethod]
        public void AlumnoCorreco()
        {
            Alumno a1 = new Alumno(1,"Pedro","Perez","12345678",EntidadesAbstractas.Universitario.ENacionalidad.Argentino,Universidad.EClases.Laboratorio);
            Assert.IsNotNull(a1);
            
           //Pruebo que realmente no se haya insertado el texto raro y haya cumplido la validacion
            //Cambiandolo a vacio
            a1.Apellido = "3#$pedro";
            Assert.AreEqual(a1.Apellido, "");

            Alumno a2 = new Alumno(1, "Pedro", "Perez", "12345678", EntidadesAbstractas.Universitario.ENacionalidad.Argentino, Universidad.EClases.SPD,Alumno.EEstadoCuenta.AlDia);
            Assert.AreEqual(a1, a2);
            bool rta = a2==Universidad.EClases.Legislacion;
            Assert.IsFalse(rta);
            bool rta2 = a2 == Universidad.EClases.SPD;
            Assert.IsTrue(rta2);
            try 
            { 
                a1.DNI = 1111111111;
                
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
                //Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void ProfesorCorrecto() 
        {
            //Genero un nuevo profesor
            Profesor p1 = new Profesor(1, "Juan", "Cardozo", "22222222", Persona.ENacionalidad.Argentino);
            
            //Pruebo no generar un Objeto Null
            Assert.IsNotNull(p1);
            
            //Pruebo que sea de tipo profesor
            Assert.IsInstanceOfType(p1,typeof(Profesor));
            
            //Pruebo la validacion de nombre
            p1.Nombre = "#####";
            Assert.AreSame(p1.Nombre, "");
            
            //Realizo la comparacion por numero de dni, para ver si son iguales
            Profesor p2 = new Profesor(0002, "Alberto", "Cardozo", "22222222", Persona.ENacionalidad.Argentino);
            bool rta = p1 == p2;
            Assert.IsTrue(rta);
            
            //Le cambio el dni, para que ahora no sean iguales
            p2.DNI = 1234567;
            rta = p1 == p2;
            Assert.IsFalse(rta);

        }

        [TestMethod]
        public void JornadaCorrecta() 
        {
            Profesor p1 = new Profesor(1, "Juan", "Cardozo", "22222222", Persona.ENacionalidad.Argentino);
            Jornada j1 = new Jornada(Universidad.EClases.SPD, p1);

            Jornada j2 = new Jornada();
            Assert.IsNotNull(j2);
            Assert.IsNull(j2.Instructor);


        }

        [TestMethod]
        public void UniversidadCorrecta() 
        {
            Universidad uni1 = new Universidad();
            Assert.IsNotNull(uni1);
            Alumno a1 = new Alumno(1, "Pedro", "Perez", "12345678", EntidadesAbstractas.Universitario.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);


        }


    }
}

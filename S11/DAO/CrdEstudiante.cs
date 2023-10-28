using S11.DAO;
using S11.Data;
using S11.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace S11.DAO
{
    public class CrdEstudiante
    {
        Contexto db = new Contexto();

        public estudiante EstudianteIndivi(int Id)
        {
            var buscar = db.Estudiante.FirstOrDefault(x => x.Id == Id);
            return buscar;
        }

        public void CreateEstu(estudiante Es)
        {
            estudiante Estudiante = new estudiante();

            Estudiante.Nombres = Es.Nombres;
            Estudiante.Apellidos = Es.Apellidos;
            Estudiante.Edad = Es.Edad;
            Estudiante.Sexo = Es.Sexo;

            db.Add(Estudiante);
            db.SaveChanges();
        }

        public void UpdateEstu(estudiante Estudiante, int LR)
        {
            var buscar = EstudianteIndivi(Estudiante.Id);

            if (buscar == null)
            {
                Console.WriteLine("El id no existe");
            }
            else
            {
                if (LR == 1)
                {
                    buscar.Nombres = Estudiante.Nombres;
                }
                else if (LR == 2)
                {
                    buscar.Apellidos = Estudiante.Apellidos;
                }
                else if (LR == 3)
                {
                    buscar.Edad = Estudiante.Edad;
                }
                else if (LR == 4)
                {
                    buscar.Sexo = Estudiante.Sexo;
                }
                db.Update(Estudiante);
                db.SaveChanges();
            }
        }
    }
}





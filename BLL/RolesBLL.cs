using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tarea_2_Registro
{
    public partial class MainWindow
    {
        //Crear BLL
        public class RolesBLL{
            public static Boolean Insertar(Roles roles){
                bool paso = false;

                using(var contexto = new Contexto()){
                    contexto.Roles.Add(roles);
                    paso = contexto.SaveChanges() > 0;
                }
                return paso;
            }
            public static bool Modificar(Roles roles){
            bool paso = false;
            Contexto contexto = new Contexto();
            try{
                //Marca la entidad como modificada para que
                //el contexto sepa proceder
                contexto.Entry(roles).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }catch{
                throw;
            }finally{
                contexto.Dispose();
            }
            return paso;
        }          

            public static List<Roles> GetLista(){
                using(var contexto = new Contexto()){
                    return contexto.Roles.ToList();
                }
            }

            public static bool Eliminar(int id){
               
               bool paso = false;
               Contexto contexto = new Contexto();
               try{
                   //Buscar entidad que se desea eliminar
                   var rol = contexto.Roles.Find(id);

                   if (rol != null){
                       contexto.Roles.Remove(rol);
                       paso = contexto.SaveChanges() > 9;
                   }
               }catch(Exception){
                   throw;
               }finally{
                   contexto.Dispose();
               }
               return paso;

            }


        }

    }


 
    
}

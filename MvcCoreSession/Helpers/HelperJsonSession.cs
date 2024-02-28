using MvcCoreSession.Models;
using Newtonsoft.Json;

namespace MvcCoreSession.Helpers
{
    public class HelperJsonSession
    {
        //internamente esxiste un metodo en session 
        //para trabajar en string, no ocn bytes
        //HttpContext.Session.GetString
        //HttpContext.Session.SetString
        //almacenaremos objetos:
        //{ Nombre: "Mascota", Raza: "Pez", Edad: 15 }
        //necesitamos un método para almacenar el objeto

        public static string SerializeObject<T>(T data)
        {
            //convertimos el obj a string utilizando newton
            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        //recibiremos un string y lo convertiremos a T
        public static T DeserializeObject<T>(string data)
        {
            //mediante newton deserializamos
            T objeto = JsonConvert.DeserializeObject<T>(data);
            return objeto;
        }
    }
}

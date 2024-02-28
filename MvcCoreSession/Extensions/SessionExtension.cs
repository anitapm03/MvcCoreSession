using MvcCoreSession.Helpers;
using Newtonsoft.Json;

namespace MvcCoreSession.Extensions
{
    public static class SessionExtension
    {
        //queremos un metodo para recuperar 
        //cualquier objeto
        public static T GetObject<T>
            (this ISession session, string key)
        {
            //necesitamos recuperar los datos que tenemos
            //almacenados en session mediante un key
            //recuperamos el string json 
            string json = session.GetString(key);
            //que sucede cuando recuperamos de session 
            //algo que no existe?
            if (json == null)
            {
                //si no existe la key devolvemos el valor
                //por defecto del obj recibido (T)
                return default(T);
            }
            else
            {
                //recuperamos el obj almacenado en la key
                T data = JsonConvert.DeserializeObject<T>(json);
                return data;
            }

        }

        //queremos un metodo para almacenar cualquier
        //objeto dentro de session
        //HttpContext.Session.SetObject(key, value);
        public static void SetObject
            (this ISession session, string key, object value)
        {
            //serializamos el objeto a string json
            string data = JsonConvert.SerializeObject(value);
            //almacenamos en session el string json
            session.SetString(key, data);

        }

    }
}

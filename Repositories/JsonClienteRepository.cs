using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clientes.Shared.Models;
using Clientes.Shared.Repositories;
using Newtonsoft.Json;

namespace Clientes.Shared.Repositories
{
    public class JsonClienteRepository: ClienteRepository
    {
        // Carpeta donde se almacenará el archivo JSON
        private readonly string folder = "Data";
        // Nombre del archivo que contiene los clientes
        private readonly string fileName = "clientes_store.json";
        // Propiedad que construye la ruta completa del archivo
        private string FullPath => Path.Combine(folder, fileName);

        // Obtiene todos los clientes almacenados en el archivo JSON
        public List<Cliente> GetAll()   
        {
            // Si la carpeta no existe, devuelve una lista vacía
            if (!Directory.Exists(folder))
                return new List<Cliente>();
            // Si el archivo no existe, devuelve una lista vacía
            if (!File.Exists(FullPath))
                return new List<Cliente>();
            // Lee todo el contenido del archivo JSON
            var json = File.ReadAllText(FullPath);

            // Convierte el JSON en una lista de objetos Cliente
            // Si la deserialización devuelve null, se retorna una lista vacía
            return JsonConvert.DeserializeObject<List<Cliente>>(json)
                   ?? new List<Cliente>();
        }

        // Guarda todos los clientes en el archivo JSON
        public void SaveAll(List<Cliente> clients)
        {
            try
            {
                // Si la lista es null se crea una nueva lista vacía
                if (clients == null)
                    clients = new List<Cliente>();

                // Crear carpeta si no existe
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                // Convierte la lista de clientes a formato JSON
                var json = JsonConvert.SerializeObject(
                    clients,
                    Formatting.Indented
                );
                // Escribe el JSON en el archivo
                File.WriteAllText(FullPath, json);
            }
            catch (Exception ex)
            {
                // Lanza una excepción personalizada si ocurre un error al guardar
                throw new Exception("Error guardando los clientes", ex);
            }
        }
    }
}

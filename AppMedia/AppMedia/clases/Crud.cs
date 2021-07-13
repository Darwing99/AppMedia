using AppMedia.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppMedia.clases
{
     class Crud
    {

        Conexion conn = new Conexion();

        public Crud()
        {

        }

        public Task<List<MediaVideo>> getReadMedia()
        {

            var datos = conn.GetConnectionAsync().Table<MediaVideo>().ToListAsync();


            //    var data = conn.Conn().Query<Imagen>("Select*from Imagen").FirstOrDefault();

            return datos;

        }

        public Task<MediaVideo> GetMediaId(int id)
        {
            return conn
                .GetConnectionAsync()
                .Table<MediaVideo>()
                .Where(item => item.id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> getMediaUpdateId(MediaVideo media)
        {
            return conn
                .GetConnectionAsync()
                .UpdateAsync(media);

        }

        public Task<int> Delete(MediaVideo media)
        {
            return conn
                .GetConnectionAsync()
                .DeleteAsync(media);
        }
    }
}

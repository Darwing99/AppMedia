using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace AppMedia.model
{
    class MediaVideo
    {

            [PrimaryKey, AutoIncrement]
            public int id { get; set; }
            [MaxLength(200)]
            public string Nombre { get; set; }
            public string descripcion { get; set; }
            public string MiImagen { get; set; }

    }
}

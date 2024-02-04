﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiexamen
{
    public class Examen
    {
        public int IdExamen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class ExamenCreate
    {
        public bool Respuesta { get; set; }
        public string Descripcion { get; set; }
    }
    public class ExamenConsultId
    {
        public int IdExamen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }

        public static ApiResponse<T> Ok(T data) => new ApiResponse<T> { Success = true, Data = data };
        public static ApiResponse<T> Fail(string error) => new ApiResponse<T> { Success = false, Error = error };
    }
}

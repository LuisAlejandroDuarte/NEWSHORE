using Microsoft.AspNetCore.Http;

namespace NEWSHORE.DTOs
{
    public class Paginator
    {
        public int? draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public string? searchby { get; set; } = string.Empty;
        public string? sortColumn { get; set; } = string.Empty;
        public string? sortDirection { get; set; } = string.Empty;
        public long? idEmpresa { get; set; }
        public DateTime? filterDate { get; set; }



        public static Paginator GetPaginador(IFormCollection coleccion)
        {
            return new Paginator()
            {
                draw = Convert.ToInt16(coleccion["draw"].FirstOrDefault()),
                start = Convert.ToInt16(coleccion["start"].FirstOrDefault()),
                length = Convert.ToInt16(coleccion["length"].FirstOrDefault()),
                searchby = coleccion["search[value]"].FirstOrDefault(),
                sortColumn = coleccion["columns[" + coleccion["order[0][column]"].FirstOrDefault() + "][data]"].FirstOrDefault(),
                sortDirection = coleccion["order[0][dir]"],
                idEmpresa = Convert.ToInt16(coleccion["empresaId"])
            };
        }

    }

    public class ResultDataTable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public object? data { get; set; }

    }

    public class ColumnsAccion
    {
        public string? Bloqueado { get; set; } = string.Empty;
        public string? Edit { get; set; } = string.Empty;
        public string? Eliminar { get; set; } = string.Empty;
    }
}

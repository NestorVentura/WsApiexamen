using System.ComponentModel.DataAnnotations;

namespace WsApiexamen.Dto
{
    public class ExamenPutDto
    {
       
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}

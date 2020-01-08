namespace apoio2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRO_USU_USUARIO
    {
        [Key]
        public int USU_N_CODIGO { get; set; }

        public string USU_C_NOME { get; set; }

        public string USU_C_SENHA { get; set; }

        public bool? USU_C_ATIVO { get; set; }
    }
}

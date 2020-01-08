namespace apoio2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRO_PRO_PRODUTO
    {
        [Key]
        public int PRO_N_CODIGO { get; set; }

        public int? PRO_N_REFERENCIA { get; set; }

        public string PRO_C_NOME { get; set; }

        public string PRO_C_DESCRICAO { get; set; }

        public string PRO_C_MARCA { get; set; }

        public string PRO_C_COR { get; set; }

        public decimal? PRO_C_VALOR { get; set; }

        public decimal? PRO_C_VALOR_VENDA { get; set; }

        public decimal? PRO_C_PORCENTAGEM { get; set; }

        public DateTime? PRO_D_DATA_CADASTRO { get; set; }

        public DateTime? PRO_D_DATA_VENDA { get; set; }

        public string PRO_C_TAMANHO { get; set; }

        public int? PRO_N_SITUACAO { get; set; }

        public string PRO_C_IMAGEM { get; set; }

        public bool? PRO_B_ATIVO { get; set; }
    }
}

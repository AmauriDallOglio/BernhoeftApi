using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dominio.Enum
{
    public class Enum
    {
        public enum SituacaoEnum
        {
            [Description("Ativo")]
            [Display(Name = "Ativo")]
            [EnumMember(Value = "Ativo")]
            Ativo = 0,
            [Description("Inativo")]
            [Display(Name = "Inativo")]
            [EnumMember(Value = "Inativo")]
            Inativo = 1,
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Domain.Enums
{
    public enum PensionType
    {
        [Description("Herşey Dahil")]
        HerşeyDahil,

        [Description("Alkolsüz Herşey Dahil")]
        AlkolsüzHerşeyDahil,

        [Description("Oda Kahvaltı")]
        OdaKahvaltı,

        [Description("Sadece Oda")]
        SadeceOda
    }
}

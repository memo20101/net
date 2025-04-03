using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recetas.API.Domain.Entities
{
    public enum EstadoReceta
    {
        Activa,
        Vencida,
        Entregada,
        Cancelada
    }
}
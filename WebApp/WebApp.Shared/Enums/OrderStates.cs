using System.ComponentModel;

namespace WebApp.Shared.Enums
{
    public enum OrderStates
    {
        [Description("Nuevo")]
        New,

        [Description("Confirmada")]
        Confirmed,

        [Description("Alistando")]
        Preparing,

        [Description("Enviado")]
        Sent,

        [Description("Entregada")]
        Delivered,

        [Description("Cancelada")]
        Cancelled
    }
}
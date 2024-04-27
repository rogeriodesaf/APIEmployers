﻿using System.Text.Json.Serialization;

namespace WebApiFuncionarios.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        Manhã,
        Tarde,
        Noite
    }
}

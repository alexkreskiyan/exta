using System;
using Annium.Core.Entrypoint;
using Server.Db.Migrator;

await using var entry = Entrypoint.Default
    .UseServicePack<ServicePack>()
    .Setup();

Console.WriteLine("Hello from Server.Db.Migrator");
using System;
using Annium.Architecture.ViewModel;
using Core.Domain.Models;

namespace Server.ViewModels.Responses.Checks;

public class TempCheckResponse : IResponse<TempCheck>
{
    public string ContentType { get; set; } = string.Empty;
    public byte[] Data { get; set; } = Array.Empty<byte>();
}
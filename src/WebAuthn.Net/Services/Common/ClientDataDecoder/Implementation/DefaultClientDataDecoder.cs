using System;
using Microsoft.Extensions.Logging;
using WebAuthn.Net.Models;
using WebAuthn.Net.Services.Common.ClientDataDecoder.Implementation.Models;
using WebAuthn.Net.Services.Common.ClientDataDecoder.Models;
using WebAuthn.Net.Services.Serialization.Json;

namespace WebAuthn.Net.Services.Common.ClientDataDecoder.Implementation;

/// <summary>
///     Default implementation of <see cref="IClientDataDecoder" />.
/// </summary>
public class DefaultClientDataDecoder : IClientDataDecoder
{
    /// <summary>
    ///     Constructs <see cref="DefaultClientDataDecoder" />
    /// </summary>
    /// <param name="safeJsonSerializer">Safe (exceptionless) JSON serializer.</param>
    /// <param name="logger">Logger.</param>
    /// <exception cref="ArgumentNullException">Any of the parameters is <see langword="null" /></exception>
    public DefaultClientDataDecoder(
        ISafeJsonSerializer safeJsonSerializer,
        ILogger<DefaultClientDataDecoder> logger)
    {
        ArgumentNullException.ThrowIfNull(safeJsonSerializer);
        ArgumentNullException.ThrowIfNull(logger);
        SafeJsonSerializer = safeJsonSerializer;
        Logger = logger;
    }

    /// <summary>
    ///     Safe (exceptionless) JSON serializer.
    /// </summary>
    protected ISafeJsonSerializer SafeJsonSerializer { get; }

    /// <summary>
    ///     Logger.
    /// </summary>
    protected ILogger<DefaultClientDataDecoder> Logger { get; }

    /// <inheritdoc />
    public virtual Result<CollectedClientData> Decode(string jsonText)
    {
        var clientDataResult = SafeJsonSerializer.DeserializeNonNullable<CollectedClientDataJson>(jsonText);
        if (clientDataResult.HasError)
        {
            Logger.FailedToDeserializeClientData();
            return Result<CollectedClientData>.Fail();
        }

        var clientData = clientDataResult.Ok;
        if (string.IsNullOrEmpty(clientData.Type))
        {
            Logger.ClientDataTypeIsNullOrEmpty();
            return Result<CollectedClientData>.Fail();
        }

        if (string.IsNullOrEmpty(clientData.Challenge))
        {
            Logger.ClientDataChallengeIsNullOrEmpty();
            return Result<CollectedClientData>.Fail();
        }

        if (string.IsNullOrEmpty(clientData.Origin))
        {
            Logger.ClientDataOriginIsNullOrEmpty();
            return Result<CollectedClientData>.Fail();
        }

        var result = new CollectedClientData(
            clientData.Type,
            clientData.Challenge,
            clientData.Origin,
            clientData.CrossOrigin,
            clientData.TopOrigin);

        return Result<CollectedClientData>.Success(result);
    }
}

/// <summary>
///     Extension methods for logging the 'clientData' decoder.
/// </summary>
public static partial class DefaultClientDataDecoderLoggingExtensions
{
    /// <summary>
    ///     Failed to deserialize 'clientData'
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "Failed to deserialize 'clientData'")]
    public static partial void FailedToDeserializeClientData(this ILogger logger);

    /// <summary>
    ///     'clientData.type' contains an empty string or null
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "'clientData.type' contains an empty string or null")]
    public static partial void ClientDataTypeIsNullOrEmpty(this ILogger logger);

    /// <summary>
    ///     'clientData.challenge' contains an empty string or null
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "'clientData.challenge' contains an empty string or null")]
    public static partial void ClientDataChallengeIsNullOrEmpty(this ILogger logger);

    /// <summary>
    ///     'clientData.origin' contains an empty string or null
    /// </summary>
    /// <param name="logger">Logger.</param>
    [LoggerMessage(
        Level = LogLevel.Warning,
        Message = "'clientData.origin' contains an empty string or null")]
    public static partial void ClientDataOriginIsNullOrEmpty(this ILogger logger);
}

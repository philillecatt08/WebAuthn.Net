using System.Runtime.Serialization;

namespace WebAuthn.Net.Models.Protocol.Enums;

/// <summary>
///     Credential Type Enumeration
/// </summary>
/// <remarks>
///     <a href="https://www.w3.org/TR/webauthn-3/#enum-credentialType">Web Authentication: An API for accessing Public Key Credentials Level 3 - Credential Type Enumeration (enum PublicKeyCredentialType)</a>
/// </remarks>
public enum PublicKeyCredentialType
{
    /// <summary>
    ///     Public key.
    /// </summary>
    [EnumMember(Value = "public-key")]
    PublicKey = 0
}

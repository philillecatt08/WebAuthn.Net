using System;

namespace WebAuthn.Net.Models.Protocol.RegistrationCeremony.CreateOptions;

/// <summary>
///     Relying Party Parameters for Credential Generation (dictionary PublicKeyCredentialRpEntity)
/// </summary>
/// <remarks>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#dictionary-rp-credential-params">Web Authentication: An API for accessing Public Key Credentials Level 3 - Relying Party Parameters for Credential Generation (dictionary PublicKeyCredentialRpEntity)</a>
///     </para>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#sctn-parseCreationOptionsFromJSON">Web Authentication: An API for accessing Public Key Credentials Level 3 - Deserialize Registration ceremony options - PublicKeyCredential’s parseCreationOptionsFromJSON() Method</a>
///     </para>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#dictionary-makecredentialoptions">Web Authentication: An API for accessing Public Key Credentials Level 3 - Options for Credential Creation (dictionary PublicKeyCredentialCreationOptions)</a>
///     </para>
/// </remarks>
public class PublicKeyCredentialRpEntity
{
    /// <summary>
    ///     Constructs <see cref="PublicKeyCredentialRpEntity" />.
    /// </summary>
    /// <param name="name">
    ///     <para>
    ///         [DEPRECATED] [REQUIRED] When inherited by <a href="https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialrpentity">PublicKeyCredentialRpEntity</a> it is a <a href="https://www.w3.org/TR/webauthn-3/#human-palatability">human-palatable</a> identifier for the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a>, intended only for display.
    ///     </para>
    ///     <para>
    ///         This member is deprecated because many <a href="https://www.w3.org/TR/webauthn-3/#client">clients</a> do not display it, but it remains a required dictionary member for backwards compatibility.
    ///         <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Parties</a> MAY, as a safe default, set this equal to the <a href="https://www.w3.org/TR/webauthn-3/#rp-id">RP ID</a>.
    ///     </para>
    ///     <para>
    ///         When storing a <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialentity-name">"name"</a> member’s value, the value MAY be truncated as described in <a href="https://www.w3.org/TR/webauthn-3/#sctn-strings-truncation">"String Truncation"</a> using a size
    ///         limit greater than or equal to 64 bytes.
    ///     </para>
    /// </param>
    /// <param name="id">
    ///     <para>A unique identifier for the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> entity, which sets the <a href="https://www.w3.org/TR/webauthn-3/#rp-id">RP ID</a>.</para>
    ///     <para>
    ///         Specifies the <a href="https://www.w3.org/TR/webauthn-3/#rp-id">RP ID</a> the credential should be scoped to. If omitted, its value will be the <a href="https://www.w3.org/TR/credential-management-1/#credentialscontainer">CredentialsContainer</a> object’s
    ///         <a href="https://html.spec.whatwg.org/multipage/webappapis.html#relevant-settings-object">relevant settings object’s</a> <a href="https://html.spec.whatwg.org/multipage/webappapis.html#concept-settings-object-origin">origin’s</a>
    ///         <a href="https://html.spec.whatwg.org/multipage/browsers.html#concept-origin-effective-domain">effective domain</a>.
    ///     </para>
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="name" /> is <see langword="null" /></exception>
    public PublicKeyCredentialRpEntity(string name, string? id)
    {
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        Id = id;
    }

    /// <summary>
    ///     <para>
    ///         [DEPRECATED] [REQUIRED] When inherited by <a href="https://www.w3.org/TR/webauthn-3/#dictdef-publickeycredentialrpentity">PublicKeyCredentialRpEntity</a> it is a <a href="https://www.w3.org/TR/webauthn-3/#human-palatability">human-palatable</a> identifier for the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a>, intended only for display.
    ///     </para>
    ///     <para>
    ///         This member is deprecated because many <a href="https://www.w3.org/TR/webauthn-3/#client">clients</a> do not display it, but it remains a required dictionary member for backwards compatibility.
    ///         <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Parties</a> MAY, as a safe default, set this equal to the <a href="https://www.w3.org/TR/webauthn-3/#rp-id">RP ID</a>.
    ///     </para>
    ///     <para>
    ///         When storing a <a href="https://www.w3.org/TR/webauthn-3/#dom-publickeycredentialentity-name">"name"</a> member’s value, the value MAY be truncated as described in <a href="https://www.w3.org/TR/webauthn-3/#sctn-strings-truncation">"String Truncation"</a> using a size
    ///         limit greater than or equal to 64 bytes.
    ///     </para>
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     <para>A unique identifier for the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> entity, which sets the <a href="https://www.w3.org/TR/webauthn-3/#rp-id">RP ID</a>.</para>
    ///     <para>
    ///         Specifies the <a href="https://www.w3.org/TR/webauthn-3/#rp-id">RP ID</a> the credential should be scoped to. If omitted, its value will be the <a href="https://www.w3.org/TR/credential-management-1/#credentialscontainer">CredentialsContainer</a> object’s
    ///         <a href="https://html.spec.whatwg.org/multipage/webappapis.html#relevant-settings-object">relevant settings object’s</a> <a href="https://html.spec.whatwg.org/multipage/webappapis.html#concept-settings-object-origin">origin’s</a>
    ///         <a href="https://html.spec.whatwg.org/multipage/browsers.html#concept-origin-effective-domain">effective domain</a>.
    ///     </para>
    /// </summary>
    public string? Id { get; }
}

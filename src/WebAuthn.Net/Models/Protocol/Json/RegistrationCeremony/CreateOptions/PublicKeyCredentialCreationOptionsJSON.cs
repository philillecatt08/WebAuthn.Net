using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebAuthn.Net.Models.Protocol.Json.RegistrationCeremony.CreateOptions;

/// <summary>
///     Options for Credential Creation (dictionary PublicKeyCredentialCreationOptions)
/// </summary>
/// <remarks>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#dictionary-makecredentialoptions">Web Authentication: An API for accessing Public Key Credentials Level 3 - Options for Credential Creation (dictionary PublicKeyCredentialCreationOptions)</a>
///     </para>
///     <para>
///         <a href="https://www.w3.org/TR/webauthn-3/#sctn-parseCreationOptionsFromJSON">Web Authentication: An API for accessing Public Key Credentials Level 3 - Deserialize Registration ceremony options - PublicKeyCredential’s parseCreationOptionsFromJSON() Method</a>
///     </para>
/// </remarks>
// ReSharper disable once InconsistentNaming
public class PublicKeyCredentialCreationOptionsJSON
{
    /// <summary>
    ///     Constructs <see cref="PublicKeyCredentialCreationOptionsJSON" />.
    /// </summary>
    /// <param name="rp">This member contains a name and an identifier for the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> responsible for the request.</param>
    /// <param name="user">This member contains names and an identifier for the <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a> performing the <a href="https://www.w3.org/TR/webauthn-3/#registration">registration</a>.</param>
    /// <param name="challenge">
    ///     This member specifies a challenge that the <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> signs, along with other data, when producing an <a href="https://www.w3.org/TR/webauthn-3/#attestation-object">attestation object</a>
    ///     for the newly created credential. See the <a href="https://www.w3.org/TR/webauthn-3/#sctn-cryptographic-challenges">"Cryptographic Challenges"</a> security consideration.
    /// </param>
    /// <param name="pubKeyCredParams">
    ///     This member lists the key types and signature algorithms the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> supports, ordered from most preferred to least preferred. Duplicates are allowed but effectively ignored. The
    ///     <a href="https://www.w3.org/TR/webauthn-3/#client">client</a> and <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> make a best-effort to create a credential of the most preferred type possible. If none of the listed types can be created, the
    ///     <a href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-create">create()</a> operation fails.
    /// </param>
    /// <param name="timeout">
    ///     This OPTIONAL member specifies a time, in milliseconds, that the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> is willing to wait for the call to complete. This is treated as a hint, and MAY be overridden by the
    ///     <a href="https://www.w3.org/TR/webauthn-3/#client">client</a>.
    /// </param>
    /// <param name="excludeCredentials">
    ///     The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> SHOULD use this OPTIONAL member to list any existing <a href="https://www.w3.org/TR/credential-management-1/#concept-credential">credentials</a> mapped to this
    ///     <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a> (as identified by user.id). This ensures that the new credential is not <a href="https://www.w3.org/TR/webauthn-3/#created-on">created on</a> an
    ///     <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> that already <a href="https://www.w3.org/TR/webauthn-3/#contains">contains</a> a credential mapped to this <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a>. If it would be,
    ///     the <a href="https://www.w3.org/TR/webauthn-3/#client">client</a> is requested to instead guide the user to use a different <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a>, or return an error if that fails.
    /// </param>
    /// <param name="authenticatorSelection">
    ///     The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> MAY use this OPTIONAL member to specify capabilities and settings that the <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> MUST or SHOULD satisfy to participate in the
    ///     <a href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-create">create()</a> operation. See
    ///     <a href="https://www.w3.org/TR/webauthn-3/#dictionary-authenticatorSelection">"Authenticator Selection Criteria (dictionary AuthenticatorSelectionCriteria)"</a>.
    /// </param>
    /// <param name="hints">This OPTIONAL member contains zero or more elements from <a href="https://www.w3.org/TR/webauthn-3/#enumdef-publickeycredentialhint">PublicKeyCredentialHint</a> to guide the user agent in interacting with the user.</param>
    /// <param name="attestation">
    ///     The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> MAY use this OPTIONAL member to specify a preference regarding <a href="https://www.w3.org/TR/webauthn-3/#attestation-conveyance">attestation conveyance</a>. Its value
    ///     SHOULD be a member of <a href="https://www.w3.org/TR/webauthn-3/#enumdef-attestationconveyancepreference">AttestationConveyancePreference</a>. <a href="https://www.w3.org/TR/webauthn-3/#client-platform">Client platforms</a> MUST ignore unknown values, treating an unknown
    ///     value as if the <a href="https://infra.spec.whatwg.org/#map-exists">member does not exist</a>.
    /// </param>
    /// <param name="attestationFormats">
    ///     The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> MAY use this OPTIONAL member to specify a preference regarding the <a href="https://www.w3.org/TR/webauthn-3/#attestation">attestation</a> statement format used by
    ///     the <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a>. Values SHOULD be taken from the <a href="https://www.iana.org/assignments/webauthn/">IANA "WebAuthn Attestation Statement Format Identifiers" registry</a> established by
    ///     <a href="https://www.rfc-editor.org/rfc/rfc8809">RFC8809</a>. Values are ordered from most preferred to least preferred. Duplicates are allowed but effectively ignored. This parameter is advisory and the
    ///     <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> MAY use an attestation statement not enumerated in this parameter.
    /// </param>
    /// <param name="extensions">
    ///     <para>
    ///         The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> MAY use this OPTIONAL member to provide <a href="https://www.w3.org/TR/webauthn-3/#client-extension-input">client extension inputs</a> requesting additional processing by the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#client">client</a> and <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a>. For example, the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> may request that the client returns
    ///         additional information about the <a href="https://www.w3.org/TR/credential-management-1/#concept-credential">credential</a> that was created.
    ///     </para>
    ///     <para>
    ///         The extensions framework is defined in <a href="https://www.w3.org/TR/webauthn-3/#sctn-extensions">"WebAuthn Extensions"</a>. Some extensions are defined in <a href="https://www.w3.org/TR/webauthn-3/#sctn-defined-extensions">"Defined Extensions"</a>; consult the
    ///         <a href="https://www.iana.org/assignments/webauthn/">IANA "WebAuthn Extension Identifiers" registry</a> established by <a href="https://www.rfc-editor.org/rfc/rfc8809">RFC8809</a> for an up-to-date list of registered
    ///         <a href="https://www.w3.org/TR/webauthn-3/#webauthn-extensions">WebAuthn Extensions</a>.
    ///     </para>
    /// </param>
    public PublicKeyCredentialCreationOptionsJSON(
        PublicKeyCredentialRpEntityJSON rp,
        PublicKeyCredentialUserEntityJSON user,
        string challenge,
        PublicKeyCredentialParametersJSON[] pubKeyCredParams,
        uint? timeout,
        PublicKeyCredentialDescriptorJSON[]? excludeCredentials,
        AuthenticatorSelectionCriteriaJSON? authenticatorSelection,
        string[]? hints,
        string? attestation,
        string[]? attestationFormats,
        Dictionary<string, JsonElement>? extensions)
    {
        Rp = rp;
        User = user;
        Challenge = challenge;
        PubKeyCredParams = pubKeyCredParams;
        Timeout = timeout;
        ExcludeCredentials = excludeCredentials;
        AuthenticatorSelection = authenticatorSelection;
        Hints = hints;
        Attestation = attestation;
        AttestationFormats = attestationFormats;
        Extensions = extensions;
    }

    /// <summary>
    ///     This member contains a name and an identifier for the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> responsible for the request.
    /// </summary>
    [Required]
    [JsonPropertyName("rp")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public PublicKeyCredentialRpEntityJSON Rp { get; }

    /// <summary>
    ///     This member contains names and an identifier for the <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a> performing the <a href="https://www.w3.org/TR/webauthn-3/#registration">registration</a>.
    /// </summary>
    [Required]
    [JsonPropertyName("user")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public PublicKeyCredentialUserEntityJSON User { get; }

    /// <summary>
    ///     This member specifies a challenge that the <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> signs, along with other data, when producing an <a href="https://www.w3.org/TR/webauthn-3/#attestation-object">attestation object</a> for the newly created
    ///     credential. See the <a href="https://www.w3.org/TR/webauthn-3/#sctn-cryptographic-challenges">"Cryptographic Challenges"</a> security consideration.
    /// </summary>
    /// <remarks>
    ///     Base64URLString
    /// </remarks>
    [Required]
    [JsonPropertyName("challenge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string Challenge { get; }

    /// <summary>
    ///     This member lists the key types and signature algorithms the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> supports, ordered from most preferred to least preferred. Duplicates are allowed but effectively ignored. The
    ///     <a href="https://www.w3.org/TR/webauthn-3/#client">client</a> and <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> make a best-effort to create a credential of the most preferred type possible. If none of the listed types can be created, the
    ///     <a href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-create">create()</a> operation fails.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Parties</a> that wish to support a wide range of <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticators</a> SHOULD include at least the following
    ///         <a href="https://www.w3.org/TR/webauthn-3/#typedefdef-cosealgorithmidentifier">COSEAlgorithmIdentifier</a> values:
    ///         <list type="table">
    ///             <listheader>
    ///                 <term>Id</term>
    ///                 <description>Name</description>
    ///             </listheader>
    ///             <item>
    ///                 <term>-8</term>
    ///                 <description>Ed25519</description>
    ///             </item>
    ///             <item>
    ///                 <term>-7</term>
    ///                 <description>ES256</description>
    ///             </item>
    ///             <item>
    ///                 <term>-257</term>
    ///                 <description>RS256</description>
    ///             </item>
    ///         </list>
    ///     </para>
    ///     <para>Additional signature algorithms can be included as needed.</para>
    /// </remarks>
    [Required]
    [JsonPropertyName("pubKeyCredParams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public PublicKeyCredentialParametersJSON[] PubKeyCredParams { get; }

    /// <summary>
    ///     This OPTIONAL member specifies a time, in milliseconds, that the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> is willing to wait for the call to complete. This is treated as a hint, and MAY be overridden by the
    ///     <a href="https://www.w3.org/TR/webauthn-3/#client">client</a>.
    /// </summary>
    [JsonPropertyName("timeout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public uint? Timeout { get; }

    /// <summary>
    ///     The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> SHOULD use this OPTIONAL member to list any existing <a href="https://www.w3.org/TR/credential-management-1/#concept-credential">credentials</a> mapped to this
    ///     <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a> (as identified by user.id). This ensures that the new credential is not <a href="https://www.w3.org/TR/webauthn-3/#created-on">created on</a> an
    ///     <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> that already <a href="https://www.w3.org/TR/webauthn-3/#contains">contains</a> a credential mapped to this <a href="https://www.w3.org/TR/webauthn-3/#user-account">user account</a>. If it would be,
    ///     the <a href="https://www.w3.org/TR/webauthn-3/#client">client</a> is requested to instead guide the user to use a different <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a>, or return an error if that fails.
    /// </summary>
    /// <remarks>
    ///     defaulting to []
    /// </remarks>
    [JsonPropertyName("excludeCredentials")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public PublicKeyCredentialDescriptorJSON[]? ExcludeCredentials { get; }

    /// <summary>
    ///     The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> MAY use this OPTIONAL member to specify capabilities and settings that the <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> MUST or SHOULD satisfy to participate in the
    ///     <a href="https://www.w3.org/TR/credential-management-1/#dom-credentialscontainer-create">create()</a> operation. See
    ///     <a href="https://www.w3.org/TR/webauthn-3/#dictionary-authenticatorSelection">"Authenticator Selection Criteria (dictionary AuthenticatorSelectionCriteria)"</a>.
    /// </summary>
    [JsonPropertyName("authenticatorSelection")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public AuthenticatorSelectionCriteriaJSON? AuthenticatorSelection { get; }

    /// <summary>
    ///     This OPTIONAL member contains zero or more elements from <a href="https://www.w3.org/TR/webauthn-3/#enumdef-publickeycredentialhint">PublicKeyCredentialHint</a> to guide the user agent in interacting with the user.
    /// </summary>
    /// <remarks>
    ///     defaulting to []
    /// </remarks>
    [JsonPropertyName("hints")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string[]? Hints { get; }

    /// <summary>
    ///     The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> MAY use this OPTIONAL member to specify a preference regarding <a href="https://www.w3.org/TR/webauthn-3/#attestation-conveyance">attestation conveyance</a>. Its value SHOULD be a member of
    ///     <a href="https://www.w3.org/TR/webauthn-3/#enumdef-attestationconveyancepreference">AttestationConveyancePreference</a>. <a href="https://www.w3.org/TR/webauthn-3/#client-platform">Client platforms</a> MUST ignore unknown values, treating an unknown value as if the
    ///     <a href="https://infra.spec.whatwg.org/#map-exists">member does not exist</a>.
    /// </summary>
    /// <remarks>
    ///     defaulting to <a href="https://www.w3.org/TR/webauthn-3/#dom-attestationconveyancepreference-none">"none"</a>
    /// </remarks>
    [JsonPropertyName("attestation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Attestation { get; }

    /// <summary>
    ///     The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> MAY use this OPTIONAL member to specify a preference regarding the <a href="https://www.w3.org/TR/webauthn-3/#attestation">attestation</a> statement format used by the
    ///     <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a>. Values SHOULD be taken from the <a href="https://www.iana.org/assignments/webauthn/">IANA "WebAuthn Attestation Statement Format Identifiers" registry</a> established by
    ///     <a href="https://www.rfc-editor.org/rfc/rfc8809">RFC8809</a>. Values are ordered from most preferred to least preferred. Duplicates are allowed but effectively ignored. This parameter is advisory and the
    ///     <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a> MAY use an attestation statement not enumerated in this parameter.
    /// </summary>
    /// <remarks>
    ///     defaulting to []
    /// </remarks>
    [JsonPropertyName("attestationFormats")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string[]? AttestationFormats { get; }

    /// <summary>
    ///     <para>
    ///         The <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> MAY use this OPTIONAL member to provide <a href="https://www.w3.org/TR/webauthn-3/#client-extension-input">client extension inputs</a> requesting additional processing by the
    ///         <a href="https://www.w3.org/TR/webauthn-3/#client">client</a> and <a href="https://www.w3.org/TR/webauthn-3/#authenticator">authenticator</a>. For example, the <a href="https://www.w3.org/TR/webauthn-3/#relying-party">Relying Party</a> may request that the client returns
    ///         additional information about the <a href="https://www.w3.org/TR/credential-management-1/#concept-credential">credential</a> that was created.
    ///     </para>
    ///     <para>
    ///         The extensions framework is defined in <a href="https://www.w3.org/TR/webauthn-3/#sctn-extensions">"WebAuthn Extensions"</a>. Some extensions are defined in <a href="https://www.w3.org/TR/webauthn-3/#sctn-defined-extensions">"Defined Extensions"</a>; consult the
    ///         <a href="https://www.iana.org/assignments/webauthn/">IANA "WebAuthn Extension Identifiers" registry</a> established by <a href="https://www.rfc-editor.org/rfc/rfc8809">RFC8809</a> for an up-to-date list of registered
    ///         <a href="https://www.w3.org/TR/webauthn-3/#webauthn-extensions">WebAuthn Extensions</a>.
    ///     </para>
    /// </summary>
    [JsonPropertyName("extensions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Dictionary<string, JsonElement>? Extensions { get; }
}

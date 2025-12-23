using System;
using WebAuthn.Net.Services.AuthenticationCeremony.Models.CreateOptions.Enums;

namespace WebAuthn.Net.Services.AuthenticationCeremony.Models.VerifyAssertion;

/// <summary>
///     Result of successful completion of the authentication ceremony
/// </summary>
public class CompleteAuthenticationCeremonyResult
{
    /// <summary>
    ///     Constructs <see cref="CompleteAuthenticationCeremonyResult" />.
    /// </summary>
    /// <param name="recommendedActions">Actions recommended to be taken following a successful authentication ceremony, depending on the credential backup state.</param>
    /// <param name="userVerificationFlagMayBeUpdatedToTrue">
    ///     <para>
    ///         A flag referring to the <a href="https://www.w3.org/TR/webauthn-3/#authn-ceremony-update-credential-record">step of the authentication ceremony</a>: "If credentialRecord.uvInitialized is <see langword="false" />, update it to the value of the UV bit in the flags in
    ///         authData. This change SHOULD require authorization by an additional authentication factor equivalent to WebAuthn user verification; if not authorized, skip this step".
    ///     </para>
    ///     <para>
    ///         If the property contains <see langword="true" />, this means that during the authentication ceremony, it was established that the current stored value of credentialRecord.uvInitialized is <see langword="false" />, but the authenticator's response reported it has become
    ///         <see langword="true" />. According to the specification: "if not authorized, skip this step", therefore the library does NOT perform the updating of this specific credentialRecord property. If you need this step, implement it yourself.
    ///     </para>
    /// </param>
    /// <param name="userHandle">Identifier of the user account.</param>
    /// <exception cref="ArgumentNullException">Any of the parameters is <see langword="null" /></exception>
    public CompleteAuthenticationCeremonyResult(
        CredentialBackupStateRecommendedAction[] recommendedActions,
        bool userVerificationFlagMayBeUpdatedToTrue,
        byte[] userHandle)
    {
        ArgumentNullException.ThrowIfNull(recommendedActions);
        ArgumentNullException.ThrowIfNull(userHandle);
        RecommendedActions = recommendedActions;
        UserVerificationFlagMayBeUpdatedToTrue = userVerificationFlagMayBeUpdatedToTrue;
        UserHandle = userHandle;
    }

    /// <summary>
    ///     Actions recommended to be taken following a successful authentication ceremony, depending on the credential backup state.
    /// </summary>
    public CredentialBackupStateRecommendedAction[] RecommendedActions { get; }

    /// <summary>
    ///     <para>
    ///         A flag referring to the <a href="https://www.w3.org/TR/webauthn-3/#authn-ceremony-update-credential-record">step of the authentication ceremony</a>: "If credentialRecord.uvInitialized is <see langword="false" />, update it to the value of the UV bit in the flags in
    ///         authData. This change SHOULD require authorization by an additional authentication factor equivalent to WebAuthn user verification; if not authorized, skip this step".
    ///     </para>
    ///     <para>
    ///         If the property contains <see langword="true" />, this means that during the authentication ceremony, it was established that the current stored value of credentialRecord.uvInitialized is <see langword="false" />, but the authenticator's response reported it has become
    ///         <see langword="true" />. According to the specification: "if not authorized, skip this step", therefore the library does NOT perform the updating of this specific credentialRecord property. If you need this step, implement it yourself.
    ///     </para>
    /// </summary>
    public bool UserVerificationFlagMayBeUpdatedToTrue { get; }

    /// <summary>
    ///     Identifier of the user account.
    /// </summary>
    public byte[] UserHandle { get; }
}

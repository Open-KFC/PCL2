Imports System.Reflection
Imports PCL.Core.Network
Imports PCL.Core.ProgramSetup

Public Class ModSetup

    ''' <summary>
    ''' 设置的更新号。
    ''' </summary>
    Public Const VersionSetup As Integer = SetupModel.VersionCode
    ''' <summary>
    ''' 设置列表。
    ''' </summary>
    Private ReadOnly SetupDict As New Dictionary(Of String, SetupEntry) From {
        {"Identify", New SetupEntry(SetupEntrySource.SystemGlobal, "Identify", "")},
        {"WindowHeight", New SetupEntry(SetupEntrySource.PathLocal, "WindowHeight", 550)},
        {"WindowWidth", New SetupEntry(SetupEntrySource.PathLocal, "WindowWidth", 900)},
        {"HintDownloadThread", New SetupEntry(SetupEntrySource.SystemGlobal, "HintDownloadThread", False)},
        {"HintNotice", New SetupEntry(SetupEntrySource.SystemGlobal, "HintNotice", 0)},
        {"HintDownload", New SetupEntry(SetupEntrySource.SystemGlobal, "HintDownload", 0)},
        {"HintInstallBack", New SetupEntry(SetupEntrySource.SystemGlobal, "HintInstallBack", False)},
        {"HintHide", New SetupEntry(SetupEntrySource.SystemGlobal, "HintHide", False)},
        {"HintHandInstall", New SetupEntry(SetupEntrySource.SystemGlobal, "HintHandInstall", False)},
        {"HintBuy", New SetupEntry(SetupEntrySource.SystemGlobal, "HintBuy", False)},
        {"HintClearRubbish", New SetupEntry(SetupEntrySource.SystemGlobal, "HintClearRubbish", 0)},
        {"HintUpdateMod", New SetupEntry(SetupEntrySource.SystemGlobal, "HintUpdateMod", False)},
        {"HintCustomCommand", New SetupEntry(SetupEntrySource.SystemGlobal, "HintCustomCommand", False)},
        {"HintCustomWarn", New SetupEntry(SetupEntrySource.SystemGlobal, "HintCustomWarn", False)},
        {"HintMoreAdvancedSetup", New SetupEntry(SetupEntrySource.SystemGlobal, "HintMoreAdvancedSetup", False)},
        {"HintIndieSetup", New SetupEntry(SetupEntrySource.SystemGlobal, "HintIndieSetup", False)},
        {"HintProfileSelect", New SetupEntry(SetupEntrySource.SystemGlobal, "HintProfileSelect", False)},
        {"HintExportConfig", New SetupEntry(SetupEntrySource.SystemGlobal, "HintExportConfig", False)},
        {"HintMaxLog", New SetupEntry(SetupEntrySource.SystemGlobal, "HintMaxLog", False)},
        {"HintDisableGamePathCheckTip", New SetupEntry(SetupEntrySource.SystemGlobal, "HintDisableGamePathCheckTip", False)},
        {"SystemEula", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemEula", False)},
        {"SystemCount", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemCount", 0, isEncrypted:=true)},
        {"SystemLaunchCount", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemLaunchCount", 0, isEncrypted:=True)},
        {"SystemLastVersionReg", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemLastVersionReg", 0, isEncrypted:=True)},
        {"SystemHighestSavedBetaVersionReg", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemHighestSavedBetaVersionReg", 0, isEncrypted:=True)},
        {"SystemHighestBetaVersionReg", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemHighestBetaVersionReg", 0, isEncrypted:=True)},
        {"SystemHighestAlphaVersionReg", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemHighestAlphaVersionReg", 0, isEncrypted:=True)},
        {"SystemSetupVersionReg", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemSetupVersionReg", VersionSetup)},
        {"SystemSetupVersionIni", New SetupEntry(SetupEntrySource.PathLocal, "SystemSetupVersionIni", VersionSetup)},
        {"SystemDebugMode", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemDebugMode", False)},
        {"SystemDebugAnim", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemDebugAnim", 9)},
        {"SystemDebugDelay", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemDebugDelay", False)},
        {"SystemDebugSkipCopy", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemDebugSkipCopy", False)},
        {"SystemSystemCache", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemSystemCache", "")},
        {"SystemSystemUpdate", New SetupEntry(SetupEntrySource.PathLocal, "SystemSystemUpdate", 0)},
        {"SystemSystemUpdateBranch", New SetupEntry(SetupEntrySource.PathLocal, "SystemSystemUpdateBranch", If(VersionBaseName.Contains("beta"), 1, 0))},
        {"SystemSystemActivity", New SetupEntry(SetupEntrySource.PathLocal, "SystemSystemActivity", 0)},
        {"SystemSystemAnnouncement", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemSystemAnnouncement", "")},
        {"SystemHttpProxy", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemHttpProxy", "", isEncrypted:=True)},
        {"SystemUseDefaultProxy", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemUseDefaultProxy", True)},
        {"SystemDisableHardwareAcceleration", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemDisableHardwareAcceleration", False)},
        {"SystemTelemetry", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemTelemetry", False)},
        {"SystemMirrorChyanKey", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemMirrorChyanKey", "", isEncrypted:=True)},
        {"SystemMaxLog", New SetupEntry(SetupEntrySource.SystemGlobal, "SystemMaxLog", 13)},
        {"CacheExportConfig", New SetupEntry(SetupEntrySource.SystemGlobal, "CacheExportConfig", "")},
        {"CacheSavedPageUrl", New SetupEntry(SetupEntrySource.SystemGlobal, "CacheSavedPageUrl", "")},
        {"CacheSavedPageInstance", New SetupEntry(SetupEntrySource.SystemGlobal, "CacheSavedPageInstance", "")},
        {"CacheDownloadFolder", New SetupEntry(SetupEntrySource.SystemGlobal, "CacheDownloadFolder", "")},
        {"ToolDownloadCustomUserAgent", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadCustomUserAgent", "")},
        {"CacheJavaListVersion", New SetupEntry(SetupEntrySource.SystemGlobal, "CacheJavaListVersion", 0)},
        {"CacheAuthUuid", New SetupEntry(SetupEntrySource.SystemGlobal, "CacheAuthUuid", "", isEncrypted:=True)},
        {"CacheAuthName", New SetupEntry(SetupEntrySource.SystemGlobal, "CacheAuthName", "", isEncrypted:=True)},
        {"CacheAuthUsername", New SetupEntry(SetupEntrySource.SystemGlobal, "CacheAuthUsername", "", isEncrypted:=True)},
        {"CacheAuthPass", New SetupEntry(SetupEntrySource.SystemGlobal, "CacheAuthPass", "", isEncrypted:=True)},
        {"CacheAuthServerServer", New SetupEntry(SetupEntrySource.SystemGlobal, "CacheAuthServerServer", "", isEncrypted:=True)},
        {"CompFavorites", New SetupEntry(SetupEntrySource.SystemGlobal, "CompFavorites", "[]")},
        {"LaunchInstanceSelect", New SetupEntry(SetupEntrySource.PathLocal, "LaunchInstanceSelect", "")},
        {"LaunchFolderSelect", New SetupEntry(SetupEntrySource.PathLocal, "LaunchFolderSelect", "")},
        {"LaunchFolders", New SetupEntry(SetupEntrySource.SystemGlobal, "LaunchFolders", "")},
        {"LaunchArgumentTitle", New SetupEntry(SetupEntrySource.PathLocal, "LaunchArgumentTitle", "")},
        {"LaunchArgumentInfo", New SetupEntry(SetupEntrySource.PathLocal, "LaunchArgumentInfo", "PCL")},
        {"LaunchArgumentJavaSelect", New SetupEntry(SetupEntrySource.SystemGlobal, "LaunchArgumentJavaSelect", "")},
        {"LaunchArgumentJavaUser", New SetupEntry(SetupEntrySource.SystemGlobal, "LaunchArgumentJavaUser", "[]")},
        {"LaunchArgumentIndie", New SetupEntry(SetupEntrySource.PathLocal, "LaunchArgumentIndie", 0)},
        {"LaunchArgumentIndieV2", New SetupEntry(SetupEntrySource.PathLocal, "LaunchArgumentIndieV2", 4)},
        {"LaunchArgumentVisible", New SetupEntry(SetupEntrySource.SystemGlobal, "LaunchArgumentVisible", 5)},
        {"LaunchArgumentPriority", New SetupEntry(SetupEntrySource.SystemGlobal, "LaunchArgumentPriority", 1)},
        {"LaunchArgumentWindowWidth", New SetupEntry(SetupEntrySource.PathLocal, "LaunchArgumentWindowWidth", 854)},
        {"LaunchArgumentWindowHeight", New SetupEntry(SetupEntrySource.PathLocal, "LaunchArgumentWindowHeight", 480)},
        {"LaunchArgumentWindowType", New SetupEntry(SetupEntrySource.PathLocal, "LaunchArgumentWindowType", 1)},
        {"LaunchPreferredIpStack", New SetupEntry(SetupEntrySource.SystemGlobal, "LaunchPreferredIpStack", 1)},
        {"LaunchArgumentRam", New SetupEntry(SetupEntrySource.SystemGlobal, "LaunchArgumentRam", False)},
        {"LaunchAdvanceJvm", New SetupEntry(SetupEntrySource.PathLocal, "LaunchAdvanceJvm", "-XX:+UseG1GC -XX:-UseAdaptiveSizePolicy -XX:-OmitStackTraceInFastThrow -Djdk.lang.Process.allowAmbiguousCommands=true -Dfml.ignoreInvalidMinecraftCertificates=True -Dfml.ignorePatchDiscrepancies=True -Dlog4j2.formatMsgNoLookups=true")},
        {"LaunchAdvanceGame", New SetupEntry(SetupEntrySource.PathLocal, "LaunchAdvanceGame", "")},
        {"LaunchAdvanceRun", New SetupEntry(SetupEntrySource.PathLocal, "LaunchAdvanceRun", "")},
        {"LaunchAdvanceRunWait", New SetupEntry(SetupEntrySource.PathLocal, "LaunchAdvanceRunWait", True)},
        {"LaunchAdvanceDisableJLW", New SetupEntry(SetupEntrySource.PathLocal, "LaunchAdvanceDisableJLW", False)},
        {"LaunchAdvanceDisableRW", New SetupEntry(SetupEntrySource.PathLocal, "LaunchAdvanceDisableRW", False)},
        {"LaunchAdvanceGraphicCard", New SetupEntry(SetupEntrySource.SystemGlobal, "LaunchAdvanceGraphicCard", True)},
        {"LaunchAdvanceNoJavaw", New SetupEntry(SetupEntrySource.SystemGlobal, "LaunchAdvanceNoJavaw", False)},
        {"LaunchRamType", New SetupEntry(SetupEntrySource.PathLocal, "LaunchRamType", 0)},
        {"LaunchRamCustom", New SetupEntry(SetupEntrySource.PathLocal, "LaunchRamCustom", 15)},
        {"LaunchUuid", New SetupEntry(SetupEntrySource.SystemGlobal, "LaunchUuid", String.Empty)},
        {"ToolFixAuthlib", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolFixAuthlib", True)},
        {"LinkEula", New SetupEntry(SetupEntrySource.SystemGlobal, "LinkEula", False)},
        {"LinkAnnounceCache", New SetupEntry(SetupEntrySource.SystemGlobal, "LinkAnnounceCache", "", isEncrypted:=True)},
        {"LinkAnnounceCacheVer", New SetupEntry(SetupEntrySource.SystemGlobal, "LinkAnnounceCacheVer", 0)},
        {"LinkRelayType", New SetupEntry(SetupEntrySource.SystemGlobal, "LinkRelayType", 0)},
        {"LinkServerType", New SetupEntry(SetupEntrySource.SystemGlobal, "LinkServerType", 1)},
        {"LinkProxyType", New SetupEntry(SetupEntrySource.SystemGlobal, "LinkProxyType", 1)},
        {"LinkRelayServer", New SetupEntry(SetupEntrySource.SystemGlobal, "LinkRelayServer", "")},
        {"LinkNaidRefreshToken", New SetupEntry(SetupEntrySource.SystemGlobal, "LinkNaidRefreshToken", "", isEncrypted:=True)},
        {"LinkNaidRefreshExpiresAt", New SetupEntry(SetupEntrySource.SystemGlobal, "LinkNaidRefreshExpiresAt", "", isEncrypted:=True)},
        {"LinkFirstTimeNetTest", New SetupEntry(SetupEntrySource.SystemGlobal, "LinkFirstTimeNetTest", True)},
        {"LoginLegacyName", New SetupEntry(SetupEntrySource.SystemGlobal, "LoginLegacyName", "", isEncrypted:=True)},
        {"LoginMsJson", New SetupEntry(SetupEntrySource.SystemGlobal, "LoginMsJson", "{}", isEncrypted:=True)}, '{UserName: OAuthToken, ...}
        {"LoginMsAuthType", New SetupEntry(SetupEntrySource.SystemGlobal, "LoginMsAuthType", 1)},
        {"ToolHelpChinese", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolHelpChinese", True)},
        {"ToolDownloadThread", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadThread", 63)},
        {"ToolDownloadSpeed", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadSpeed", 42)},
        {"ToolDownloadSource", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadSource", 1)},
        {"ToolDownloadVersion", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadVersion", 1)},
        {"ToolDownloadTranslate", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadTranslate", 0)},
        {"ToolDownloadTranslateV2", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadTranslateV2", 1)},
        {"ToolDownloadIgnoreQuilt", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadIgnoreQuilt", True)},
        {"ToolDownloadClipboard", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadClipboard", False)},
        {"ToolDownloadCert", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadCert", True)},
        {"ToolDownloadMod", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadMod", 1)},
        {"ToolModLocalNameStyle", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolModLocalNameStyle", 0)},
        {"ToolUpdateAlpha", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolUpdateAlpha", 0, isEncrypted:=True)},
        {"ToolUpdateRelease", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolUpdateRelease", False)},
        {"ToolUpdateSnapshot", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolUpdateSnapshot", False)},
        {"ToolUpdateReleaseLast", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolUpdateReleaseLast", "")},
        {"ToolUpdateSnapshotLast", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolUpdateSnapshotLast", "")},
        {"ToolDownloadAutoSelectVersion", New SetupEntry(SetupEntrySource.SystemGlobal, "ToolDownloadAutoSelectVersion", True)},
        {"UiLauncherTransparent", New SetupEntry(SetupEntrySource.PathLocal, "UiLauncherTransparent", 600)}, '避免与 PCL1 设置冲突（UiLauncherOpacity）
        {"UiLauncherHue", New SetupEntry(SetupEntrySource.PathLocal, "UiLauncherHue", 180)},
        {"UiLauncherSat", New SetupEntry(SetupEntrySource.PathLocal, "UiLauncherSat", 80)},
        {"UiLauncherDelta", New SetupEntry(SetupEntrySource.PathLocal, "UiLauncherDelta", 90)},
        {"UiLauncherLight", New SetupEntry(SetupEntrySource.PathLocal, "UiLauncherLight", 20)},
        {"UiLauncherTheme", New SetupEntry(SetupEntrySource.PathLocal, "UiLauncherTheme", 0)},
        {"UiLauncherThemeGold", New SetupEntry(SetupEntrySource.SystemGlobal, "UiLauncherThemeGold", "", isEncrypted:=True)},
        {"UiLauncherThemeHide", New SetupEntry(SetupEntrySource.SystemGlobal, "UiLauncherThemeHide", "0|1|2|3|4", isEncrypted:=True)},
        {"UiLauncherThemeHide2", New SetupEntry(SetupEntrySource.SystemGlobal, "UiLauncherThemeHide2", "0|1|2|3|4", isEncrypted:=True)},
        {"UiLauncherLogo", New SetupEntry(SetupEntrySource.PathLocal, "UiLauncherLogo", True)},
        {"UiLauncherCEHint", New SetupEntry(SetupEntrySource.SystemGlobal, "UiLauncherCEHint", True)},
        {"UiLauncherCEHintCount", New SetupEntry(SetupEntrySource.SystemGlobal, "UiLauncherCEHintCount", 0)},
        {"UiBlur", New SetupEntry(SetupEntrySource.PathLocal, "UiBlur", False)},
        {"UiBlurValue", New SetupEntry(SetupEntrySource.PathLocal, "UiBlurValue", 16)},
        {"UiBackgroundColorful", New SetupEntry(SetupEntrySource.PathLocal, "UiBackgroundColorful", True)},
        {"UiBackgroundOpacity", New SetupEntry(SetupEntrySource.PathLocal, "UiBackgroundOpacity", 1000)},
        {"UiBackgroundBlur", New SetupEntry(SetupEntrySource.PathLocal, "UiBackgroundBlur", 0)},
        {"UiBackgroundSuit", New SetupEntry(SetupEntrySource.PathLocal, "UiBackgroundSuit", 0)},
        {"UiCustomType", New SetupEntry(SetupEntrySource.PathLocal, "UiCustomType", 0)},
        {"UiCustomPreset", New SetupEntry(SetupEntrySource.PathLocal, "UiCustomPreset", 0)},
        {"UiCustomNet", New SetupEntry(SetupEntrySource.PathLocal, "UiCustomNet", "")},
        {"UiDarkMode", New SetupEntry(SetupEntrySource.SystemGlobal, "UiDarkMode", 2)},
        {"UiDarkColor", New SetupEntry(SetupEntrySource.SystemGlobal, "UiDarkColor", 1)},
        {"UiLightColor", New SetupEntry(SetupEntrySource.SystemGlobal, "UiLightColor", 1)},
        {"UiLockWindowSize", New SetupEntry(SetupEntrySource.SystemGlobal, "UiLockWindowSize", False)},
        {"UiLogoType", New SetupEntry(SetupEntrySource.PathLocal, "UiLogoType", 1)},
        {"UiLogoText", New SetupEntry(SetupEntrySource.PathLocal, "UiLogoText", "")},
        {"UiLogoLeft", New SetupEntry(SetupEntrySource.PathLocal, "UiLogoLeft", False)},
        {"UiMusicVolume", New SetupEntry(SetupEntrySource.PathLocal, "UiMusicVolume", 500)},
        {"UiMusicStop", New SetupEntry(SetupEntrySource.PathLocal, "UiMusicStop", False)},
        {"UiMusicStart", New SetupEntry(SetupEntrySource.PathLocal, "UiMusicStart", False)},
        {"UiMusicRandom", New SetupEntry(SetupEntrySource.PathLocal, "UiMusicRandom", True)},
        {"UiMusicSMTC", New SetupEntry(SetupEntrySource.PathLocal, "UiMusicSMTC", True)},
        {"UiMusicAuto", New SetupEntry(SetupEntrySource.PathLocal, "UiMusicAuto", True)},
        {"UiHiddenPageDownload", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenPageDownload", False)},
        {"UiHiddenPageLink", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenPageLink", False)},
        {"UiHiddenPageSetup", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenPageSetup", False)},
        {"UiHiddenPageOther", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenPageOther", False)},
        {"UiHiddenFunctionSelect", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenFunctionSelect", False)},
        {"UiHiddenFunctionModUpdate", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenFunctionModUpdate", False)},
        {"UiHiddenFunctionHidden", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenFunctionHidden", False)},
        {"UiHiddenSetupLaunch", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenSetupLaunch", False)},
        {"UiHiddenSetupUi", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenSetupUi", False)},
        {"UiHiddenSetupSystem", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenSetupSystem", False)},
        {"UiHiddenOtherHelp", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenOtherHelp", False)},
        {"UiHiddenOtherFeedback", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenOtherFeedback", False)},
        {"UiHiddenOtherVote", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenOtherVote", False)},
        {"UiHiddenOtherAbout", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenOtherAbout", False)},
        {"UiHiddenOtherTest", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenOtherTest", False)},
        {"UiHiddenVersionEdit", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenVersionEdit", False)},
        {"UiHiddenVersionExport", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenVersionExport", False)},
        {"UiHiddenVersionSave", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenVersionSave", False)},
        {"UiHiddenVersionScreenshot", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenVersionScreenshot", False)},
        {"UiHiddenVersionMod", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenVersionMod", False)},
        {"UiHiddenVersionResourcePack", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenVersionResourcePack", False)},
        {"UiHiddenVersionShader", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenVersionShader", False)},
        {"UiHiddenVersionSchematic", New SetupEntry(SetupEntrySource.PathLocal, "UiHiddenVersionSchematic", False)},
        {"UiSchematicFirstTimeHintShown", New SetupEntry(SetupEntrySource.SystemGlobal, "UiSchematicFirstTimeHintShown", False)},
        {"UiAniFPS", New SetupEntry(SetupEntrySource.SystemGlobal, "UiAniFPS", 59)},
        {"UiFont", New SetupEntry(SetupEntrySource.PathLocal, "UiFont", "")},
        {"VersionAdvanceJvm", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceJvm", "")},
        {"VersionAdvanceGame", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceGame", "")},
        {"VersionAdvanceAssets", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceAssets", 0)},
        {"VersionAdvanceAssetsV2", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceAssetsV2", False)},
        {"VersionAdvanceJava", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceJava", False)},
        {"VersionAdvanceDisableJlw", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceDisableJlw", False)},
        {"VersionAdvanceRun", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceRun", "")},
        {"VersionAdvanceRunWait", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceRunWait", True)},
        {"VersionAdvanceDisableJLW", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceDisableJLW", False)},
        {"VersionAdvanceUseProxyV2", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceUseProxyV2", False)},
        {"VersionAdvanceDisableRW", New SetupEntry(SetupEntrySource.GameInstance, "VersionAdvanceDisableRW", False)},
        {"VersionRamType", New SetupEntry(SetupEntrySource.GameInstance, "VersionRamType", 2)},
        {"VersionRamCustom", New SetupEntry(SetupEntrySource.GameInstance, "VersionRamCustom", 15)},
        {"VersionRamOptimize", New SetupEntry(SetupEntrySource.GameInstance, "VersionRamOptimize", 0)},
        {"VersionArgumentTitle", New SetupEntry(SetupEntrySource.GameInstance, "VersionArgumentTitle", "")},
        {"VersionArgumentTitleEmpty", New SetupEntry(SetupEntrySource.GameInstance, "VersionArgumentTitleEmpty", False)},
        {"VersionArgumentInfo", New SetupEntry(SetupEntrySource.GameInstance, "VersionArgumentInfo", "")},
        {"VersionArgumentIndie", New SetupEntry(SetupEntrySource.GameInstance, "VersionArgumentIndie", -1)},
        {"VersionArgumentIndieV2", New SetupEntry(SetupEntrySource.GameInstance, "VersionArgumentIndieV2", False)},
        {"VersionArgumentJavaSelect", New SetupEntry(SetupEntrySource.GameInstance, "VersionArgumentJavaSelect", "使用全局设置")},
        {"VersionServerEnter", New SetupEntry(SetupEntrySource.GameInstance, "VersionServerEnter", "")},
        {"VersionServerLoginRequire", New SetupEntry(SetupEntrySource.GameInstance, "VersionServerLoginRequire", 0)},
        {"VersionServerAuthRegister", New SetupEntry(SetupEntrySource.GameInstance, "VersionServerAuthRegister", "")},
        {"VersionServerAuthName", New SetupEntry(SetupEntrySource.GameInstance, "VersionServerAuthName", "")},
        {"VersionServerAuthServer", New SetupEntry(SetupEntrySource.GameInstance, "VersionServerAuthServer", "")},
        {"VersionServerLoginLock", New SetupEntry(SetupEntrySource.GameInstance, "VersionServerLoginLock", False)},
        {"VersionLaunchCount", New SetupEntry(SetupEntrySource.GameInstance, "VersionLaunchCount", 0)},
        {"IsStar", new SetupEntry(SetupEntrySource.GameInstance, "IsStar", False)},
        {"DisplayType", new SetupEntry(SetupEntrySource.GameInstance, "DisplayType", 0)},
        {"Logo", new SetupEntry(SetupEntrySource.GameInstance, "Logo", "")},
        {"LogoCustom", new SetupEntry(SetupEntrySource.GameInstance, "LogoCustom", False)},
        {"CustomInfo", new SetupEntry(SetupEntrySource.GameInstance, "CustomInfo", "")},
        {"Info", new SetupEntry(SetupEntrySource.GameInstance, "Info", "")},
        {"ReleaseTime", new SetupEntry(SetupEntrySource.GameInstance, "ReleaseTime", "")},
        {"State", new SetupEntry(SetupEntrySource.GameInstance, "State", 0)},
        {"VersionFabric", new SetupEntry(SetupEntrySource.GameInstance, "VersionFabric", "")},
        {"VersionLegacyFabric", new SetupEntry(SetupEntrySource.GameInstance, "VersionLegacyFabric", "")},
        {"VersionQuilt", new SetupEntry(SetupEntrySource.GameInstance, "VersionQuilt", "")},
        {"VersionLabyMod", new SetupEntry(SetupEntrySource.GameInstance, "VersionLabyMod", "")},
        {"VersionOptiFine", new SetupEntry(SetupEntrySource.GameInstance, "VersionOptiFine", "")},
        {"VersionLiteLoader", new SetupEntry(SetupEntrySource.GameInstance, "VersionLiteLoader", "")},
        {"VersionForge", new SetupEntry(SetupEntrySource.GameInstance, "VersionForge", "")},
        {"VersionNeoForge", new SetupEntry(SetupEntrySource.GameInstance, "VersionNeoForge", "")},
        {"VersionCleanroom", new SetupEntry(SetupEntrySource.GameInstance, "VersionCleanroom", "")},
        {"VersionApiCode", new SetupEntry(SetupEntrySource.GameInstance, "VersionApiCode", 0)},
        {"VersionOriginal", new SetupEntry(SetupEntrySource.GameInstance, "VersionOriginal", "")},
        {"VersionOriginalMain", new SetupEntry(SetupEntrySource.GameInstance, "VersionOriginalMain", 0)},
        {"VersionOriginalSub", new SetupEntry(SetupEntrySource.GameInstance, "VersionOriginalSub", 0)}
    }

#Region "基础"

    Public Sub New()
        AddHandler SetupService.SetupChanged, AddressOf OnSetupChanged
    End Sub

    Private Sub OnSetupChanged(entry As SetupEntry, oldValue As Object, newValue As Object, gamePath As String)
        Dim method As MethodInfo = GetType(ModSetup).GetMethod(entry.KeyName)
        If method IsNot Nothing Then method.Invoke(Me, {If(newValue, entry.DefaultValue)})
    End Sub

    ''' <summary>
    ''' 改变某个设置项的值。
    ''' </summary>
    Public Sub [Set](key As String, value As Object, Optional forceReload As Boolean = False, Optional instance As McInstance = Nothing)
        Dim entry As SetupEntry = SetupDict(key)
        Dim type As Type = entry.DefaultValue.GetType()
        If type = GetType(Boolean) Then
            SetupService.SetBool(entry, value, instance?.Path)
        ElseIf type = GetType(Integer) Then
            SetupService.SetInt32(entry, value, instance?.Path)
        ElseIf type = GetType(String) Then
            SetupService.SetString(entry, value, instance?.Path)
        Else
            Throw New NotSupportedException("请让开发者完善配置系统迁移……")
        End If
    End Sub

    ''' <summary>
    ''' 应用某个设置项的值。
    ''' </summary>
    Public Function Load(key As String, Optional forceReload As Boolean = False, Optional instance As McInstance = Nothing)
        Dim entry As SetupEntry = SetupDict(key)
        Dim type As Type = entry.DefaultValue.GetType()
        Dim value
        If type = GetType(Boolean) Then 
            value = SetupService.GetBool(entry, instance?.Path)
        ElseIf type = GetType(Integer) Then 
            value = SetupService.GetInt32(entry, instance?.Path)
        ElseIf type = GetType(String) Then
            value = SetupService.GetString(entry, instance?.Path)
        Else
            Throw New NotSupportedException("请让开发者完善配置系统迁移……")
        End If
#disable Warning BC40000 ' Obsolete
        SetupService.RaiseSetupChanged(SetupDict(key), value, value, instance?.Path)
#enable Warning BC40000
        Return value
    End Function

    ''' <summary>
    ''' 获取某个设置项的值。
    ''' </summary>
    Public Function [Get](key As String, Optional instance As McInstance = Nothing)
        Dim entry As SetupEntry = SetupDict(key)
        Dim type As Type = entry.DefaultValue.GetType()
        If type = GetType(Boolean) Then 
            Return SetupService.GetBool(entry, instance?.Path)
        ElseIf type = GetType(Integer) Then 
            Return SetupService.GetInt32(entry, instance?.Path)
        ElseIf type = GetType(String) Then
            Return SetupService.GetString(entry, instance?.Path)
        Else
            Throw New NotSupportedException("请让开发者完善配置系统迁移……")
        End If
    End Function

    ''' <summary>
    ''' 初始化某个设置项的值。
    ''' </summary>
    Public Sub Reset(key As String, Optional forceReload As Boolean = False, Optional instance As McInstance = Nothing)
        Dim entry As SetupEntry = SetupDict(key)
        Dim type As Type = entry.DefaultValue.GetType()
        If type = GetType(Boolean) Then 
            SetupService.DeleteBool(entry, instance?.Path)
        ElseIf type = GetType(Integer) Then 
            SetupService.DeleteInt32(entry, instance?.Path)
        ElseIf type = GetType(String) Then
            SetupService.DeleteString(entry, instance?.Path)
        Else
            Throw New NotSupportedException("请让开发者完善配置系统迁移……")
        End If
    End Sub

    ''' <summary>
    ''' 获取某个设置项的默认值。
    ''' </summary>
    Public Function GetDefault(key As String)
        Dim entry As SetupEntry = SetupDict(key)
        Return entry.DefaultValue
    End Function

    ''' <summary>
    ''' 某个设置项是否从未被设置过。
    ''' </summary>
    Public Function IsUnset(key As String, Optional instance As McInstance = Nothing) As Boolean
        Dim entry As SetupEntry = SetupDict(key)
        Return SetupService.IsUnset(entry, instance?.Path)
    End Function

#End Region

#Region "Launch"

    '切换选择
    Public Sub LaunchInstanceSelect(Value As String)
        Log("[Setup] 当前选择的 Minecraft 版本：" & Value)
        WriteIni(PathMcFolder & "PCL.ini", "Version", If(IsNothing(McInstanceCurrent), "", McInstanceCurrent.Name))
    End Sub
    Public Sub LaunchFolderSelect(Value As String)
        Log("[Setup] 当前选择的 Minecraft 文件夹：" & Value.ToString.Replace("$", Path))
        PathMcFolder = Value.ToString.Replace("$", Path)
    End Sub

    '游戏内存
    Public Sub LaunchRamType(Type As Integer)
        If FrmSetupLaunch Is Nothing Then Return
        FrmSetupLaunch.RamType(Type)
    End Sub

#End Region

#Region "Tool"

    Public Sub ToolDownloadThread(Value As Integer)
        NetTaskThreadLimit = Value + 1
    End Sub
    Public Sub ToolDownloadCert(Value As Boolean)
        ServicePointManager.ServerCertificateValidationCallback =
        Function(Sender, Certificate, Chain, Failure)
            Dim Request As HttpWebRequest = TryCast(Sender, HttpWebRequest)
            If Failure = Net.Security.SslPolicyErrors.None Then Return True '已通过验证
            '基于 #3018 和 #5879，只在访问正版登录 API 时跳过证书验证
            Log($"[System] 未通过 SSL 证书验证（{Failure}），提供的证书为 {Certificate?.Subject}，URL：{Request?.Address}", LogLevel.Debug)
            If Request Is Nothing Then
                Return Not Value
            ElseIf Request.Address.Host.Contains("xboxlive") OrElse Request.Address.Host.Contains("minecraftservices") Then
                Return Not Value '根据设置决定是否忽略错误
            Else
                Return False
            End If
        End Function
    End Sub
    Public Sub ToolDownloadSpeed(Value As Integer)
        If Value <= 14 Then
            NetTaskSpeedLimitHigh = (Value + 1) * 0.1 * 1024 * 1024L
        ElseIf Value <= 31 Then
            NetTaskSpeedLimitHigh = (Value - 11) * 0.5 * 1024 * 1024L
        ElseIf Value <= 41 Then
            NetTaskSpeedLimitHigh = (Value - 21) * 1024 * 1024L
        Else
            NetTaskSpeedLimitHigh = -1
        End If
    End Sub

#End Region

#Region "UI"

    '启动器
    Public Sub UiLauncherTransparent(Value As Integer)
        FrmMain.Opacity = Value / 1000 + 0.4
    End Sub
    Public Sub UiLauncherTheme(Value As Integer)
        ThemeRefresh(Value)
    End Sub
    Public Sub UiBackgroundColorful(Value As Boolean)
        ThemeRefresh()
    End Sub

    Public Sub UiLockWindowSize(Value As Boolean)
        If Value Then
            FrmMain.RemoveResizer()
        Else
            FrmMain.AddResizer()
        End If
    End Sub

    '背景图片
    Public Sub UiBackgroundOpacity(Value As Integer)
        FrmMain.ImgBack.Opacity = Value / 1000
    End Sub
    Public Sub UiBackgroundBlur(Value As Integer)
        If Value = 0 Then
            FrmMain.ImgBack.Effect = Nothing
        Else
            FrmMain.ImgBack.Effect = New Effects.BlurEffect With {.Radius = Value + 1}
        End If
        FrmMain.ImgBack.Margin = New Thickness(-(Value + 1) / 1.8)
    End Sub
    Public Sub UiBackgroundSuit(Value As Integer)
        If IsNothing(FrmMain.ImgBack.Background) Then Return
        Dim Width As Double = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Width
        Dim Height As Double = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Height
        If Value = 0 Then
            '智能：当图片较小时平铺，较大时适应
            If Width < FrmMain.PanMain.ActualWidth / 2 AndAlso Height < FrmMain.PanMain.ActualHeight / 2 Then
                Value = 4 '平铺
            Else
                Value = 2 '适应
            End If
        End If
        CType(FrmMain.ImgBack.Background, ImageBrush).TileMode = TileMode.None
        CType(FrmMain.ImgBack.Background, ImageBrush).Viewport = New Rect(0, 0, 1, 1)
        CType(FrmMain.ImgBack.Background, ImageBrush).ViewportUnits = BrushMappingMode.RelativeToBoundingBox
        Select Case Value
            Case 1 '居中
                FrmMain.ImgBack.HorizontalAlignment = HorizontalAlignment.Center
                FrmMain.ImgBack.VerticalAlignment = VerticalAlignment.Center
                CType(FrmMain.ImgBack.Background, ImageBrush).Stretch = Stretch.None
                FrmMain.ImgBack.Width = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Width
                FrmMain.ImgBack.Height = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Height
            Case 2 '适应
                FrmMain.ImgBack.HorizontalAlignment = HorizontalAlignment.Stretch
                FrmMain.ImgBack.VerticalAlignment = VerticalAlignment.Stretch
                CType(FrmMain.ImgBack.Background, ImageBrush).Stretch = Stretch.UniformToFill
                FrmMain.ImgBack.Width = Double.NaN
                FrmMain.ImgBack.Height = Double.NaN
            Case 3 '拉伸
                FrmMain.ImgBack.HorizontalAlignment = HorizontalAlignment.Stretch
                FrmMain.ImgBack.VerticalAlignment = VerticalAlignment.Stretch
                CType(FrmMain.ImgBack.Background, ImageBrush).Stretch = Stretch.Fill
                FrmMain.ImgBack.Width = Double.NaN
                FrmMain.ImgBack.Height = Double.NaN
            Case 4 '平铺
                FrmMain.ImgBack.HorizontalAlignment = HorizontalAlignment.Stretch
                FrmMain.ImgBack.VerticalAlignment = VerticalAlignment.Stretch
                CType(FrmMain.ImgBack.Background, ImageBrush).Stretch = Stretch.None
                CType(FrmMain.ImgBack.Background, ImageBrush).TileMode = TileMode.Tile
                CType(FrmMain.ImgBack.Background, ImageBrush).Viewport = New Rect(0, 0, CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Width, CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Height)
                CType(FrmMain.ImgBack.Background, ImageBrush).ViewportUnits = BrushMappingMode.Absolute
                FrmMain.ImgBack.Width = Double.NaN
                FrmMain.ImgBack.Height = Double.NaN
            Case 5 '左上
                FrmMain.ImgBack.HorizontalAlignment = HorizontalAlignment.Left
                FrmMain.ImgBack.VerticalAlignment = VerticalAlignment.Top
                CType(FrmMain.ImgBack.Background, ImageBrush).Stretch = Stretch.None
                FrmMain.ImgBack.Width = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Width
                FrmMain.ImgBack.Height = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Height
            Case 6 '右上
                FrmMain.ImgBack.HorizontalAlignment = HorizontalAlignment.Right
                FrmMain.ImgBack.VerticalAlignment = VerticalAlignment.Top
                CType(FrmMain.ImgBack.Background, ImageBrush).Stretch = Stretch.None
                FrmMain.ImgBack.Width = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Width
                FrmMain.ImgBack.Height = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Height
            Case 7 '左下
                FrmMain.ImgBack.HorizontalAlignment = HorizontalAlignment.Left
                FrmMain.ImgBack.VerticalAlignment = VerticalAlignment.Bottom
                CType(FrmMain.ImgBack.Background, ImageBrush).Stretch = Stretch.None
                FrmMain.ImgBack.Width = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Width
                FrmMain.ImgBack.Height = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Height
            Case 8 '右下
                FrmMain.ImgBack.HorizontalAlignment = HorizontalAlignment.Right
                FrmMain.ImgBack.VerticalAlignment = VerticalAlignment.Bottom
                CType(FrmMain.ImgBack.Background, ImageBrush).Stretch = Stretch.None
                FrmMain.ImgBack.Width = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Width
                FrmMain.ImgBack.Height = CType(FrmMain.ImgBack.Background, ImageBrush).ImageSource.Height
        End Select
    End Sub

    '主页
    Public Sub UiCustomType(Value As Integer)
        If FrmSetupUI Is Nothing Then Return
        Select Case Value
            Case 0 '无
                FrmSetupUI.PanCustomPreset.Visibility = Visibility.Collapsed
                FrmSetupUI.PanCustomLocal.Visibility = Visibility.Collapsed
                FrmSetupUI.PanCustomNet.Visibility = Visibility.Collapsed
                FrmSetupUI.HintCustom.Visibility = Visibility.Collapsed
                FrmSetupUI.HintCustomWarn.Visibility = Visibility.Collapsed
            Case 1 '本地
                FrmSetupUI.PanCustomPreset.Visibility = Visibility.Collapsed
                FrmSetupUI.PanCustomLocal.Visibility = Visibility.Visible
                FrmSetupUI.PanCustomNet.Visibility = Visibility.Collapsed
                FrmSetupUI.HintCustom.Visibility = Visibility.Visible
                FrmSetupUI.HintCustomWarn.Visibility = If(Setup.Get("HintCustomWarn"), Visibility.Collapsed, Visibility.Visible)
                FrmSetupUI.HintCustom.Text = $"从 PCL 文件夹下的 Custom.xaml 读取主页内容。{vbCrLf}你可以手动编辑该文件，向主页添加文本、图片、常用网站、快捷启动等功能。"
                FrmSetupUI.HintCustom.EventType = ""
                FrmSetupUI.HintCustom.EventData = ""
            Case 2 '联网
                FrmSetupUI.PanCustomPreset.Visibility = Visibility.Collapsed
                FrmSetupUI.PanCustomLocal.Visibility = Visibility.Collapsed
                FrmSetupUI.PanCustomNet.Visibility = Visibility.Visible
                FrmSetupUI.HintCustom.Visibility = Visibility.Visible
                FrmSetupUI.HintCustomWarn.Visibility = If(Setup.Get("HintCustomWarn"), Visibility.Collapsed, Visibility.Visible)
                FrmSetupUI.HintCustom.Text = $"从指定网址联网获取主页内容。服主也可以用于动态更新服务器公告。{vbCrLf}如果你制作了稳定运行的联网主页，可以点击这条提示投稿，若合格即可加入预设！"
                FrmSetupUI.HintCustom.EventType = "打开网页"
                FrmSetupUI.HintCustom.EventData = "https://github.com/Meloong-Git/PCL/discussions/2528"
            Case 3 '预设
                FrmSetupUI.PanCustomPreset.Visibility = Visibility.Visible
                FrmSetupUI.PanCustomLocal.Visibility = Visibility.Collapsed
                FrmSetupUI.PanCustomNet.Visibility = Visibility.Collapsed
                FrmSetupUI.HintCustom.Visibility = Visibility.Collapsed
                FrmSetupUI.HintCustomWarn.Visibility = Visibility.Collapsed
        End Select
        FrmSetupUI.CardCustom.TriggerForceResize()
    End Sub
    '颜色模式
    Public Sub UiDarkMode(Value As Integer)
        If Value = 0 Then
            IsDarkMode = False
        ElseIf Value = 1 Then
            IsDarkMode = True
        Else
            IsDarkMode = IsSystemInDarkMode()
        End If
        ThemeRefresh()
    End Sub
    '高级材质
    Public Sub UiBlur(Value As Boolean)
        FrmSetupUI.PanBlurValue.Visibility = If(Value, Visibility.Visible, Visibility.Collapsed)
        If Value Then
            UiBlurValue(Setup.Get("UiBlurValue"))
        Else
            UiBlurValue(0)
        End If
    End Sub
    Public Sub UiBlurValue(Value As Integer)
        Application.Current.Resources("BlurValue") = CType(Value, Double)
    End Sub
    '顶部栏
    Public Sub UiLogoType(Value As Integer)
        Select Case Value
            Case 0 '无
                FrmMain.ShapeTitleLogo.Visibility = Visibility.Collapsed
                FrmMain.LabTitleLogo.Visibility = Visibility.Collapsed
                FrmMain.ImageTitleLogo.Visibility = Visibility.Collapsed
                FrmMain.CELogo.Visibility = Visibility.Collapsed
                If Not IsNothing(FrmSetupUI) Then
                    FrmSetupUI.CheckLogoLeft.Visibility = Visibility.Visible
                    FrmSetupUI.PanLogoText.Visibility = Visibility.Collapsed
                    FrmSetupUI.PanLogoChange.Visibility = Visibility.Collapsed
                End If
            Case 1 '默认
                FrmMain.ShapeTitleLogo.Visibility = Visibility.Visible
                FrmMain.LabTitleLogo.Visibility = Visibility.Collapsed
                FrmMain.ImageTitleLogo.Visibility = Visibility.Collapsed
                FrmMain.CELogo.Visibility = Visibility.Visible
                If Not IsNothing(FrmSetupUI) Then
                    FrmSetupUI.CheckLogoLeft.Visibility = Visibility.Collapsed
                    FrmSetupUI.PanLogoText.Visibility = Visibility.Collapsed
                    FrmSetupUI.PanLogoChange.Visibility = Visibility.Collapsed
                End If
            Case 2 '文本
                FrmMain.ShapeTitleLogo.Visibility = Visibility.Collapsed
                FrmMain.LabTitleLogo.Visibility = Visibility.Visible
                FrmMain.ImageTitleLogo.Visibility = Visibility.Collapsed
                FrmMain.CELogo.Visibility = Visibility.Visible
                If Not IsNothing(FrmSetupUI) Then
                    FrmSetupUI.CheckLogoLeft.Visibility = Visibility.Collapsed
                    FrmSetupUI.PanLogoText.Visibility = Visibility.Visible
                    FrmSetupUI.PanLogoChange.Visibility = Visibility.Collapsed
                End If
                Setup.Load("UiLogoText", True)
            Case 3 '图片
                FrmMain.ShapeTitleLogo.Visibility = Visibility.Collapsed
                FrmMain.LabTitleLogo.Visibility = Visibility.Collapsed
                FrmMain.ImageTitleLogo.Visibility = Visibility.Visible
                FrmMain.CELogo.Visibility = Visibility.Visible
                If Not IsNothing(FrmSetupUI) Then
                    FrmSetupUI.CheckLogoLeft.Visibility = Visibility.Collapsed
                    FrmSetupUI.PanLogoText.Visibility = Visibility.Collapsed
                    FrmSetupUI.PanLogoChange.Visibility = Visibility.Visible
                End If
                Try
                    FrmMain.ImageTitleLogo.Source = Path & "PCL\Logo.png"
                Catch ex As Exception
                    FrmMain.ImageTitleLogo.Source = Nothing
                    Log(ex, "显示标题栏图片失败", LogLevel.Msgbox)
                End Try
        End Select
        Setup.Load("UiLogoLeft", True)
        If Not IsNothing(FrmSetupUI) Then FrmSetupUI.CardLogo.TriggerForceResize()
    End Sub
    Public Sub UiLogoText(Value As String)
        FrmMain.LabTitleLogo.Text = Value
    End Sub
    Public Sub UiLogoLeft(Value As Boolean)
        FrmMain.PanTitleMain.ColumnDefinitions(0).Width = New GridLength(If(Value AndAlso (Setup.Get("UiLogoType") = 0), 0, 1), GridUnitType.Star)
    End Sub

    '功能隐藏
    Public Sub UiHiddenPageLink(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenPageDownload(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenPageSetup(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenPageOther(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenFunctionSelect(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenFunctionModUpdate(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenFunctionHidden(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenSetupLaunch(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenSetupUi(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenSetupSystem(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenOtherHelp(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenOtherFeedback(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenOtherVote(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenOtherAbout(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenOtherTest(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenVersionEdit(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenVersionExport(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenVersionSave(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenVersionScreenshot(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenVersionMod(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenVersionResourcePack(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenVersionShader(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub
    Public Sub UiHiddenVersionSchematic(Value As Boolean)
        PageSetupUI.HiddenRefresh()
    End Sub


#End Region

#Region "System"

    '调试选项
    Public Sub SystemDebugMode(Value As Boolean)
        ModeDebug = Value
    End Sub
    Public Sub SystemDebugAnim(Value As Integer)
        AniSpeed = If(Value >= 30, 200, MathClamp(Value * 0.1 + 0.1, 0.1, 3))
    End Sub

    Public Sub SystemHttpProxy(value As String)
        HttpProxyManager.Instance.ProxyAddress = value
    End Sub

    Public Sub SystemUseDefaultProxy(value As Boolean)
        HttpProxyManager.Instance.DisableProxy = value
    End Sub

#End Region

#Region "Version"

    '游戏内存
    Public Sub VersionRamType(Type As Integer)
        If FrmInstanceSetup Is Nothing Then Return
        FrmInstanceSetup.RamType(Type)
    End Sub

    '服务器
    Public Sub VersionServerLogin(Type As Integer)
        If FrmInstanceSetup Is Nothing Then Return
        '为第三方登录清空缓存以更新描述
        WriteIni(PathMcFolder & "PCL.ini", "InstanceCache", "")
        If PageInstanceLeft.Instance Is Nothing Then Return
        PageInstanceLeft.Instance = New McInstance(PageInstanceLeft.Instance.Name).Load()
        LoaderFolderRun(McInstanceListLoader, PathMcFolder, LoaderFolderRunType.ForceRun, MaxDepth:=1, ExtraPath:="versions\")
    End Sub

#End Region

End Class

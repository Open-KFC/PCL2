Imports System.Reflection
Imports PCL.Core.Network
Imports PCL.Core.ProgramSetup
Imports NEWSetupEntry = PCL.Core.ProgramSetup.SetupEntry

Public Class ModSetup

    ''' <summary>
    ''' 设置的更新号。
    ''' </summary>
    Public Const VersionSetup As Integer = 1
    ''' <summary>
    ''' 设置列表。
    ''' </summary>
    Private ReadOnly SetupDict As New Dictionary(Of String, NEWSetupEntry) From {
        {"Identify", New SetupEntry("Identify", "", source:=SetupSource.AppData)},
        {"WindowHeight", New SetupEntry("WindowHeight", 550)},
        {"WindowWidth", New SetupEntry("WindowWidth", 900)},
        {"HintDownloadThread", New SetupEntry("HintDownloadThread", False, source:=SetupSource.AppData)},
        {"HintNotice", New SetupEntry("HintNotice", 0, source:=SetupSource.AppData)},
        {"HintDownload", New SetupEntry("HintDownload", 0, source:=SetupSource.AppData)},
        {"HintInstallBack", New SetupEntry("HintInstallBack", False, source:=SetupSource.AppData)},
        {"HintHide", New SetupEntry("HintHide", False, source:=SetupSource.AppData)},
        {"HintHandInstall", New SetupEntry("HintHandInstall", False, source:=SetupSource.AppData)},
        {"HintBuy", New SetupEntry("HintBuy", False, source:=SetupSource.AppData)},
        {"HintClearRubbish", New SetupEntry("HintClearRubbish", 0, source:=SetupSource.AppData)},
        {"HintUpdateMod", New SetupEntry("HintUpdateMod", False, source:=SetupSource.AppData)},
        {"HintCustomCommand", New SetupEntry("HintCustomCommand", False, source:=SetupSource.AppData)},
        {"HintCustomWarn", New SetupEntry("HintCustomWarn", False, source:=SetupSource.AppData)},
        {"HintMoreAdvancedSetup", New SetupEntry("HintMoreAdvancedSetup", False, source:=SetupSource.AppData)},
        {"HintIndieSetup", New SetupEntry("HintIndieSetup", False, source:=SetupSource.AppData)},
        {"HintProfileSelect", New SetupEntry("HintProfileSelect", False, source:=SetupSource.AppData)},
        {"HintExportConfig", New SetupEntry("HintExportConfig", False, source:=SetupSource.AppData)},
        {"HintMaxLog", New SetupEntry("HintMaxLog", False, source:=SetupSource.AppData)},
        {"HintDisableGamePathCheckTip", New SetupEntry("HintDisableGamePathCheckTip", False, source:=SetupSource.AppData)},
        {"SystemEula", New SetupEntry("SystemEula", False, source:=SetupSource.AppData)},
        {"SystemCount", New SetupEntry("SystemCount", 0, source:=SetupSource.AppData, encoded:=True)},
        {"SystemLaunchCount", New SetupEntry("SystemLaunchCount", 0, source:=SetupSource.AppData, encoded:=True)},
        {"SystemLastVersionReg", New SetupEntry("SystemLastVersionReg", 0, source:=SetupSource.AppData, encoded:=True)},
        {"SystemHighestSavedBetaVersionReg", New SetupEntry("SystemHighestSavedBetaVersionReg", 0, source:=SetupSource.AppData, encoded:=True)},
        {"SystemHighestBetaVersionReg", New SetupEntry("SystemHighestBetaVersionReg", 0, source:=SetupSource.AppData, encoded:=True)},
        {"SystemHighestAlphaVersionReg", New SetupEntry("SystemHighestAlphaVersionReg", 0, source:=SetupSource.AppData, encoded:=True)},
        {"SystemSetupVersionReg", New SetupEntry("SystemSetupVersionReg", VersionSetup, source:=SetupSource.AppData)},
        {"SystemSetupVersionIni", New SetupEntry("SystemSetupVersionIni", VersionSetup)},
        {"SystemDebugMode", New SetupEntry("SystemDebugMode", False, source:=SetupSource.AppData)},
        {"SystemDebugAnim", New SetupEntry("SystemDebugAnim", 9, source:=SetupSource.AppData)},
        {"SystemDebugDelay", New SetupEntry("SystemDebugDelay", False, source:=SetupSource.AppData)},
        {"SystemDebugSkipCopy", New SetupEntry("SystemDebugSkipCopy", False, source:=SetupSource.AppData)},
        {"SystemSystemCache", New SetupEntry("SystemSystemCache", "", source:=SetupSource.AppData)},
        {"SystemSystemUpdate", New SetupEntry("SystemSystemUpdate", 0)},
        {"SystemSystemUpdateBranch", New SetupEntry("SystemSystemUpdateBranch", If(VersionBaseName.Contains("beta"), 1, 0))},
        {"SystemSystemActivity", New SetupEntry("SystemSystemActivity", 0)},
        {"SystemSystemAnnouncement", New SetupEntry("SystemSystemAnnouncement", "", source:=SetupSource.AppData)},
        {"SystemHttpProxy", New SetupEntry("SystemHttpProxy", "", source:=SetupSource.AppData, encoded:=True)},
        {"SystemUseDefaultProxy", New SetupEntry("SystemUseDefaultProxy", True, source:=SetupSource.AppData)},
        {"SystemDisableHardwareAcceleration", New SetupEntry("SystemDisableHardwareAcceleration", False, source:=SetupSource.AppData)},
        {"SystemTelemetry", New SetupEntry("SystemTelemetry", False, source:=SetupSource.AppData)},
        {"SystemMirrorChyanKey", New SetupEntry("SystemMirrorChyanKey", "", source:=SetupSource.AppData, encoded:=True)},
        {"SystemMaxLog", New SetupEntry("SystemMaxLog", 13, source:=SetupSource.AppData)},
        {"CacheExportConfig", New SetupEntry("CacheExportConfig", "", source:=SetupSource.AppData)},
        {"CacheSavedPageUrl", New SetupEntry("CacheSavedPageUrl", "", source:=SetupSource.AppData)},
        {"CacheSavedPageInstance", New SetupEntry("CacheSavedPageInstance", "", source:=SetupSource.AppData)},
        {"CacheDownloadFolder", New SetupEntry("CacheDownloadFolder", "", source:=SetupSource.AppData)},
        {"ToolDownloadCustomUserAgent", New SetupEntry("ToolDownloadCustomUserAgent", "", source:=SetupSource.AppData)},
        {"CacheJavaListVersion", New SetupEntry("CacheJavaListVersion", 0, source:=SetupSource.AppData)},
        {"CacheAuthUuid", New SetupEntry("CacheAuthUuid", "", source:=SetupSource.AppData, encoded:=True)},
        {"CacheAuthName", New SetupEntry("CacheAuthName", "", source:=SetupSource.AppData, encoded:=True)},
        {"CacheAuthUsername", New SetupEntry("CacheAuthUsername", "", source:=SetupSource.AppData, encoded:=True)},
        {"CacheAuthPass", New SetupEntry("CacheAuthPass", "", source:=SetupSource.AppData, encoded:=True)},
        {"CacheAuthServerServer", New SetupEntry("CacheAuthServerServer", "", source:=SetupSource.AppData, encoded:=True)},
        {"CompFavorites", New SetupEntry("CompFavorites", "[]", source:=SetupSource.AppData)},
        {"LaunchInstanceSelect", New SetupEntry("LaunchInstanceSelect", "")},
        {"LaunchFolderSelect", New SetupEntry("LaunchFolderSelect", "")},
        {"LaunchFolders", New SetupEntry("LaunchFolders", "", source:=SetupSource.AppData)},
        {"LaunchArgumentTitle", New SetupEntry("LaunchArgumentTitle", "")},
        {"LaunchArgumentInfo", New SetupEntry("LaunchArgumentInfo", "PCL")},
        {"LaunchArgumentJavaSelect", New SetupEntry("LaunchArgumentJavaSelect", "", source:=SetupSource.AppData)},
        {"LaunchArgumentJavaUser", New SetupEntry("LaunchArgumentJavaUser", "[]", source:=SetupSource.AppData)},
        {"LaunchArgumentIndie", New SetupEntry("LaunchArgumentIndie", 0)},
        {"LaunchArgumentIndieV2", New SetupEntry("LaunchArgumentIndieV2", 4)},
        {"LaunchArgumentVisible", New SetupEntry("LaunchArgumentVisible", 5, source:=SetupSource.AppData)},
        {"LaunchArgumentPriority", New SetupEntry("LaunchArgumentPriority", 1, source:=SetupSource.AppData)},
        {"LaunchArgumentWindowWidth", New SetupEntry("LaunchArgumentWindowWidth", 854)},
        {"LaunchArgumentWindowHeight", New SetupEntry("LaunchArgumentWindowHeight", 480)},
        {"LaunchArgumentWindowType", New SetupEntry("LaunchArgumentWindowType", 1)},
        {"LaunchPreferredIpStack", New SetupEntry("LaunchPreferredIpStack", 1, source:=SetupSource.AppData)},
        {"LaunchArgumentRam", New SetupEntry("LaunchArgumentRam", False, source:=SetupSource.AppData)},
        {"LaunchAdvanceJvm", New SetupEntry("LaunchAdvanceJvm", "-XX:+UseG1GC -XX:-UseAdaptiveSizePolicy -XX:-OmitStackTraceInFastThrow -Djdk.lang.Process.allowAmbiguousCommands=true -Dfml.ignoreInvalidMinecraftCertificates=True -Dfml.ignorePatchDiscrepancies=True -Dlog4j2.formatMsgNoLookups=true")},
        {"LaunchAdvanceGame", New SetupEntry("LaunchAdvanceGame", "")},
        {"LaunchAdvanceRun", New SetupEntry("LaunchAdvanceRun", "")},
        {"LaunchAdvanceRunWait", New SetupEntry("LaunchAdvanceRunWait", True)},
        {"LaunchAdvanceDisableJLW", New SetupEntry("LaunchAdvanceDisableJLW", False)},
        {"LaunchAdvanceDisableRW", New SetupEntry("LaunchAdvanceDisableRW", False)},
        {"LaunchAdvanceGraphicCard", New SetupEntry("LaunchAdvanceGraphicCard", True, source:=SetupSource.AppData)},
        {"LaunchAdvanceNoJavaw", New SetupEntry("LaunchAdvanceNoJavaw", False, source:=SetupSource.AppData)},
        {"LaunchRamType", New SetupEntry("LaunchRamType", 0)},
        {"LaunchRamCustom", New SetupEntry("LaunchRamCustom", 15)},
        {"LaunchUuid", New SetupEntry("LaunchUuid", String.Empty, source:=SetupSource.AppData)},
        {"ToolFixAuthlib", New SetupEntry("ToolFixAuthlib", True, source:=SetupSource.AppData)},
        {"LinkEula", New SetupEntry("LinkEula", False, source:=SetupSource.AppData)},
        {"LinkAnnounceCache", New SetupEntry("LinkAnnounceCache", "", source:=SetupSource.AppData, encoded:=True)},
        {"LinkAnnounceCacheVer", New SetupEntry("LinkAnnounceCacheVer", 0, source:=SetupSource.AppData)},
        {"LinkRelayType", New SetupEntry("LinkRelayType", 0, source:=SetupSource.AppData)},
        {"LinkServerType", New SetupEntry("LinkServerType", 1, source:=SetupSource.AppData)},
        {"LinkProxyType", New SetupEntry("LinkProxyType", 1, source:=SetupSource.AppData)},
        {"LinkRelayServer", New SetupEntry("LinkRelayServer", "", source:=SetupSource.AppData)},
        {"LinkNaidRefreshToken", New SetupEntry("LinkNaidRefreshToken", "", source:=SetupSource.AppData, encoded:=True)},
        {"LinkNaidRefreshExpiresAt", New SetupEntry("LinkNaidRefreshExpiresAt", "", source:=SetupSource.AppData, encoded:=True)},
        {"LinkFirstTimeNetTest", New SetupEntry("LinkFirstTimeNetTest", True, source:=SetupSource.AppData)},
        {"LoginLegacyName", New SetupEntry("LoginLegacyName", "", source:=SetupSource.AppData, encoded:=True)},
        {"LoginMsJson", New SetupEntry("LoginMsJson", "{}", source:=SetupSource.AppData, encoded:=True)}, '{UserName: OAuthToken, ...}
        {"LoginMsAuthType", New SetupEntry("LoginMsAuthType", 1, source:=SetupSource.AppData)},
        {"ToolHelpChinese", New SetupEntry("ToolHelpChinese", True, source:=SetupSource.AppData)},
        {"ToolDownloadThread", New SetupEntry("ToolDownloadThread", 63, source:=SetupSource.AppData)},
        {"ToolDownloadSpeed", New SetupEntry("ToolDownloadSpeed", 42, source:=SetupSource.AppData)},
        {"ToolDownloadSource", New SetupEntry("ToolDownloadSource", 1, source:=SetupSource.AppData)},
        {"ToolDownloadVersion", New SetupEntry("ToolDownloadVersion", 1, source:=SetupSource.AppData)},
        {"ToolDownloadTranslate", New SetupEntry("ToolDownloadTranslate", 0, source:=SetupSource.AppData)},
        {"ToolDownloadTranslateV2", New SetupEntry("ToolDownloadTranslateV2", 1, source:=SetupSource.AppData)},
        {"ToolDownloadIgnoreQuilt", New SetupEntry("ToolDownloadIgnoreQuilt", True, source:=SetupSource.AppData)},
        {"ToolDownloadClipboard", New SetupEntry("ToolDownloadClipboard", False, source:=SetupSource.AppData)},
        {"ToolDownloadCert", New SetupEntry("ToolDownloadCert", True, source:=SetupSource.AppData)},
        {"ToolDownloadMod", New SetupEntry("ToolDownloadMod", 1, source:=SetupSource.AppData)},
        {"ToolModLocalNameStyle", New SetupEntry("ToolModLocalNameStyle", 0, source:=SetupSource.AppData)},
        {"ToolUpdateAlpha", New SetupEntry("ToolUpdateAlpha", 0, source:=SetupSource.AppData, encoded:=True)},
        {"ToolUpdateRelease", New SetupEntry("ToolUpdateRelease", False, source:=SetupSource.AppData)},
        {"ToolUpdateSnapshot", New SetupEntry("ToolUpdateSnapshot", False, source:=SetupSource.AppData)},
        {"ToolUpdateReleaseLast", New SetupEntry("ToolUpdateReleaseLast", "", source:=SetupSource.AppData)},
        {"ToolUpdateSnapshotLast", New SetupEntry("ToolUpdateSnapshotLast", "", source:=SetupSource.AppData)},
        {"ToolDownloadAutoSelectVersion", New SetupEntry("ToolDownloadAutoSelectVersion", True, source:=SetupSource.AppData)},
        {"UiLauncherTransparent", New SetupEntry("UiLauncherTransparent", 600)}, '避免与 PCL1 设置冲突（UiLauncherOpacity）
        {"UiLauncherHue", New SetupEntry("UiLauncherHue", 180)},
        {"UiLauncherSat", New SetupEntry("UiLauncherSat", 80)},
        {"UiLauncherDelta", New SetupEntry("UiLauncherDelta", 90)},
        {"UiLauncherLight", New SetupEntry("UiLauncherLight", 20)},
        {"UiLauncherTheme", New SetupEntry("UiLauncherTheme", 0)},
        {"UiLauncherThemeGold", New SetupEntry("UiLauncherThemeGold", "", source:=SetupSource.AppData, encoded:=True)},
        {"UiLauncherThemeHide", New SetupEntry("UiLauncherThemeHide", "0|1|2|3|4", source:=SetupSource.AppData, encoded:=True)},
        {"UiLauncherThemeHide2", New SetupEntry("UiLauncherThemeHide2", "0|1|2|3|4", source:=SetupSource.AppData, encoded:=True)},
        {"UiLauncherLogo", New SetupEntry("UiLauncherLogo", True)},
        {"UiLauncherCEHint", New SetupEntry("UiLauncherCEHint", True, source:=SetupSource.AppData)},
        {"UiLauncherCEHintCount", New SetupEntry("UiLauncherCEHintCount", 0, source:=SetupSource.AppData)},
        {"UiBlur", New SetupEntry("UiBlur", False)},
        {"UiBlurValue", New SetupEntry("UiBlurValue", 16)},
        {"UiBackgroundColorful", New SetupEntry("UiBackgroundColorful", True)},
        {"UiBackgroundOpacity", New SetupEntry("UiBackgroundOpacity", 1000)},
        {"UiBackgroundBlur", New SetupEntry("UiBackgroundBlur", 0)},
        {"UiBackgroundSuit", New SetupEntry("UiBackgroundSuit", 0)},
        {"UiCustomType", New SetupEntry("UiCustomType", 0)},
        {"UiCustomPreset", New SetupEntry("UiCustomPreset", 0)},
        {"UiCustomNet", New SetupEntry("UiCustomNet", "")},
        {"UiDarkMode", New SetupEntry("UiDarkMode", 2, source:=SetupSource.AppData)},
        {"UiDarkColor", New SetupEntry("UiDarkColor", 1, source:=SetupSource.AppData)},
        {"UiLightColor", New SetupEntry("UiLightColor", 1, source:=SetupSource.AppData)},
        {"UiLockWindowSize", New SetupEntry("UiLockWindowSize", False, source:=SetupSource.AppData)},
        {"UiLogoType", New SetupEntry("UiLogoType", 1)},
        {"UiLogoText", New SetupEntry("UiLogoText", "")},
        {"UiLogoLeft", New SetupEntry("UiLogoLeft", False)},
        {"UiMusicVolume", New SetupEntry("UiMusicVolume", 500)},
        {"UiMusicStop", New SetupEntry("UiMusicStop", False)},
        {"UiMusicStart", New SetupEntry("UiMusicStart", False)},
        {"UiMusicRandom", New SetupEntry("UiMusicRandom", True)},
        {"UiMusicSMTC", New SetupEntry("UiMusicSMTC", True)},
        {"UiMusicAuto", New SetupEntry("UiMusicAuto", True)},
        {"UiHiddenPageDownload", New SetupEntry("UiHiddenPageDownload", False)},
        {"UiHiddenPageLink", New SetupEntry("UiHiddenPageLink", False)},
        {"UiHiddenPageSetup", New SetupEntry("UiHiddenPageSetup", False)},
        {"UiHiddenPageOther", New SetupEntry("UiHiddenPageOther", False)},
        {"UiHiddenFunctionSelect", New SetupEntry("UiHiddenFunctionSelect", False)},
        {"UiHiddenFunctionModUpdate", New SetupEntry("UiHiddenFunctionModUpdate", False)},
        {"UiHiddenFunctionHidden", New SetupEntry("UiHiddenFunctionHidden", False)},
        {"UiHiddenSetupLaunch", New SetupEntry("UiHiddenSetupLaunch", False)},
        {"UiHiddenSetupUi", New SetupEntry("UiHiddenSetupUi", False)},
        {"UiHiddenSetupSystem", New SetupEntry("UiHiddenSetupSystem", False)},
        {"UiHiddenOtherHelp", New SetupEntry("UiHiddenOtherHelp", False)},
        {"UiHiddenOtherFeedback", New SetupEntry("UiHiddenOtherFeedback", False)},
        {"UiHiddenOtherVote", New SetupEntry("UiHiddenOtherVote", False)},
        {"UiHiddenOtherAbout", New SetupEntry("UiHiddenOtherAbout", False)},
        {"UiHiddenOtherTest", New SetupEntry("UiHiddenOtherTest", False)},
        {"UiHiddenVersionEdit", New SetupEntry("UiHiddenVersionEdit", False)},
        {"UiHiddenVersionExport", New SetupEntry("UiHiddenVersionExport", False)},
        {"UiHiddenVersionSave", New SetupEntry("UiHiddenVersionSave", False)},
        {"UiHiddenVersionScreenshot", New SetupEntry("UiHiddenVersionScreenshot", False)},
        {"UiHiddenVersionMod", New SetupEntry("UiHiddenVersionMod", False)},
        {"UiHiddenVersionResourcePack", New SetupEntry("UiHiddenVersionResourcePack", False)},
        {"UiHiddenVersionShader", New SetupEntry("UiHiddenVersionShader", False)},
        {"UiHiddenVersionSchematic", New SetupEntry("UiHiddenVersionSchematic", False)},
        {"UiSchematicFirstTimeHintShown", New SetupEntry("UiSchematicFirstTimeHintShown", False, source:=SetupSource.AppData)},
        {"UiAniFPS", New SetupEntry("UiAniFPS", 59, source:=SetupSource.AppData)},
        {"UiFont", New SetupEntry("UiFont", "")},
        {"VersionAdvanceJvm", New SetupEntry("VersionAdvanceJvm", "", source:=SetupSource.Instance)},
        {"VersionAdvanceGame", New SetupEntry("VersionAdvanceGame", "", source:=SetupSource.Instance)},
        {"VersionAdvanceAssets", New SetupEntry("VersionAdvanceAssets", 0, source:=SetupSource.Instance)},
        {"VersionAdvanceAssetsV2", New SetupEntry("VersionAdvanceAssetsV2", False, source:=SetupSource.Instance)},
        {"VersionAdvanceJava", New SetupEntry("VersionAdvanceJava", False, source:=SetupSource.Instance)},
        {"VersionAdvanceDisableJlw", New SetupEntry("VersionAdvanceDisableJlw", False, source:=SetupSource.Instance)},
        {"VersionAdvanceRun", New SetupEntry("VersionAdvanceRun", "", source:=SetupSource.Instance)},
        {"VersionAdvanceRunWait", New SetupEntry("VersionAdvanceRunWait", True, source:=SetupSource.Instance)},
        {"VersionAdvanceDisableJLW", New SetupEntry("VersionAdvanceDisableJLW", False, source:=SetupSource.Instance)},
        {"VersionAdvanceUseProxyV2", New SetupEntry("VersionAdvanceUseProxyV2", False, source:=SetupSource.Instance)},
        {"VersionAdvanceDisableRW", New SetupEntry("VersionAdvanceDisableRW", False, source:=SetupSource.Instance)},
        {"VersionRamType", New SetupEntry("VersionRamType", 2, source:=SetupSource.Instance)},
        {"VersionRamCustom", New SetupEntry("VersionRamCustom", 15, source:=SetupSource.Instance)},
        {"VersionRamOptimize", New SetupEntry("VersionRamOptimize", 0, source:=SetupSource.Instance)},
        {"VersionArgumentTitle", New SetupEntry("VersionArgumentTitle", "", source:=SetupSource.Instance)},
        {"VersionArgumentTitleEmpty", New SetupEntry("VersionArgumentTitleEmpty", False, source:=SetupSource.Instance)},
        {"VersionArgumentInfo", New SetupEntry("VersionArgumentInfo", "", source:=SetupSource.Instance)},
        {"VersionArgumentIndie", New SetupEntry("VersionArgumentIndie", -1, source:=SetupSource.Instance)},
        {"VersionArgumentIndieV2", New SetupEntry("VersionArgumentIndieV2", False, source:=SetupSource.Instance)},
        {"VersionArgumentJavaSelect", New SetupEntry("VersionArgumentJavaSelect", "使用全局设置", source:=SetupSource.Instance)},
        {"VersionServerEnter", New SetupEntry("VersionServerEnter", "", source:=SetupSource.Instance)},
        {"VersionServerLoginRequire", New SetupEntry("VersionServerLoginRequire", 0, source:=SetupSource.Instance)},
        {"VersionServerAuthRegister", New SetupEntry("VersionServerAuthRegister", "", source:=SetupSource.Instance)},
        {"VersionServerAuthName", New SetupEntry("VersionServerAuthName", "", source:=SetupSource.Instance)},
        {"VersionServerAuthServer", New SetupEntry("VersionServerAuthServer", "", source:=SetupSource.Instance)},
        {"VersionServerLoginLock", New SetupEntry("VersionServerLoginLock", False, source:=SetupSource.Instance)},
        {"VersionLaunchCount", New SetupEntry("VersionLaunchCount", 0, source:=SetupSource.Instance)}}

#Region "基础"

    Public Sub New()
        AddHandler SetupService.SetupChanged, AddressOf OnSetupChanged
    End Sub

    Private Sub OnSetupChanged(entry As NEWSetupEntry, oldValue As Object, newValue As Object, gamePath As String)
        Dim method As MethodInfo = GetType(ModSetup).GetMethod(entry.KeyName)
        If method IsNot Nothing Then method.Invoke(Me, {If(newValue, entry.DefaultValue)})
    End Sub

    Private Enum SetupSource
        Normal ' = PathLocal
        AppData ' = SystemGlobal
        Instance ' = GameInstance
    End Enum
    Private Class SetupEntry
        Private ReadOnly _keyName As String
        Private ReadOnly _encoded As Boolean
        Private ReadOnly _defaultValue
        Private ReadOnly _source As SetupSource

        Public Sub New(keyName As String, defaultValue As Object, Optional source As SetupSource = SetupSource.Normal, Optional encoded As Boolean = False)
            _keyName = keyName
            _defaultValue = defaultValue
            _encoded = encoded
            _source = source
        End Sub

        Public Shared Widening Operator CType(entry As SetupEntry) As NEWSetupEntry
            Return New NEWSetupEntry(entry._source, entry._keyName, entry._defaultValue, entry._encoded)
        End Operator
    End Class

    ''' <summary>
    ''' 改变某个设置项的值。
    ''' </summary>
    Public Sub [Set](key As String, value As Object, Optional forceReload As Boolean = False, Optional instance As McInstance = Nothing)
        Dim entry As NEWSetupEntry = SetupDict(key)
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
        Dim entry As NEWSetupEntry = SetupDict(key)
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
#disable Warning BC40000
        SetupService.RaiseSetupChanged(SetupDict(key), value, value, instance?.Path)
#enable Warning BC40000
        Return value
    End Function

    ''' <summary>
    ''' 获取某个设置项的值。
    ''' </summary>
    Public Function [Get](key As String, Optional instance As McInstance = Nothing)
        Dim entry As NEWSetupEntry = SetupDict(key)
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
        Dim entry As NEWSetupEntry = SetupDict(key)
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
        Dim entry As NEWSetupEntry = SetupDict(key)
        Return entry.DefaultValue
    End Function
    ''' <summary>
    ''' 某个设置项是否从未被设置过。
    ''' </summary>
    Public Function IsUnset(key As String, Optional instance As McInstance = Nothing) As Boolean
        Dim entry As NEWSetupEntry = SetupDict(key)
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

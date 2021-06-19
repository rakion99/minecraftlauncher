namespace FreeLauncher
{
    public class ApplicationLocalization
    {
        public string Name { get; set; }
        public string LanguageTag { get; set; }
        public string Authors { get; set; }

        #region LauncherForm

        #region Tabs

        public string NewsTabText { get; set; }
        public string ConsoleTabText { get; set; }
        public string ManageVersionsTabText { get; set; }
        public string ManageProfilesTabText { get; set; }
        public string AboutTabText { get; set; }
        public string LicensesTabText { get; set; }
        public string SettingsTabText { get; set; }

        #endregion

        #region Main Controls

        public string LaunchButtonText { get; set; }
        public string AddProfileButtonText { get; set; }
        public string EditProfileButtonText { get; set; }
        public string SetToClipboardButtonText { get; set; }

        #endregion

        #region Build Managment Tab

        public string VersionHeader { get; set; }
        public string TypeHeader { get; set; }
        public string ReleaseDateHeader { get; set; }
        public string LastUpdatedHeader { get; set; }
        public string AssetsIndexHeader { get; set; }
        public string DependencyHeader { get; set; }

        public string Restore { get; set; }
        public string OpenLocation { get; set; }
        public string DeleteVersion { get; set; }
        public string DeleteConfirmationTitle { get; set; }
        public string DeleteConfirmationText { get; set; }

        #endregion

        #region Profile Managment Tab

        public string MoveUp { get; set; }
        public string MoveDown { get; set; }
        #endregion

        #region About Tab

        public string DevInfo { get; set; }
        public string GratitudesText { get; set; }
        public string GratitudesDescription { get; set; }
        public string PartnersText { get; set; }
        public string MCofflineDescription { get; set; }

        public string CopyrightInfo { get; set; }

        #endregion

        #region Settings Tab

        public string MainSettingsTitle { get; set; }
        public string CheckUpdatesCheckBox { get; set; }
        public string SkipAssetsDownload { get; set; }
        public string EnableMinecraftLoggingText { get; set; }
        public string LoggerSettingsTitle { get; set; }

        public string CloseGameOutputText { get; set; }

        #endregion

        public string Launch { get; set; }
        public string Delete { get; set; }
        public string ReadyToLaunch { get; set; }
        public string ReadyToDownload { get; set; }
        public string EditingProfileTitle { get; set; }
        public string ProfileAlreadyExistsErrorText { get; set; }
        public string ProfileDeleteConfirmationText { get; set; }
        public string AddingProfileTitle { get; set; }
        public string CheckingVersionAvailability { get; set; }
        public string CheckingLibraries { get; set; }
        public string GameOutput { get; set; }
        public string KillProcess { get; set; }
        public string Independent { get; set; }
        public string InvalidSessionMessage { get; set; }
        public string SomeFilesMissingMessage { get; set; }

        #endregion

        #region ProfileForm

        #region GroupBoxes

        public string MainProfileSettingsGroup { get; set; }
        public string VersionSettingsGroup { get; set; }
        public string JavaSettingsGroup { get; set; }

        #endregion

        #region Main Settings

        public string ProfileName { get; set; }
        public string WorkingDirectory { get; set; }
        public string WindowResolution { get; set; }
        public string ActionAfterLaunch { get; set; }
        public string KeepLauncherOpen { get; set; }
        public string HideLauncher { get; set; }
        public string CloseLauncher { get; set; }
        public string Autoconnect { get; set; }

        #endregion

        #region Version Selection

        public string Snapshots { get; set; }
        public string Beta { get; set; }
        public string Alpha { get; set; }
        public string Other { get; set; }
        public string UseLatestVersion { get; set; }

        #endregion

        #region Java Options

        public string JavaExecutable { get; set; }
        public string JavaFlags { get; set; }

        #endregion

        public string OpenDirectory { get; set; }

        public string JavaDetectionFailed { get; set; }

        #endregion

        #region UsersForm

        public string AddNewUserBox { get; set; }
        public string Nickname { get; set; }
        public string LicenseQuestion { get; set; }
        public string Password { get; set; }
        public string AddNewUserButton { get; set; }
        public string RemoveSelectedUser { get; set; }
        public string IncorrectLoginOrPassword { get; set; }
        public string PleaseWait { get; set; }

        #endregion

        #region UpdateForm

        public string GoToGitHub { get; set; }
        public string SupportDeveloper { get; set; }

        #endregion

        public string Error { get; set; }
        public string Cancel { get; set; }
        public string Close { get; set; }
        public string Save { get; set; }

        public string CloseLogsTab { get; set; }

        public string Updatefound { get; set; }
        public string UpdateInfo { get; set; }
        public string Checkingversionjson { get; set; }
        public string Lastsnapshot { get; set; }
        public string Lastrelease { get; set; }
        public string Localversions { get; set; }
        public string Remoteversions { get; set; }
        public string Noupdatefound { get; set; }
        public string Writingversionlist { get; set; }
        public string Cantcheckversions { get; set; }
        public string Correctlystarted { get; set; }
        public string Deletedsuccessfully { get; set; }
        public string Deleteerror { get; set; }
        public string Profilecorruptempty { get; set; }
        public string Profileerror1 { get; set; }
        public string Profileerror2 { get; set; }
        public string Profilecopy { get; set; }
        public string Checkingversionavailability { get; set; }
        public string Downloading { get; set; }
        public string Offlinemode { get; set; }
        public string Cantdownloadversion { get; set; }
        public string Checkingversionavailabilityfinish { get; set; }
        public string Logsdisabled { get; set; }
        public string Profilename { get; set; }
        public string Versionname { get; set; }
        public string Versiontype { get; set; }
        public string Launchervisibility { get; set; }
        public string Preparinglibraries { get; set; }
        public string Downloadfailed { get; set; }
        public string Cantdownload { get; set; }
        public string Finishedlibraries { get; set; }
        public string Checkinggamedata { get; set; }
        public string Downloadinggamedata { get; set; }
        public string Gamedatafinished { get; set; }
        public string Javanotfound { get; set; }
        public string Cantconnectinternet { get; set; }
        public string Checkinternet { get; set; }
        public string UpdateLang { get; set; }
        public string LangLabel { get; set; }
        public string Javadownloadexit { get; set; }
        public string Javaupdatefound { get; set; }
        public string Javaupdateinfo { get; set; }
    }
}

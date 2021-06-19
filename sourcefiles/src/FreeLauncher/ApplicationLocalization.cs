namespace FreeLauncher
{
    public class ApplicationLocalization
    {
        public string Name { get; set; } = "Español";
        public string LanguageTag { get; set; } = "es_MX";
        public string Authors { get; set; } = "rakion99";

        #region LauncherForm

        #region Tabs

        public string NewsTabText { get; set; } = "Noticias";
        public string ConsoleTabText { get; set; } = "CONSOLA";
        public string ManageVersionsTabText { get; set; } = "Versiones";
        public string ManageProfilesTabText { get; set; } = "Perfiles";
        public string AboutTabText { get; set; } = "OTROS";
        public string LicensesTabText { get; set; } = "Licensias";
        public string SettingsTabText { get; set; } = "Ajustes";

        #endregion

        #region Main Controls

        public string LaunchButtonText { get; set; } = "Abrir el Juego";
        public string AddProfileButtonText { get; set; } = "Añadir perfil";
        public string EditProfileButtonText { get; set; } = "Editar perfil";
        public string SetToClipboardButtonText { get; set; } = "Copiar al portapapeles";

        #endregion

        #region Build Managment Tab

        public string VersionHeader { get; set; } = "Version";
        public string TypeHeader { get; set; } = "Tipo";
        public string ReleaseDateHeader { get; set; } = "Dia de lanzamiento";
        public string LastUpdatedHeader { get; set; } = "Ultima actualizacion";
        public string AssetsIndexHeader { get; set; } = "Assets Index";
        public string DependencyHeader { get; set; } = "Depende de";

        public string Restore { get; set; } = "Restaurar";
        public string OpenLocation { get; set; } = "Abrir ubicacion";
        public string DeleteVersion { get; set; } = "Borrar";
        public string DeleteConfirmationTitle { get; set; } = "Confirmacion para borrar";
        public string DeleteConfirmationText { get; set; } = "Estas seguro que quieres borrar esta version '{0}'?";

        #endregion

        #region Profile Managment Tab

        public string MoveUp { get; set; } = "Mover arriba";
        public string MoveDown { get; set; } = "Mover abajo";
        #endregion

        #region About Tab

        public string DevInfo { get; set; } = "Developed by rakion99";
        public string GratitudesText { get; set; } = "Agradecimientos";
        public string GratitudesDescription { get; set; } = "rakion99";
        public string PartnersText { get; set; } = "Asociados";
        public string MCofflineDescription { get; set; } = "AnyCraft!";

        public string CopyrightInfo { get; set; } =
            "\"Minecraft\" es una marca registrada de Mojang. Todos los derechos reservados.\nMojang ahora es de Microsoft :V.";

        #endregion

        #region Settings Tab

        public string MainSettingsTitle { get; set; } = "Main";
        public string CheckUpdatesCheckBox { get; set; } = "Buscar actualizaciones";
        public string SkipAssetsDownload { get; set; } = "Saltar descarga de assets";
        public string EnableMinecraftLoggingText { get; set; } = "Display logs from OUTPUT thread";
        public string LoggerSettingsTitle { get; set; } = "Logging";

        public string CloseGameOutputText { get; set; } =
            "Cerrar pestaña automaticamente si no hay errores";

        #endregion

        public string Launch { get; set; } = "Jugar";
        public string Delete { get; set; } = "Borrar";
        public string ReadyToLaunch { get; set; } = "Listo para Jugar la version {0}";
        public string ReadyToDownload { get; set; } = "Listo para bajar la version {0}";
        public string EditingProfileTitle { get; set; } = "Editando perfil";
        public string ProfileAlreadyExistsErrorText { get; set; } = "Ya existe un perfil con este nombre!";
        public string ProfileDeleteConfirmationText { get; set; } = "Estas seguro que quieres borrar este perfil '{0}'?";
        public string AddingProfileTitle { get; set; } = "Añadiendo perfil";
        public string CheckingVersionAvailability { get; set; } = "Comprobando disponibilidad de la version '{0}'";
        public string CheckingLibraries { get; set; } = "Comprobando librerias";
        public string GameOutput { get; set; } = "Logs del juego";
        public string KillProcess { get; set; } = "Terminar";
        public string Independent { get; set; } = "Nothing";
        public string InvalidSessionMessage { get; set; } = "Session token is not valid. Please, re-add your account.";
        public string SomeFilesMissingMessage { get; set; } = "Parece que esta es la primera ves usando este Launcher.\nDesafortunadamente, algunos archivos no se encuentra y no se pueden descargar sin conexion a internet.\nPorfavor checa tu conexion de internet y reinicia el Launcher.";

        #endregion

        #region ProfileForm

        #region GroupBoxes

        public string MainProfileSettingsGroup { get; set; } = "Configuracion principal del perfil";
        public string VersionSettingsGroup { get; set; } = "Selecionador de version";
        public string JavaSettingsGroup { get; set; } = "Configuracion de Java";

        #endregion

        #region Main Settings

        public string ProfileName { get; set; } = "Nombre del perfil:";
        public string WorkingDirectory { get; set; } = "Working directory:";
        public string WindowResolution { get; set; } = "Resolucion de la ventana:";
        public string ActionAfterLaunch { get; set; } = "Accion despues de Jugar:";
        public string KeepLauncherOpen { get; set; } = "Dejar abierto el Launcher";
        public string HideLauncher { get; set; } = "Ocultar el Launcher";
        public string CloseLauncher { get; set; } = "Cerrar el Launcher";
        public string Autoconnect { get; set; } = "Auto conectar a:";

        #endregion

        #region Version Selection

        public string Snapshots { get; set; } = "Mostrar version experimentales (\"snapshots\")";
        public string Beta { get; set; } = "Mostar versiones \"Beta\" (2011-2012))";
        public string Alpha { get; set; } = "Mostrar versiones \"Alpha\" (hasta 2011)";
        public string Other { get; set; } = "Mostrar versiones modificadas (Forge, LiteLoader, etc.)";
        public string UseLatestVersion { get; set; } = "Usar ultima version '{0}'";

        #endregion

        #region Java Options

        public string JavaExecutable { get; set; } = "Ejecutable Java:";
        public string JavaFlags { get; set; } = "Java Flags:";

        #endregion

        public string OpenDirectory { get; set; } = "Open working dir";

        public string JavaDetectionFailed { get; set; } =
            "No se detecto instalacion de Java! Porfavor, proporciona el directorio de Java manualmente.";

        #endregion

        #region UsersForm

        public string AddNewUserBox { get; set; } = "Añadir nuevo usuario";
        public string Nickname { get; set; } = "Usuario:";
        public string LicenseQuestion { get; set; } = "Cuenta premium?";
        public string Password { get; set; } = "Contraseña:";
        public string AddNewUserButton { get; set; } = "Añadir nuevo usuario";
        public string RemoveSelectedUser { get; set; } = "Remover usuario seleccionado";
        public string IncorrectLoginOrPassword { get; set; } = "Usuario y/o Contraseña incorrecta!";
        public string PleaseWait { get; set; } = "Porfavor espere";

        #endregion

        #region UpdateForm

        public string GoToGitHub { get; set; } = "Ir a GitHub";
        public string SupportDeveloper { get; set; } = "Donar a rakion99";

        #endregion

        public string Error { get; set; } = "Error";
        public string Cancel { get; set; } = "Cancelar";
        public string Close { get; set; } = "Cerrar";
        public string Save { get; set; } = "Guardar";

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

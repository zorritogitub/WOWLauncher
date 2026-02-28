namespace Launcher.HelpClasses
{
    internal class Strings
    {
        public class Info
        {
            public static readonly string NOT_SET = "No especificado";

            public static readonly string PATH_CHOOSE = "Seleccione la carpeta del cliente del juego";

            public static readonly string INIT = "Inicializando…";

            public static readonly string UPDATE_IN_PROGRESS = "Actualizando…";
            public static readonly string UPDATE_DONE = "Juego actualizado";
        }

        public class Error
        {
            public static readonly string CONNECTION_ERROR = "Error de conexión";
            public static readonly string CONNECTION_ERROR_EXPLAIN = "No se puede conectar a Internet, verifique su conexión e intente nuevamente";

            public static readonly string PATH_ERROR = "Error de ubicación";
            public static readonly string PATH_ERROR_EXPLAIN = "¡Archivo \"Wow.exe\" no encontrado!\nPor favor, coloque el programa en la carpeta del juego o indique la ruta a la carpeta del juego.\n\n¿Indicar la ruta ahora?";

            public static readonly string PATH_CHOOSE_ERROR = "Error al seleccionar carpeta";
            public static readonly string PATH_CHOOSE_ERROR_EXPLAIN = "¡En la carpeta seleccionada no se encontró el archivo \"Wow.exe\"!\nPor favor, seleccione una carpeta válida del juego.\n\n¿Intentar seleccionar nuevamente?";
        }

    }
}

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System.ComponentModel;
using System.Reflection;
using static Google.Apis.Drive.v3.DriveService;

namespace Integracao
{
    public class GoogleDrive
    {
        public static string ClienteId { get; set; }
        public static string ChaveSecreta { get; set; }
        public static string NomeAplicativo { get; set; }
        public static string AccessToken { get; set; }
        public static string RefreshToken { get; set; }
        public static string IdPasta { get; set; }
        public static string Email { get; set; }

        /// <summary>
        /// Tipos de arquivos que podem ser enviados ao Google Drive
        /// </summary>
        /// <returns></returns>
        public enum eGoogleDriveMimeType
        {
            [System.ComponentModel.Description("application/pdf")]
            PDF,

            [System.ComponentModel.Description("image/jpeg")]
            JPEG,
            [System.ComponentModel.Description("image/png")]
            PNG,
            [System.ComponentModel.Description("image/gif")]
            GIF,
            [System.ComponentModel.Description("image/bmp")]
            BMP,

            [System.ComponentModel.Description("application/msword")]
            DOC,
            [System.ComponentModel.Description("application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
            DOCX,

            [System.ComponentModel.Description("application/vnd.ms-excel")]
            XLS,
            [System.ComponentModel.Description("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
            XLSX,

            [System.ComponentModel.Description("text/plain")]
            TXT,

            [System.ComponentModel.Description("application/vnd.google-apps.folder")]
            CriarPasta
        }

        public enum eRetornoLink
        {
            PDF,
            LINK
        }

        /// <summary>
        /// Aciona o serviço a ser utilizado para acesso ao Google Drive
        /// </summary>
        /// <returns></returns>
        private static DriveService GetService()
        {
            var pendencias = new List<string>();

            if (string.IsNullOrEmpty(ClienteId))
                pendencias.Add("Cliente Id");

            if (string.IsNullOrEmpty(ChaveSecreta))
                pendencias.Add("Chave Secreta");

            if (string.IsNullOrEmpty(NomeAplicativo))
                pendencias.Add("Nome do Aplicativo");

            if (string.IsNullOrEmpty(AccessToken))
                pendencias.Add("Token de Acesso (AccessToken)");

            if (string.IsNullOrEmpty(RefreshToken))
                pendencias.Add("Token Atualizado (Refresh Token)");

            if (string.IsNullOrEmpty(Email))
                pendencias.Add("Email");

            if (pendencias.Count > 0)
            {
                var mensagemErro = string.Join(", ", pendencias);
                throw new Exception(mensagemErro + ", não foi informado nas configurações do Google Drive.");
            }

            var tokenResponse = new TokenResponse
            {
                AccessToken = AccessToken,
                RefreshToken = RefreshToken
            };

            var applicationName = NomeAplicativo;
            var username = Email;

            var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = ClienteId,
                    ClientSecret = ChaveSecreta
                },
                Scopes = new[] { Scope.Drive },
                DataStore = new FileDataStore(applicationName)
            });

            var credential = new UserCredential(apiCodeFlow, username, tokenResponse);

            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            return service;
        }

        /// <summary>
        /// Cria uma pasta no Google Drive
        /// </summary>
        /// <param name="nomePasta"></param>
        /// <returns></returns>
        public static string CreateFolder(string nomePasta)
        {
            DriveService service = GetService();
            Google.Apis.Drive.v3.Data.File driveFolder = new Google.Apis.Drive.v3.Data.File
            {
                Name = nomePasta,
                MimeType = DescricaoEnum(eGoogleDriveMimeType.CriarPasta),
                Parents = new List<string> { "root" }
            };

            var command = service.Files.Create(driveFolder);
            var file = command.Execute();
            return file.Id;
        }

        /// <summary>
        /// Faz o upload do arquivo no Google Drive e retorna o Id
        /// </summary>
        /// <param name="caminhoArquivo">Arquivo a ser enviado</param>
        /// <param name="nomeArquivo">Nome do arquivo</param>
        /// <param name="tipoArquivo">Tipo do arquivo</param>
        /// <param name="descricaoArquivo">Descrição do arquivo</param>
        /// <param name="emailDestinatario">Email do destinatario que tera acesso ao compartilhamento, se vázio o compartilhamento é para qualquer um</param>
        /// <returns></returns>
        public static string UploadFile(string caminhoArquivo, string nomeArquivo, eGoogleDriveMimeType tipoArquivo, string descricaoArquivo, eRetornoLink retornoLink , string emailDestinatario = "")
        {
            using (Stream stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read))
            {
                DriveService service = GetService();
                string mime = DescricaoEnum(tipoArquivo);

                Google.Apis.Drive.v3.Data.File driveFile = new Google.Apis.Drive.v3.Data.File
                {
                    Name = nomeArquivo,
                    Description = descricaoArquivo,
                    MimeType = mime
                };
                if (!string.IsNullOrEmpty(IdPasta))
                {
                    driveFile.Parents = new List<string> { IdPasta };
                }

                var request = service.Files.Create(driveFile, stream, mime);
                request.Fields = "id";

                var response = request.Upload();
                if (response.Status != UploadStatus.Completed)
                {
                    throw new Exception(response.Exception.Message);
                }

                PermitirCompartilhamentoArquivo(service, request, emailDestinatario);

                if (retornoLink == eRetornoLink.LINK) {
                    return $"https://drive.google.com/file/d/{request.ResponseBody.Id}/view?usp=sharing";
                }else
                {
                    return $"https://drive.google.com/uc?export=download&id={request.ResponseBody.Id}";
                }

            }
        }

        /// <summary>
        /// Deleta o arquivo pelo Id
        /// </summary>
        /// <param name="idArquivo"></param>
        public static void DeletarArquivo(string idArquivo)
        {
            DriveService service = GetService();
            var command = service.Files.Delete(idArquivo);
            var result = command.Execute();
        }

        /// <summary>
        /// Coleta todos os arquivos dentro da pasta pelo Id
        /// </summary>
        /// <param name="idPasta"></param>
        /// <returns></returns>
        public static IEnumerable<Google.Apis.Drive.v3.Data.File> GetFiles(string idPasta)
        {
            DriveService service = GetService();

            FilesResource.ListRequest fileList = service.Files.List();
            fileList.Q = $"mimeType!='application/vnd.google-apps.folder' and '{idPasta}' in parents";
            fileList.Fields = "nextPageToken, files(id, name, size, mimeType)";

            List<Google.Apis.Drive.v3.Data.File> result = new List<Google.Apis.Drive.v3.Data.File>();
            string pageToken = null;
            do
            {
                fileList.PageToken = pageToken;
                var filesResult = fileList.Execute();
                var files = filesResult.Files;
                pageToken = filesResult.NextPageToken;
                result.AddRange(files);
            } while (pageToken != null);

            return result;
        }

        /// <summary>
        /// Coleta um arquivo em específico dentro da pasta pelo Id
        /// </summary>
        /// <param name="idPasta"></param>
        /// <param name="idArquivo"></param>
        /// <returns></returns>
        public static Google.Apis.Drive.v3.Data.File GetFiles(string idPasta, string idArquivo)
        {
            DriveService service = GetService();

            var request = service.Files.Get(idArquivo);
            request.Fields = "id, name, size, mimeType";
            var file = request.Execute();

            if (file.Parents != null && file.Parents.Contains(idPasta))
            {
                return file;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Permite compartilhamento do arquivo para determinado endereço de email ou para qualquer um
        /// </summary>
        /// <param name="servico">Serviço atual que está sendo utilizado</param>
        /// <param name="request">Requisição</param>
        /// <param name="emailDestinatario">Email do destinatario que tera acesso ao compartilhamento, se vázio o compartilhamento é para qualquer um</param>>
        private static void PermitirCompartilhamentoArquivo(DriveService servico, FilesResource.CreateMediaUpload request, string emailDestinatario)
        {
            var permission = new Permission();
            bool acessoUnico = !string.IsNullOrEmpty(emailDestinatario);

            permission.Type = acessoUnico ? "user" : "anyone";
            permission.Role = "reader";

            if (acessoUnico)
            {
                permission.EmailAddress = emailDestinatario;
            }
            else
            {
                permission.AllowFileDiscovery = false;
            }

            servico.Permissions.Create(permission, request.ResponseBody.Id).Execute();
        }

        /// <summary>
        /// Coleta a descrição do ENUM
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string DescricaoEnum(Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Autenticação da API do Google Drive
        /// </summary>
        /// <param name="caminhoCredencial">Caminho do arquivo json com o client id e a chave secreta</param>
        /// <returns></returns>
        public static UserCredential Autenticar(string caminhoCredencial)
        {
            string[] scopes = {
            DriveService.Scope.Drive,
            DriveService.Scope.DriveAppdata,
            DriveService.Scope.DriveFile,
            DriveService.Scope.DriveMetadata,
            DriveService.Scope.DriveMetadataReadonly,
            DriveService.Scope.DrivePhotosReadonly,
            DriveService.Scope.DriveReadonly,
            DriveService.Scope.DriveScripts
        };

            // Carrega o arquivo JSON contendo o Client ID e a chave secreta
            string credenciaisJson = caminhoCredencial;

            // Faz a autorização do usuário
            UserCredential credenciais = GetCredentials(credenciaisJson, scopes);

            return credenciais;
        }

        /// <summary>
        /// Retorna as credenciais (RefreshToken e AccessToken) atraves de uma requisição
        /// </summary>
        /// <param name="credenciaisJson"></param>
        /// <param name="scopes"></param>
        /// <returns></returns>
        private static UserCredential GetCredentials(string credenciaisJson, string[] scopes)
        {
            using (FileStream stream = new FileStream(credenciaisJson, FileMode.Open, FileAccess.Read))
            {
                string diretorioArmazenamento = Path.Combine(Path.GetTempPath(), ".credentials");

                var clientSecrets = GoogleClientSecrets.FromStream(stream).Secrets;

                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    scopes,
                    "user",
                    System.Threading.CancellationToken.None,
                    new FileDataStore(diretorioArmazenamento)
                ).Result;

                return credential;
            }
        }
    }
}
using Gs1XmlTransfer.Persistence;
using Gs1XmlTransfer.Services;
using NLog;
using Microsoft.Extensions.Configuration;
using Gs1XmlTransfer.Interfaces;
using Gs1XmlTransfer.Configuration;
using Gs1XmlTransfer;

ILogger logger = LogManager.GetCurrentClassLogger();
IAppConfiguration config = AppConfigurationBuilder.Get().Get<AppConfiguration>();
ICatalogueXmlConverter xmlConverter = new CatalogueXmlConverter();
ICatalogueRepository catalogueRepository = new CatalogueRepository();

IXmlFileReader xmlFileReader = config.UseLocalFiles ?
     new LocalFileReader(config.LocalFilesDirectory) : new FtpFileReader(config.Ftp.Host, config.Ftp.Directory, config.Ftp.UserName, config.Ftp.Password);

var gs1Xml = new Gs1Xml(logger, xmlFileReader, xmlConverter, catalogueRepository);
gs1Xml.Transfer();

namespace Gs1XmlTransfer
{
    public class Gs1Xml
    {
        private readonly ILogger _logger;
        private readonly IXmlFileReader _xmlReader;
        private readonly ICatalogueXmlConverter _xmlConverter;
        private readonly ICatalogueRepository _catalogueRepository;

        public Gs1Xml(ILogger logger, IXmlFileReader xmlReader, ICatalogueXmlConverter xmlConverter, ICatalogueRepository catalogueRepository)
        {
            _logger = logger;
            _xmlReader = xmlReader;
            _xmlConverter = xmlConverter;
            _catalogueRepository = catalogueRepository;
        }

        public void Transfer()
        {
            try
            {
                Console.WriteLine("Transferring Notification Messages - this may take several minutes.. \n");
                TransferNotificationMessages();

                Console.WriteLine("\nTransferring Withdrawal Messages - this may take several minutes.. \n");
                TransferWithdrawalMessages();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message + "\n" + e.StackTrace + "\n" + e.InnerException + "\n");
                Console.WriteLine(e.Message + "\n" + e.StackTrace + "\n" + e.InnerException + "\n");
            }
        }

        void TransferWithdrawalMessages()
        {
            var fileNames = _xmlReader.ReadFileNames().Where(f => f.StartsWith("CIHW")).ToList();

            fileNames.ForEach(fileName =>
            {
                if (!_catalogueRepository.FileIsPersisted(fileName))
                {
                    Console.WriteLine(fileName);
                    var xml = _xmlReader.ReadXml(fileName);
                    var withDrawalMessage = _xmlConverter.ConvertWithdrawalMessage(xml, fileName);
                    _catalogueRepository.SaveMessage(withDrawalMessage);
                }
            });
        }

        void TransferNotificationMessages()
        {
            var fileNames = _xmlReader.ReadFileNames().Where(f => f.StartsWith("CIN")).ToList();

            fileNames.ForEach(fileName =>
            {
                if (!_catalogueRepository.FileIsPersisted(fileName))
                {
                    Console.WriteLine(fileName);
                    var xml = _xmlReader.ReadXml(fileName);
                    var notificationMessage = _xmlConverter.ConvertNotificationMessage(xml, fileName);
                    _catalogueRepository.SaveMessage(notificationMessage);
                }                
            });
        }
    }
}
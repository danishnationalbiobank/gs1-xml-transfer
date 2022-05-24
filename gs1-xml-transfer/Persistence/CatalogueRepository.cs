using Gs1XmlTransfer.Exceptions;
using Gs1XmlTransfer.Interfaces;
using Gs1XmlTransfer.Models;
using Microsoft.EntityFrameworkCore;

namespace Gs1XmlTransfer.Persistence
{
    public class CatalogueRepository : ICatalogueRepository
    {
        public List<string?> GetPersistedNotificationMessages()
        {
            var persistedFiles = new List<string?>();

            using (var db = new Gs1CatalogueContext())
            {
                persistedFiles.AddRange(db.NotificationMessage?.Select(x => x.FileName).ToList() ?? new List<string?>());
            }

            return persistedFiles;
        }

        public List<string?> GetPersistedWithdrawalMessages()
        {
            var persistedFiles = new List<string?>();

            using (var db = new Gs1CatalogueContext())
            {
                persistedFiles.AddRange(db.WithdrawalMessage?.Select(x => x.FileName).ToList() ?? new List<string?>());
            }

            return persistedFiles;
        }

        public void SaveMessage(CatalogueMessage message)
        {
            using (var db = new Gs1CatalogueContext())
            {
                db.Add(message);
                db.SaveChanges();
            }
        }

        public bool FileIsPersisted(string fileName)
        {
            if (fileName.StartsWith("CIN"))
            {
                var persistedFileNames = GetPersistedNotificationMessages();
                return persistedFileNames.Contains(fileName);
            }

            if (fileName.StartsWith("CIHW"))
            {
                var persistedFileNames = GetPersistedWithdrawalMessages();
                return persistedFileNames.Contains(fileName);
            }

            throw new CatalogueFileNameException("Cannot handle file with name: " + fileName);
        }
    }
}

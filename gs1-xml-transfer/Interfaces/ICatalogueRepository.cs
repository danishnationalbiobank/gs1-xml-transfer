using Gs1XmlTransfer.Models;

namespace Gs1XmlTransfer.Interfaces
{
    public interface ICatalogueRepository
    {
        bool FileIsPersisted(string fileName);
        List<string?> GetPersistedNotificationMessages();
        List<string?> GetPersistedWithdrawalMessages();
        void SaveMessage(CatalogueMessage message);
    }
}